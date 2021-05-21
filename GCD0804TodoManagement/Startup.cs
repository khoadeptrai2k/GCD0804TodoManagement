using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0804TodoManagement.Startup))]
namespace GCD0804TodoManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
