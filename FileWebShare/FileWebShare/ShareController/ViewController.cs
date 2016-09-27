using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWebShare.ShareController
{
	class ViewController : Controller
	{
		public override void Index()
		{
			Client.Response.Body = "test";
			
		}
		public void test()
		{ 
		}
	}
}
