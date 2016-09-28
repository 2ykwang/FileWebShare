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
			CreateResponse();
			 
			SendResponse(_client);
		}
		private void CreateResponse()
		{ 
			Route route = _serverSetting.RouteList.HasController(_client.Response.RequestRoute.ControllerName);

#if DEBUG
			Console.WriteLine($"요청 컨트롤러 {_client.Response.RequestRoute.ControllerName} 요청 메소드: {_client.Response.RequestRoute.ControllerMethod}");
#endif
			if (route == null || !route.Methods.Contains(_client.Response.RequestRoute.ControllerMethod))
			{ 
				SetNotFound(_client.Response);
				return;
			}

			if (_client.Response.isFile == true && !File.Exists(_client.Response.FilePath))
			{
				//File Not Found
				SetNotFound(_client.Response);
				return;
			}

			_client.Response.ResponseCode = ResponseCode.Ok;

			var method = route.Type.GetMethod(_client.Response.RequestRoute.ControllerMethod);

			Controller instance = (Controller)route.Type.GetConstructor(new Type[] { }).Invoke(new object[] { });  
			instance.Initialize(_client);
			 
			method.Invoke(instance, _client.Response.RequestRoute.Parameters); 
		}


		private void SendResponse(Client client)
		{
			NetworkStream networkStream = client.TcpClient.GetStream();

			byte[] buf = new byte[1024];
			
			//Send header
			string header = ResponseHeaderBuilder(client.Response.Headers, client.Response.ResponseCode);
			buf = System.Text.Encoding.UTF8.GetBytes($"{header}");
			SendData(buf, networkStream); 

			if(client.Response.isFile)
			{
				SendFile(client.Response.FilePath, networkStream);
			}
			else
			{ 
				buf = System.Text.Encoding.UTF8.GetBytes($"{client.Response.Body}"); 
				SendData(buf, networkStream);
			}
			//Send body
			networkStream.Close();
		}


		private void SendFile(string path,Stream networkStream)
		{ 
			BinaryReader binReader = new BinaryReader(new StreamReader(path).BaseStream);

			byte[] readBytes = new byte[1024];

			while ((readBytes = binReader.ReadBytes(1024)).Length > 0)
			{
				try
				{
					SendData(readBytes, networkStream);
				}
				catch(IOException)
				{
					Console.WriteLine("데이터 전송도중 연결 끊김");
					break;
				}
			}
			binReader.Close();
		}
		private void SetNotFound(Response response)
		{
			string data = "<html><head></head><body>Not Found!</body></html>";
			_client.Response.ResponseCode = ResponseCode.NotFound;
			_client.Response.Headers["Content-Type"] = "text/html charset=utf8";
			_client.Response.Headers["Content-Length"] = data.Length.ToString();
			_client.Response.Body = data; 
		}

		private string ResponseHeaderBuilder(HeaderCollection headerCollection, ResponseCode code)
		{
			string header = $"HTTP/1.1 {ResponseCodeGenerator.GetResponseTextFromCode(code)}{Environment.NewLine}";
			header += $"{headerCollection.ToString()}{Environment.NewLine}";
			return header;
		}


		private static void SendData(byte[] data, Stream stream)
		{
			try
			{
				if (stream != null)
				{
					stream.Write(data, 0, data.Length);
					stream.Flush();
				}
			}
			catch (System.Exception e)
			{
				System.Console.WriteLine("SendData Error: " + e.ToString());
			}
		}
	}
}
