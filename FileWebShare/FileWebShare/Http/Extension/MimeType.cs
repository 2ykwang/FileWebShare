using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace FileWebShare
{
	public class MimeType
	{
		private static Dictionary<string, string> _mimeTypes = new Dictionary<string, string>()
		{
			{"bmp", "image/bmp"},
			{"css", "text/css"},
			{"gif", "image/gif"},
			{"htm", "text/html; charset=UTF-8"},
			{"html", "text/html; charset=UTF-8"},
			{"jpe", "image/jpeg"},
			{"jpeg", "image/jpeg"},
			{"jpg", "image/jpeg"},
			{"js", "application/x-javascript"},
			{"png", "image/png"},
			{"xhtml", "application/xhtml+xml"},
			{"woff", "application/font-woff"},
			{"ttf", "application/x-font-truetype"},
			{"svg", "image/svg+xml"},
			{"txt", "text/plain"},
			{"exe", "application/octet-stream"},
			{"mp4", "video/mp4" }
		};
		public static string GetMime(string requestFile)
		{
			string outputMime = "text/html; charset=UTF-8";
			string fileName = requestFile.ToLower().Trim();

			int pos = fileName.LastIndexOf(".");
			if (pos != -1 && pos + 1 < fileName.Length)
			{
				string fileExtension = fileName.Substring(pos + 1);
				if (_mimeTypes.ContainsKey(fileExtension))
				{
					outputMime = _mimeTypes[fileExtension];
				}
			}
			return outputMime;
		}
		public static string GetMimeFromExtension(string extension)
		{
			string outputMime = "text/html; charset=UTF-8";

			string fileExtension = extension.ToLower();
			if (_mimeTypes.ContainsKey(fileExtension))
			{
				outputMime = _mimeTypes[fileExtension];
			} 
			return outputMime;
		}
	}
}
