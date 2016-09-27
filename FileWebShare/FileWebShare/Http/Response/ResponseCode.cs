using System;
using System.Collections.Generic;

namespace FileWebShare
{
	public enum ResponseCode
	{
		Ok = 200,
		Moved = 301,
		BadRequest = 400,
		Forbidden = 403,
		NotFound = 404,
		MethodNotAllowed = 405,
		InternalServerError = 500,
		BadGateway = 502,
		NetworkAuthRequired = 511
	}; 
	public class ResponseCodeGenerator
	{
		private static Dictionary<int, string> _responseCodeText = new Dictionary<int, string>
		{
			{200,"200 Ok"},
			{301,"301 Moved Permanently"},
			{400,"400 Bad Request"},
			{403,"403 Forbidden"},
			{404,"404 Not Found"},
			{405,"405 Method Not Allowed"},
			{500,"500 Internal Server Error"},
			{502,"502 Bad Gateway"},
			{511,"511 Network Authentication Required"}
		};

		public static string GetResponseTextFromCode(ResponseCode code)
		{
			if (_responseCodeText.ContainsKey((int)code))
			{
				return _responseCodeText[(int)code];
			}
			else throw new Exception("Unknown response code");
		}


	}
}
