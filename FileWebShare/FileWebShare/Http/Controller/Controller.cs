using System;
using System.IO; 

namespace FileWebShare
{
	public abstract class Controller : iController
	{
		 
		public Client ClientData { get;  private set; }
		 
		protected void Redirect(string url)
		{
			ClientData.Response.ResponseCode = ResponseCode.Moved;
			ClientData.Response.Headers["Location"] = url;
		}
		protected void SetHtml(string htmlText)
		{
			ClientData.Response.Body = htmlText;
			ClientData.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
			ClientData.Response.Headers["Content-Length"] = htmlText.Length.ToString();
		}
		protected void SetFile(string file)
		{
			ClientData.Response.FilePath = file;
			ClientData.Response.isFile = true; 
			try
			{
				FileInfo fileInfo = new FileInfo(file);
				if (fileInfo.Exists)
				{
					ClientData.Response.Headers["Content-Type"] = MimeType.GetMime(fileInfo.Extension);
					ClientData.Response.Headers["Content-Length"] = fileInfo.Length.ToString();
					ClientData.Response.Headers["Content-Disposition"] = $"inline; filename=\"{fileInfo.Name}\"";
				}
				else
				{
					ClientData.Response.Headers["Content-Type"] = "text/html";
					ClientData.Response.Headers["Content-Length"] = "0";
				}
			}
			catch
			{
#if DEBUG
				Console.Write($"SetFile 에러 요청 파일 이름: {file}");
#endif
				ClientData.Response.Headers["Content-Type"] = "text/html";
				ClientData.Response.Headers["Content-Length"] = "0";
			}
		}
		public void Initialize(Client clientData)
		{
			ClientData = clientData;
		}
		public abstract void Index();
	}
}
