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
			WriteHtml(
				$@"
<!DOCTYPE HTML>
<html>
	<head>
	</head>
	<body>
		View 컨트롤러를 사용하여 Test 메소드를 요청했고 <br/>
		{test}를 변수로 넘겼다 이기야~! 
	</body>
</html>
				");
		}
	}
}
