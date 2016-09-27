using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets; 

namespace FileWebShare
{
	public class Client
	{
		public Request Request { get; private set; }

		public Response Response { get; private set; }

		public TcpClient TcpClient { get; private set; } 

		public Client(TcpClient client, Request request, Response response)
		{
			TcpClient = client;
			Request = request;
			Response = response;
		}
	}
}
