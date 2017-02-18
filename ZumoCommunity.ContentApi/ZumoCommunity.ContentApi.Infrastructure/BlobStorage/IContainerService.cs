using System.Threading.Tasks;

namespace ZumoCommunity.ContentAPI.Infrastructure.BlobStorage
{
    public interface IContainerService
    {
        Task CreateFolder(string containerName);
    }
}