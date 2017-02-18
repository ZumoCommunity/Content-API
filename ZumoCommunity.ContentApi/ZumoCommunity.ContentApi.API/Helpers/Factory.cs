using System.Threading.Tasks;

namespace ZumoCommunity.ContentAPI.API.Helpers
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