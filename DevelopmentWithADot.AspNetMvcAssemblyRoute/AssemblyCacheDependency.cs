using System.IO;
using System.Reflection;
using System.Web.Caching;

namespace DevelopmentWithADot.AspNetMvcAssemblyRoute
{
	class AssemblyCacheDependency : CacheDependency
	{
		private readonly Assembly assembly;

		public AssemblyCacheDependency(Assembly assembly)
		{
			this.assembly = assembly;
			this.SetUtcLastModified(File.GetCreationTimeUtc(assembly.Location));
		}
	}
}
