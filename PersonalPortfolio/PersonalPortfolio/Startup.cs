using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalPortfolio.Startup))]
namespace PersonalPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
