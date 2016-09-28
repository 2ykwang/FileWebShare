using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Reflection;
using System.Collections;
using System.Data.SQLite;
using System.Text;

namespace FileWebShare
{
    static class Program
    { 
        static void Main()
		{ 
				 
			ServerSetting setting = new ServerSetting
			{
				ControllerTrigger = "c",
				MethodTrigger = "m",
				DefaultController = "View",
				DefaultMethod = "Index",
				BufferSize = 2048,
				IPAddress = IPAddress.Any,
				RouteList = new RouteList(),
				Port = 5555,
				ServerName ="File Web Share"
			}; 
			ServerListener Listener = new ServerListener(setting);

			Listener.Start();
			while (true)
			{
				System.Threading.Thread.Sleep(1000);
			}
		}
	} 
}
