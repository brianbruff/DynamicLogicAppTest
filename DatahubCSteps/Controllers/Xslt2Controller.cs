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
        public IActionResult GetParams([FromRoute]string xsl)
        {
            string exampleJson = Properties.Resources.Example;

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Columns>(exampleJson)
            : default(Columns);
            return new ObjectResult(example);
        }

        

        


    }
}
