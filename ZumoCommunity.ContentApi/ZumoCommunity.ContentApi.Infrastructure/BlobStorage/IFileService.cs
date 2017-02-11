using System.IO;
using System.Threading.Tasks;

namespace ZumoCommunity.ContentApi.Infrastructure.BlobStorage
{
    public interface IFileService
    {
        Task UploadFile(string containerName, string blobName, Stream fileContent);

        Task<string> GetFileUploadUrl(string containerName, string blobName);

        Task<string> DownloadFileCdnUrl(string containerName, string blobName);
    }
}