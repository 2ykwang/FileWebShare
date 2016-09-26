using System;
namespace FileWebShare
{
	public class ServerListener : Server
	{ 

		public ServerListener(ServerSetting serverSetting) : base(serverSetting)
		{
			ServerSetting = serverSetting;
		}
		
	}
}
