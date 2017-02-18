using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using ZumoCommunity.ContentAPI.Infrastructure.BlobStorage;

namespace ZumoCommunity.ContentAPI.Storage.BlobStorage
{
    public class FileService : IFileService
    {
        protected readonly CloudStorageAccount Account;
        protected readonly CloudBlobClient BlobClient;

        public FileService(string connectionString)
        {
            Account = CloudStorageAccount.Parse(connectionString);
            BlobClient = Account.CreateCloudBlobClient();
        }

        public async Task UploadFile(string containerName, string blobName, Stream fileContent)
        {
            var container = BlobClient.GetContainerReference(containerName);
            container.CreateIfNotExists();

            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            var blockBlob = container.GetBlockBlobReference(blobName);

            await blockBlob.UploadFromStreamAsync(fileContent);
        }

        public async Task<string> GetFileUploadUrl(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DownloadFileCdnUrl(string containerName, string blobName)
        {
            throw new NotImplementedException();
        }
    }
}
