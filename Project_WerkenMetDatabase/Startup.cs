using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_WerkenMetDatabase.Startup))]
namespace Project_WerkenMetDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
