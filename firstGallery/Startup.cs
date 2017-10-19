using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(firstGallery.Startup))]
namespace firstGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
