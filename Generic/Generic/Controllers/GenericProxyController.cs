using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericProxyController : ControllerBase
    {
        [Route("{fsn}/{passcontroller/{r1?}/{r2?}/{r3?}/{r4?}/{r5?}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(string fsn, string passcontroller = "", string r1 = "", string r2="", string r3="", string r4="", string r5 = "")
        {
            return await RestAPIPassThroughHelper(fsn).ConfigureAwait(false);
        }

        private async Task<HttpResponseMessage> RestAPIPassThroughHelper(string fsn)
        {
            Task<HttpResponseMessage> responseTask = null;
            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // Loop throught request headers and add to httpClient.DefaultRequestHeaders
                string _url = string.Empty;// Form Rest URL
                if(Request.Method.Equals(HttpMethod.Get))
                {
                    responseTask = httpClient.GetAsync(_url);
                }

                if (Request.Method.Equals(HttpMethod.Post))
                {
                    // responseTask = httpClient.PostAsync(_url, Request.Content);
                }
            }
            return response;
        }
    }
    }
}