using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace ZumoCommunity.ContentApi.API
{
    public class AddFileParamTypes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId == "Content_Upload")
            {
                operation.consumes.Add("application/form-data");
                operation.parameters = new[]
                {
                    new Parameter
                    {
                        name = "FileContent",
                        required = true,
                        type = "file",
                    },
                    new Parameter
                    {
                        name = "BlobName",
                        required = true,
                        type = "string"
                    },
                    new Parameter
                    {
                        name = "Container",
                        required = true,
                        type = "string"
                    }
                };
            }
        }
    }
}