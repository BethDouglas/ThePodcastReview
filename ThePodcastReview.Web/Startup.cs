using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThePodcastReview.Web.Startup))]
namespace ThePodcastReview.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
