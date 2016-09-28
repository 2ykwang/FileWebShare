using System;
using System.Net.Sockets;
using System.IO;

namespace FileWebShare
{
	public class ResponseHandler
	{
		private ServerSetting _serverSetting;
		private Client _client; 

		public ResponseHandler(ServerSetting serverSetting, Client  client)
		{
			_serverSetting = serverSetting;
			_client = client;
		} 

		public void RequestProcess()
		{
			InitializeResponse(_client.Response);

			CreateResponse();
			 
			SendResponse(_client);
		}
		private void CreateResponse()
		{ 
			Route route = _serverSetting.RouteList.HasController(_client.Response.RequestRoute.ControllerName); 

#if DEBUG
			//Console.WriteLine(_client.Request.HeaderCollection.ToString());
			//Console.WriteLine($"요청 컨트롤러 {_client.Response.RequestRoute.ControllerName} 요청 메소드: {_client.Response.RequestRoute.ControllerMethod}");
#endif
			if (route == null || !route.Methods.Contains(_client.Response.RequestRoute.ControllerMethod))
			{ 
				SetNotFound(_client.Response);
				return;
			}  

			_client.Response.ResponseCode = ResponseCode.Ok;

			var method = route.Type.GetMethod(_client.Response.RequestRoute.ControllerMethod);

			Controller instance = (Controller)route.Type.GetConstructor(new Type[] { }).Invoke(new object[] { });  
			instance.Initialize(_client);
			//컨트롤러 메소드 호출
			method.Invoke(instance, _client.Response.RequestRoute.Parameters);

			if (_client.Response.isFile == true && !File.Exists(_client.Response.FilePath))
			{
				//File Not Found
				SetNotFound(_client.Response);
				return;
			} 
		}


		private void SendResponse(Client client)
		{
			NetworkStream networkStream = client.TcpClient.GetStream();

			byte[] buf = new byte[_serverSetting.BufferSize]; 

			//Send header
			string header = ResponseHeaderBuilder(client.Response.Headers, client.Response.ResponseCode);

			buf = System.Text.Encoding.UTF8.GetBytes($"{header}");
			SendData(networkStream, buf,0, buf.Length);

			if (client.Response.isFile)
			{
				SendFile(networkStream, client.Response.FilePath);
			}
			else
			{
				buf = System.Text.Encoding.UTF8.GetBytes(client.Response.Body.ToString());
				client.Response.Body = null;
				int offset = 0,
					sendBufLength = 0,
					bufLength = buf.Length; 

				while(offset < bufLength && _client.TcpClient.Client.Connected)
				{ 
					sendBufLength = (offset + _serverSetting.BufferSize - bufLength < 1) ?
					_serverSetting.BufferSize : bufLength - offset;

					//Console.WriteLine(sendBufLength); 
					if(SendData(networkStream, buf, offset, sendBufLength) == false)
					{
						break;
					}
					offset += sendBufLength; 
				}
			}
			//Send body
			networkStream.Close(); 
		}

		private void InitializeResponse(Response response)
		{
			response.Headers["Server"] = _serverSetting.ServerName;
			response.Headers["Connection"] = "close";
			response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
		}

		private void SetNotFound(Response response)
		{
			string data = "<html><head></head><body>Not Found!</body></html>";

			_client.Response.ResponseCode = ResponseCode.NotFound;
			_client.Response.Headers["Content-Type"] = "text/html charset=utf8";
			_client.Response.Headers["Content-Length"] = data.Length.ToString();
			_client.Response.Body = new System.Text.StringBuilder(data);

			_client.Response.FilePath = "";
			_client.Response.isFile = false; 
		}

		private string ResponseHeaderBuilder(HeaderCollection headerCollection, ResponseCode code)
		{
			string header = $"HTTP/1.1 {ResponseCodeGenerator.GetResponseTextFromCode(code)}{Environment.NewLine}";
			header += $"{headerCollection.ToString()}{Environment.NewLine}";
			return header;
		}
		 
		private bool SendData( Stream  stream, byte[] data,int offset,int length)
		{
			try
			{
				if (stream != null && _client.TcpClient.Client.Connected && _client.TcpClient.Client.Poll(60000,SelectMode.SelectWrite))
				{
					stream.Write(data, 0, data.Length);
					stream.Flush(); 
				}
				return true;
			}
			catch 
			{
				//데이터 전송도중 연결 끊김 
				return false;
			}
		}

		private void SendFile(Stream stream, string path)
		{
			BinaryReader binReader = new BinaryReader(new StreamReader(path).BaseStream);

			byte[] readBytes = new byte[_serverSetting.BufferSize];

			while ((readBytes = binReader.ReadBytes(_serverSetting.BufferSize)).Length > 0)
			{
				try
				{  
					SendData(stream, readBytes, 0, readBytes.Length);  
				}
				catch (IOException)
				{
					Console.WriteLine("데이터 전송도중 연결 끊김");
					break;
				}
			}
			binReader.Close(); 
		}
	}
}
