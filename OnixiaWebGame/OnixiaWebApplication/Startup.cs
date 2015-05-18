using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnixiaWebApplication.Startup))]
namespace OnixiaWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
