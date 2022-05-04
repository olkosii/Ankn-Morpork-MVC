using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ankn_Morpork_MVC.Startup))]
namespace Ankn_Morpork_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
