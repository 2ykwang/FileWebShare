using System;
namespace FileWebShare
{
	public class Response
	{
		public string HttpStatus { get; set; }

		public HeaderCollection Headers { get; set; }

		public string ContentType { get; set; }

		public string body { get; set; }

		public bool isFile { get; set; } 

		public Response()
		{
			Headers = new HeaderCollection();
		}
	}
}
