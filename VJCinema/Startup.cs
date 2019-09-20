using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VJCinema.Startup))]
namespace VJCinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
