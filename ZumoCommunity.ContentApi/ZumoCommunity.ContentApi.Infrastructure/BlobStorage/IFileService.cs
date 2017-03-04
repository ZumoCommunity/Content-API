using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ZumoCommunity.ContentAPI.Infrastructure.BlobStorage
{
    public interface IFileService
    {
        Task UploadFile(string containerName, string blobName, Stream fileContent);
        
        Task<string> DownloadFileUrl(string containerName, string blobName);

        Dictionary<string, string> DownloadFilesUrls(string containerName);
    }
}