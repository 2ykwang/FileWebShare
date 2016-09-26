using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FileWebShare
{
	class Route
	{ 

		public string ControllerName { get; private set; }

		public List<string> Methods { get; private set; }

		public Route(List<string> methods, string controllerName)
		{
			Methods = methods;
			ControllerName = controllerName; 
		}

	}
}
