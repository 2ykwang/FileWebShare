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
			InitializeResponse(response);
			 
			HttpGetCollection getCollection = new HttpGetCollection();
			getCollection.AddParameterFromQueryString(Request.Uri.Query);

			UriRoute uriRoute = new UriRoute(ServerSetting, Request.Uri);
			RequestRoute requestRoute = uriRoute.GetRequestRoute();

			/*
			//컨트롤러 인자가 전잘되지 않았을경우 기본인자로 세팅  
			requestRoute.ControllerName = getCollection.Contains(ServerSetting.ControllerTrigger) ?
				 getCollection[ServerSetting.ControllerTrigger] : ServerSetting.DefaultController;

			requestRoute.ControllerMethod = getCollection.Contains(ServerSetting.MethodTrigger) ?
				 getCollection[ServerSetting.MethodTrigger] : ServerSetting.DefaultMethod;
			*/
			response.RequestRoute = requestRoute;
		}
		private void InitializeResponse(Response response)
		{ 
			response.Headers["Server"] = ServerSetting.ServerName;
			response.Headers["Connection"] = "close";
			response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
		}
	}
}
