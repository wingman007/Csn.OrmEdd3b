using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Csn.OrmEdd3b.App.Startup))]
namespace Csn.OrmEdd3b.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
