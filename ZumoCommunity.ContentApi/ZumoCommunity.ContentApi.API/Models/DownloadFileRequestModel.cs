using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZumoCommunity.ContentApi.API.Models
{
    public class DownloadFileRequestModel
    {
        public string BlobName { get; set; }

        public string ContainerName { get; set; }
    }
}