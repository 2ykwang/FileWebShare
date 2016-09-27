using System;
using System.Net.Sockets;

namespace FileWebShare
{
	public class ResponseHandler
	{
		private ServerSetting _serverSetting;
		private Request _tcpClient;
		private Response _response;

		public ResponseHandler(ServerSetting serverSetting, TcpClient  tcpClient)
		{
			_serverSetting = serverSetting; 
		} 
	}
}
