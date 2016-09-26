using System;
using System.Net;
using System.Net.Sockets;

namespace FileWebShare.Extension
{
	public class NetworkInfo
	{ 
		public static IPAddress GetLocalIPAddress()
		{
			IPAddress result = null;
			IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress[] ipv4Address = Array.FindAll(
				iphostentry.AddressList, add => add.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(add));
			if (ipv4Address.Length > 0)
			{
				result = ipv4Address[0];
			}
			return result;
		} 
	}
}
