﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace FileWebShare.Route
{
	class RouteHandler
	{
		public Hashtable Routes { get; private set; }

		public RouteHandler()
		{
			Routes = GetAllRoutes(); 
		} 

		private Hashtable GetAllRoutes()
		{
			Hashtable routes = new Hashtable();
			Assembly mscorlib = Assembly.GetExecutingAssembly();
			foreach (Type type in mscorlib.GetTypes())
			{
				if (type.IsSubclassOf(typeof(Controller.Controller)))
				{
					 
					Route route = new Route(
						methods: GetAllMethods(type),
						controllerName: GetControllerName(type.Name)
					);

					routes.Add(route.ControllerName, route); 
				}
			}
			return routes;
		}
		private List<string> GetAllMethods(Type type)
		{
			List<string> methods = new List<string>();
				
			foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
			{
				methods.Add(method.Name);
			}
			return methods;
		}
		private string GetControllerName(string controllerName)
		{
			if (controllerName.IndexOf("Controller") > 0)
			{
				return controllerName.Substring(0, controllerName.IndexOf("Controller"));
			}
			throw new Exception($"지원하지 않는 컨트롤 이름입니다 {controllerName}");
		}

	}
}