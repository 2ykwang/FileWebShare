using System;
using System.Reflection;


namespace FileWebShare.Server
{
	public class Server : ServerListener
	{ 
		/// <summary>
		/// Gets the assembly.
		/// </summary>
		/// <value>The assembly.</value>
		public Assembly Assembly { get; private set; }

		/// <summary>
		/// 서버 설정 값
		/// </summary>
		public readonly ServerSetting ServerSetting;

		public Server(ServerSetting serverSetting)
		{
			Assembly = GetType().Assembly;
			ServerSetting = serverSetting;

		}
	}
}
