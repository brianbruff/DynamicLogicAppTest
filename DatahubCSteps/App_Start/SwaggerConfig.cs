using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using DatahubCSteps;
using Newtonsoft.Json.Linq;
using TRex.Metadata;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace DatahubCSteps
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {



                        c.SingleApiVersion("v1", "DatahubCSteps");



                        //c.OperationFilter<AddDefaultResponse>();
                        c.OperationFilter<ExtensionOperationFilter>();
                        //c.ReleaseTheTRex();


                    })
                        .EnableSwaggerUi(c =>
                            { });
        }
    }

    internal class ExtensionOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {

            //if (operation.description)
            if (operation.parameters != null)
            {
                // Select the capitalized parameter names
                var parameters = operation.parameters.FirstOrDefault(p => p.name == "xslParams");
                if (parameters == null) return;

                if (parameters.vendorExtensions == null)
                    parameters.vendorExtensions = new Dictionary<string, object>();

                var obj = JObject.Parse(Properties.Resources.Extension);

                //parameters.vendorExtensions.Add("x-ms-dynamic-schema", Properties.Resources.Extension.Replace("\\", "")); 
                parameters.vendorExtensions.Add("x-ms-dynamic-schema", obj);
            }
        }
    }
}