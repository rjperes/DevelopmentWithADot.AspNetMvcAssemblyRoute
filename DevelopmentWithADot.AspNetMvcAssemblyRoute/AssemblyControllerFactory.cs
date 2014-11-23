using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevelopmentWithADot.AspNetMvcAssemblyRoute
{
	class AssemblyControllerFactory : DefaultControllerFactory
	{
		private readonly IDictionary<String, Type> controllerTypes;

		public AssemblyControllerFactory(Assembly assembly)
		{
			this.controllerTypes = assembly.GetExportedTypes().Where(x => (typeof(IController).IsAssignableFrom(x) == true) && (x.IsInterface == false) && (x.IsAbstract == false)).ToDictionary(x => x.Name, x => x);
		}

		public override IController CreateController(RequestContext requestContext, String controllerName)
		{
			var controller = base.CreateController(requestContext, controllerName);

			if (controller == null)
			{
				var controllerType = this.controllerTypes.Where(x => x.Key == String.Format("{0}Controller", controllerName)).Select(x => x.Value).SingleOrDefault();
				var controllerActivator = DependencyResolver.Current.GetService(typeof (IControllerActivator)) as IControllerActivator;

				if (controllerType != null)
				{
					if (controllerActivator != null)
					{
						controller = controllerActivator.Create(requestContext, controllerType);
					}
					else
					{
						controller = Activator.CreateInstance(controllerType) as IController;
					}
				}
			}

			return (controller);
		}
	}
}
