using System;
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace DevelopmentWithADot.AspNetMvcAssemblyRoute
{
	class AssemblyVirtualFile : VirtualFile
	{
		private readonly Assembly assembly;
		private readonly String resourceName;

		public AssemblyVirtualFile(String virtualPath, Assembly assembly, String resourceName) : base(virtualPath)
		{
			this.assembly = assembly;
			this.resourceName = resourceName;
		}

		public override Stream Open()
		{
			return (this.assembly.GetManifestResourceStream(this.resourceName));
		}
	}
}
