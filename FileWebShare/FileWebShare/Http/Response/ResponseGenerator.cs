using System;
using System.Web;
using System.Collections.Specialized;
using System.Collections.Generic;
namespace FileWebShare
{
	public class ResponseGenerator
	{ 
		public ServerSetting ServerSetting { get; private set; }
		public Request Request { get; private set; }

		public ResponseGenerator(ServerSetting serverSetting, Request request)
		{
			ServerSetting = serverSetting;
			Request = request;
		}

		public void Process(Response response)
		{
			
		} 
	}
}
