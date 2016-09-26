using System;
using System.Reflection;
using System.Net;

namespace FileWebShare.Server
{
	public class ServerSetting
	{ 
		public IPAddress IPAdress { get; set; }

		public int Port { get; set; }


		public ServerSetting()
		{
		}
	}
}
