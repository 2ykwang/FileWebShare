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
<a href ='/test2'>test</a>
	</body>
</html> 
				"); 
		}
		public void test(string test, string test2)
		{
			for (int i = 0; i < 1000000; i++)
			{
				WriteHtml(i.ToString());
			}
		}
		public void test2()
		{
			SetFile(@"C:\Users\csdp0\Downloads\Home.Alone.2.Lost.in.New.York.1992.720p.BluRay.x264.YIFY.mp4");
		}
	}
}
