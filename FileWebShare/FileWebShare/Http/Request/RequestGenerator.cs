using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace FileWebShare
{
	public class RequestGenerator
	{
		public ServerSetting ServerSetting { get; private set; }

		public RequestGenerator(ServerSetting serverSetting)
		{
			ServerSetting = serverSetting;
		}

		public Request Process(TcpClient tcpClient)
		{
			Request request = new Request();



			return request;
		}
		 
	}
}
