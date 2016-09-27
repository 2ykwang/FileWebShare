using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWebShare
{
	public class ClientData
	{
		public Request Request { get; private set; }
		public Response Response { get; private set; } 

		public ClientData(Request request, Response response)
		{
			Request = request;
			Response = response;
		}
	}
}
