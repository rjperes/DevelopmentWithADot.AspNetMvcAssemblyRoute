using System.Web.Mvc;
using System.Web.Routing;
using DevelopmentWithADot.AspNetMvcAssemblyRoute.Lib.Controllers;

namespace DevelopmentWithADot.AspNetMvcAssemblyRoute.Tests
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoutes(typeof(TestController).Assembly);
		}
	}
}
