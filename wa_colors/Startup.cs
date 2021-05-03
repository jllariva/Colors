using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wa_colors.Startup))]
namespace wa_colors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
