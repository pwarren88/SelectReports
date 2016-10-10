using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SelectReports.Startup))]
namespace SelectReports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
