using System;
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

		public void Initialize(Client clientData)
		{
			ClientData = clientData;
		}
		public abstract void Index();
	}
}
