using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FileWebShare
{
	public class Route
	{ 

		public string ControllerName { get; private set; }

		public List<string> Methods { get; private set; }

		public Type Type { get; private set; }
		public Route(List<string> methods, Type type, string controllerName)
		{
			Methods = methods;
			Type = type;
			ControllerName = controllerName; 
		} 
	}
}
