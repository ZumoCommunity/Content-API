using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZumoCommunity.ContentApi.API.Models
{
    public class UploadFileRequestModel
    {
        public string BlobName { get; set; }   

        public string Container { get; set; }

        public byte[] FileContent { get; set; }
    }
}