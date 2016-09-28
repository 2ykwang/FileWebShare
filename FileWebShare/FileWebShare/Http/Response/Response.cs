using System;
using System.IO;
using System.Text;

namespace FileWebShare
{
	public class Response
	{  
		public HeaderCollection Headers { get; private set; }
		  
		public StringBuilder Body { get; set; }

		public bool isFile { get; set; }

		public string FilePath { get; set; }

		public ResponseCode ResponseCode { get; set; }

		public RequestRoute RequestRoute { get; set; } 

		
		public Response()
		{
			Headers = new HeaderCollection();
			Body = new StringBuilder();
		}
	}
}
