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
		private ServerSetting _serverSetting;
		private TcpClient _tcpClient;


		public HttpHandler(TcpClient tcpClient, ServerSetting serverSetting)
		{
			_tcpClient = tcpClient;
			_serverSetting = serverSetting;
		}

		public void RequestProcess()
		{
			Client client = new Client(_tcpClient, new Request(), new Response());

			RequestGenerator requestGenerator = new RequestGenerator(_serverSetting);
			requestGenerator.Process(_tcpClient, client.Request);

			Console.WriteLine(client.Request.HeaderCollection.ToString());
			ResponseGenerator responseGenerator = new ResponseGenerator(_serverSetting, client.Request);
			responseGenerator.Process(client.Response);

			ResponseHandler responseHandler = new ResponseHandler
				(
					serverSetting: _serverSetting,
					client: client
				);

			responseHandler.RequestProcess();
		}
	}
}
