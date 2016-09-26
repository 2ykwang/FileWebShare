using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Reflection;
using System.Collections;
namespace FileWebShare
{
    static class Program
    { 
        static void Main()
        {
			/*
			Assembly mscorlib = Assembly.GetExecutingAssembly();
			foreach (Type type in mscorlib.GetTypes())
			{
				if (type.IsSubclassOf(typeof(Controller.Controller)))
				{ 
					foreach(MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
					{ 
					}
				}
			}*/
			var table = new Route.RouteHandler();
			Console.WriteLine(table.Routes.Count); 
			foreach(DictionaryEntry entry in table.Routes)
			{
				var route = (Route.Route)entry.Value;
				Console.WriteLine("" + route.ControllerName);
			}
			Console.WriteLine( ((Route.Route) table.Routes["Test"]).Methods[0]);
		}
	} 
}
