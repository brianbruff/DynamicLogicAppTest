using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using DatahubCSteps.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger.Annotations;
using TRex.Metadata;

namespace DatahubCSteps.Controllers
{
    public class Xslt2Controller : ApiController
    {

        //// GET api/values/5
        [System.Web.Http.HttpPost]
        [SwaggerOperation("TransformToGDMX")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public string Post(string input, string xsl, [System.Web.Http.FromBody]Payload xslParams)
        {
            return "value";
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetParams/{xsl}")]
        [SwaggerOperation("GetParams")]
        [SwaggerResponse(200, type: typeof(Columns))]
        public Columns GetParams([FromRoute]string xsl)
        {
            var exampleJson = Properties.Resources.Example;


            var example = JsonConvert.DeserializeObject<Columns>(exampleJson);
            return example;
        }

        

        


    }
}
