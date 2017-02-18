using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Swashbuckle.Swagger;

namespace ZumoCommunity.ContentAPI.API
{
    public class AddFileParamTypes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId == "Content_Upload")
            {
                if (operation.parameters == null)
                    operation.parameters = new List<Parameter>();

                operation.consumes.Add("application/form-data");

                operation.parameters.Add(new Parameter
                    {
                        name = "file",
                        required = true,
                        type = "file",
                        @in = "form"
                    }
                );

                //operation.parameters.Add(new Parameter
                //{
                //    name = "blobName",
                //    required = true,
                //    type = "string"
                //});

                //operation.parameters.Add(new Parameter
                //{
                //    name = "containerName",
                //    required = true,
                //    type = "string"
                //});
            }
        }

        //var nonIFormFileProperties =
        //        parameters.Where(p =>
        //            !(iFormFilePropertyNames.Contains(p.Name)
        //           && string.Compare(p.In, "formData", StringComparison.OrdinalIgnoreCase) == 0))
        //           .ToImmutableArray();

        //parameters.Clear();
        //    foreach (var parameter in nonIFormFileProperties) parameters.Add(parameter);

        //public void Apply(Operation operation, OperationFilterContext context)
        //{
        //    if (operation.Parameters == null)
        //        return;

        //    var fileParamNames = context.ApiDescription.ActionDescriptor.Parameters
        //        .SelectMany(x => x.ParameterType.GetProperties())
        //        .Where(x => x.PropertyType.IsAssignableFrom(typeof(IFormFile)))
        //        .Select(x => x.Name)
        //        .ToList();

        //    if (!fileParamNames.Any())
        //        return;

        //    var paramsToRemove = new List<IParameter>();

        //    foreach (var param in operation.Parameters)
        //    {
        //        paramsToRemove.AddRange(from fileParamName in fileParamNames where param.Name.StartsWith(fileParamName + ".") select param);
        //    }

        //    paramsToRemove.ForEach(x => operation.Parameters.Remove(x));

        //    foreach (var paramName in fileParamNames)
        //    {
        //        var fileParam = new NonBodyParameter
        //        {
        //            Type = "file",
        //            Name = paramName,
        //            In = "formData"
        //        };
        //        operation.Parameters.Add(fileParam);
        //    }

        //    foreach (IParameter param in operation.Parameters)
        //    {
        //        param.In = "formData";
        //    }

        //    operation.Consumes = new List<string>() { "multipart/form-data" };
        //}
    }
}