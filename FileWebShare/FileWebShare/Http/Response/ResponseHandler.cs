using System;
using System.Net.Sockets;

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

			if (route != null) 
			{ 
				if(route.Methods.Contains(_client.Response.RequestRoute.ControllerMethod))
				{
					_client.Response.ResponseCode = ResponseCode.Ok;

					var method = route.Type.GetMethod(_client.Response.RequestRoute.ControllerMethod);

					Controller instance = (Controller)route.Type.GetConstructor(new Type[] { }).Invoke(new object[] { });
					instance.Initialize(_client);
					
					method.Invoke(instance, null);
				}
				else
				{
					SetNotFound(_client.Response);
				}
			}
			else // 존재하지 않는 컨트롤 이름
			{ 
				SetNotFound(_client.Response);
			}
		}
		private void SendResponse(Client client)
		{
			NetworkStream networkStream = client.TcpClient.GetStream();

			byte[] buf = new byte[2048];
			string header = ResponseHeaderBuilder(client.Response.Headers, client.Response.ResponseCode);
			buf = System.Text.Encoding.UTF8.GetBytes($"{header}{client.Response.Body}");

			networkStream.Write(buf, 0, buf.Length);
			networkStream.Flush();
			networkStream.Close();
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
	}
}
