using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MojeAutCcentrum.Startup))]
namespace MojeAutCcentrum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
