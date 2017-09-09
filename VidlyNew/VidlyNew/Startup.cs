using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyNew.Startup))]
namespace VidlyNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
