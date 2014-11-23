using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevelopmentWithADot.AspNetMvcAssemblyRoute.Tests.Startup))]
namespace DevelopmentWithADot.AspNetMvcAssemblyRoute.Tests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
