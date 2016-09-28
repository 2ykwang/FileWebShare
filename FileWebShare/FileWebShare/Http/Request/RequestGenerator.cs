using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FileWebShare
{
	public class RequestGenerator
	{
		public ServerSetting ServerSetting { get; private set; }

		public RequestGenerator(ServerSetting serverSetting)
		{
			ServerSetting = serverSetting;
		}

		public void Process(TcpClient tcpClient, Request request)
		{ 
			byte[] buf = new byte[ServerSetting.BufferSize];
			NetworkStream networkStream = tcpClient.GetStream();

			networkStream.Read(buf, 0, buf.Length); 
			string requestString = Encoding.ASCII.GetString(buf);

			if(requestString.IndexOf("\r\n\r\n") == -1)
			{// 정상적인 요청이 아닐경우
				tcpClient.Close();
				return;
			}
			string headerString = requestString.Substring(0, requestString.IndexOf("\r\n\r\n"));

			string method = requestString.Substring(0, 4).Trim();
			
			string path = requestString.Substring(method.Length + 1, requestString.IndexOf(' ', method.Length + 1) - method.Length - 1);
			 
			string version = requestString.Substring(requestString.IndexOf(' ', method.Length + 1) + 1,
				requestString.IndexOf('\r') - requestString.IndexOf(' ', method.Length + 1) - 1);
			 

			headerString = requestString.Remove(0, requestString.IndexOf('\n'));  
			foreach (string headerLine in headerString.Split('\r'))
			{
				if(headerLine.IndexOf(":") != -1)
				{
					string[] header = headerLine.Split(':');
					string name = header[0].Trim();
					string value = header[1].Trim();

					if (name == "Host")
						value += $":{header[2].Trim()}";
					request.HeaderCollection.Add(name, value);

					
				}
			}
			if (request.HeaderCollection.Contains("Host"))
			{ 
				UriData uri = new UriData($"http://{request.HeaderCollection["Host"]}{path}");
				string body = requestString.Substring(requestString.IndexOf("\r\n\r\n") + 4);
				request.Body = body;
				request.HTTPVersion = version;
				request.IPAddress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
				request.Method = method;
				request.Uri = uri; 
			}
			else throw new Exception("Host 헤더값을 찾지 못했습니다.");
		}
		 
	}
}
