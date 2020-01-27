using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIA_Immigration.Startup))]
namespace MIA_Immigration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
