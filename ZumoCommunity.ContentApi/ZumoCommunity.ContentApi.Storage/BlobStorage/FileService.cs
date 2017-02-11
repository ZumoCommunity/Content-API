using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZumoCommunity.ContentApi.Infrastructure.BlobStorage;

namespace ZumoCommunity.ContentApi.Storage.BlobStorage
{
    public class FileService : IFileService
    {
        public Task UploadFile(string containerName, string blobName, Stream fileContent)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFileUploadUrl(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<string> DownloadFileCdnUrl(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }
    }
}
