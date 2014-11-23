using System.Web.Mvc;

namespace DevelopmentWithADot.AspNetMvcAssemblyRoute.Lib.Controllers
{
	public class TestController : Controller
	{
		public ActionResult Index()
		{
			var data = this.Request.RequestContext.RouteData;
			return (this.View());
		}
	}
}
