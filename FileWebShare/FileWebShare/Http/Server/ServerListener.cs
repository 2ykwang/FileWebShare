using System;
namespace FileWebShare.Server
{
	public abstract class ServerListener : Server
	{ 

		public ServerListener(ServerSetting serverSetting) : base(serverSetting)
		{
			ServerSetting = serverSetting;
		}
		
	}
}
