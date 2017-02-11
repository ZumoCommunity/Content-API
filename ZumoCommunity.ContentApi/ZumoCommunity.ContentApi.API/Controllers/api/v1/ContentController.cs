using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ZumoCommunity.ContentApi.API.Models;
using ZumoCommunity.ContentApi.Infrastructure.BlobStorage;
using ZumoCommunity.ContentApi.Infrastructure.CDN;
using ZumoCommunity.ContentApi.Storage.BlobStorage;
using ZumoCommunity.ContentApi.Storage.CDN;

namespace ZumoCommunity.ContentApi.API.Controllers.api.v1
{
    [RoutePrefix("api/content")]
    public class ContentController : ApiController
    {
        private readonly IFileService _fileService;
        private readonly ICdnService _cdnService;
        private readonly IContainerService _containerService;

        public ContentController()
        {
            _fileService = new FileService();
            _cdnService = new CdnService();
            _containerService = new ContainerService();
        }

        [HttpPost]
        [Route("upload")]
        public async Task<HttpResponseMessage> Upload(UploadFileRequestModel model)
        {
            HttpRequestMessage request = this.Request;

            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("download")]
        public async Task<HttpResponseMessage> Download(DownloadFileRequestModel model)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
