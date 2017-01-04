[assembly: Microsoft.Owin.OwinStartup(typeof(ZumoCommunity.ContentApi.Api.Startup))]

namespace ZumoCommunity.ContentApi.Api
{
    using System.Web.Http;

    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}