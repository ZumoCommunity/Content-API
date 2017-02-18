using System.Threading.Tasks;

namespace ZumoCommunity.ContentApi.API.Helpers
{
	public static class Factory
	{
		public static async Task<string> GetStorageConnectionStringAsync()
		{
			var connectionString = await WebApiApplication.ConfigurationProvider.GetConfigValueAsync("ContentStorage");
		    return connectionString;
		}
	}
}