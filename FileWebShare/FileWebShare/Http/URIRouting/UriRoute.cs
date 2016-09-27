using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWebShare
{
	class UriRoute
	{
		private UriData _uriData;
		private ServerSetting _serverSetting;

		public UriRoute(ServerSetting serverSetting,UriData uriData)
		{
			_serverSetting = serverSetting;
			_uriData = uriData;
		}
		public RequestRoute GetRequestRoute()
		{
			RequestRoute requestRoute = new RequestRoute();

			requestRoute.ControllerMethod = _serverSetting.DefaultMethod;
			requestRoute.ControllerName = _serverSetting.DefaultController;

			if (_uriData.GetSegmentCount() < 1) // 세그먼트가 존재하지 않을경우 기본값 할당
			{ 
				return requestRoute;
			}
			/*
			 * 첫 번째 세그먼트에 메소드가 올 수 있음 다만 다른 컨트롤러와 겹치는 메소드일경우 컨트롤러가 우선이 됨 
			 */
			if (_serverSetting.RouteList.Routes.ContainsKey(_uriData.GetSegment(0)))
			{
				requestRoute.ControllerName = _uriData.GetSegment(0);
				if(
					_uriData.GetSegmentCount() > 1  
					)
				{
					requestRoute.ControllerMethod = _uriData.GetSegment(1);
				} 
			}
			else
			{
				// 해당하는 컨트롤러 존재하지 않을경우  
				requestRoute.ControllerName = _uriData.GetSegment(0);

				if (_uriData.GetSegmentCount()>1)
					requestRoute.ControllerMethod = _uriData.GetSegment(0);


				//첫 번째 세그먼트가 기본 컨트롤러의 메소드와 일치할경우 지정
				if(((Route)_serverSetting.RouteList.Routes[_serverSetting.DefaultController]).Methods.Contains(_uriData.GetSegment(0)))
				{ 
					requestRoute.ControllerName = _serverSetting.DefaultController;
					requestRoute.ControllerMethod = _uriData.GetSegment(0);
				}
			}

			return requestRoute;
		}
	}
}
