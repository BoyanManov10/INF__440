using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INF__440.Startup))]
namespace INF__440
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
