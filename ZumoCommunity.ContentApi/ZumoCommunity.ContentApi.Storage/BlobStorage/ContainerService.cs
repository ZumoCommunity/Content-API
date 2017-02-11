using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZumoCommunity.ContentApi.Infrastructure.BlobStorage;

namespace ZumoCommunity.ContentApi.Storage.BlobStorage
{

    public class ContainerService : IContainerService
    {
        public Task CreateFolder(string containerName)
        {
            throw new NotImplementedException();
        }
    }
}
