using System;
using System.Net.Sockets;

namespace FileWebShare
{
	public class ResponseHandler
	{
		private ServerSetting _serverSetting;
		private TcpClient _tcpClient;


		public ResponseHandler(ServerSetting serverSetting, TcpClient  tcpClient)
		{
			_serverSetting = serverSetting;
			_tcpClient = tcpClient;
		}
		public void RequestProcess()
		{
			Client client = new Client(_tcpClient, new Request(), new Response());

			RequestGenerator requestGenerator = new RequestGenerator(_serverSetting);
			requestGenerator.Process(_tcpClient, client.Request);

			Console.WriteLine(client.Request.HeaderCollection.ToString());


		}
	}
}
