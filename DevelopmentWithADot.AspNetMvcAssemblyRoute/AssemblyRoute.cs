using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevelopmentWithADot.AspNetMvcAssemblyRoute
{
	public static class AssemblyRoute
	{
		public static void MapRoutes(this RouteCollection routes, Assembly assembly)
		{
			ControllerBuilder.Current.SetControllerFactory(new AssemblyControllerFactory(assembly));
			HostingEnvironment.RegisterVirtualPathProvider(new AssemblyVirtualPathProvider(assembly));
		}
	}
}