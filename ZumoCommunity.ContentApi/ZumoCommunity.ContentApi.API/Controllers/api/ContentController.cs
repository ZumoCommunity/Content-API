
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Management;

namespace ZumoCommunity.ContentApi.API.Controllers.api
{
    [RoutePrefix("api/content")]
    public class ContentController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Test");
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Download(string url)
        {
            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Test");
        }
    }
}
