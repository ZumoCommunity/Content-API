using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ZumoCommunity.ConfigurationAPI.Provider;
using ZumoCommunity.ConfigurationAPI.Readers.Common;

namespace ZumoCommunity.ContentApi.API
{
    public class WebApiApplication : HttpApplication
    {
        public static ConfigurationProvider ConfigurationProvider;

        protected void Application_Start()
        {
            ConfigurationProvider = new ConfigurationProvider();

            var appSettingsReader = new AppSettingsReader();
            var connectionStringsReader = new ConnectionStringsReader();

            Task.WaitAll(
                Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(appSettingsReader)),
                Task.Run(() => ConfigurationProvider.AddConfigurationReaderAsync(connectionStringsReader)));

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
