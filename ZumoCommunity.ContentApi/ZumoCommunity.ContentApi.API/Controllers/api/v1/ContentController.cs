using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ZumoCommunity.ContentAPI.API.Helpers;
using ZumoCommunity.ContentAPI.API.Models;
using ZumoCommunity.ContentAPI.Infrastructure.BlobStorage;
using ZumoCommunity.ContentAPI.Infrastructure.CDN;
using ZumoCommunity.ContentAPI.Storage.BlobStorage;
using ZumoCommunity.ContentAPI.Storage.CDN;

namespace ZumoCommunity.ContentAPI.API.Controllers.api.v1
{
    [RoutePrefix("api/content")]
    public class ContentController : ApiController
    {
        private readonly IFileService _fileService;
        private readonly ICdnService _cdnService;
        private readonly IContainerService _containerService;

        public ContentController()
        {
            var task = Task.Run(Factory.GetStorageConnectionStringAsync);
            task.Wait();

            _fileService = new FileService(task.Result);
            _cdnService = new CdnService();
            _containerService = new ContainerService();
        }

        [HttpPost]
        [Route("upload")]
        public async Task<HttpResponseMessage> Upload([FromUri]DownloadFileRequestModel model)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var reqStream = Request.Content.ReadAsStreamAsync().Result;
            await _fileService.UploadFile(model.ContainerName.ToLower(), model.BlobName, reqStream);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("download")]
        public async Task<HttpResponseMessage> Download(DownloadFileRequestModel model)
        {
            var downloadUrl = await _fileService.DownloadFileCdnUrl(model.ContainerName, model.BlobName);

            return Request.CreateResponse(HttpStatusCode.OK, downloadUrl);
        }
    }
}
