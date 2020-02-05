using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTimeSheetProject_Practice.Startup))]
namespace WebTimeSheetProject_Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
