using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeadHunterProject.Startup))]
namespace HeadHunterProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
