using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ZumoCommunity.ContentAPI.API.Models
{
    public class UploadFileRequestModel
    {
        public string BlobName { get; set; }   

        public string Container { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}