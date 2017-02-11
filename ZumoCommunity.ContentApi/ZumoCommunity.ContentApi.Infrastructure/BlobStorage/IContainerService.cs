using System.Threading.Tasks;

namespace ZumoCommunity.ContentApi.Infrastructure.BlobStorage
{
    public interface IContainerService
    {
        Task CreateFolder(string containerName);
    }
}