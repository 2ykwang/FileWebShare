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
			SetHtml(
				@"
<!DOCTYPE HTML>
<html>
	<head>
	</head>
	<body>
		Index Page
	</body>
</html>
				"); 
		}
		public void test(string test, string test2)
		{
			ClientData.Response.FilePath = @"/Users/YYG/Downloads/XamarinStudio-5.10.1.6-0.dmg";
			ClientData.Response.isFile = true;
		}
	}
}
