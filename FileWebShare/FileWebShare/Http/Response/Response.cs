using System;
namespace FileWebShare
{
	public class Response
	{  
		public HeaderCollection Headers { get; private set; }
		 

		public string Body { get; set; } 

		public bool isFile { get; set; }

		public ResponseCode ResponseCode { get; set; }

		public RequestRoute RequestRoute { get; set; }
		 
		public Response()
		{
			Headers = new HeaderCollection();
		}
	}
}
