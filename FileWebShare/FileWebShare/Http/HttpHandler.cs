using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FileWebShare
{
	class HttpHandler
	{
		public ServerSetting ServerSetting { get; private set; }
		public TcpClient TcpClient { get; private set; }

		public HttpHandler(TcpClient tcpClient, ServerSetting serverSetting)
		{
			TcpClient = tcpClient;
			ServerSetting = serverSetting;
		}

		public void RequestProcess()
		{
			
		}
	}
}
