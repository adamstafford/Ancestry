using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ancestry.Startup))]
namespace Ancestry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
