using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DB55.Startup))]
namespace DB55
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
