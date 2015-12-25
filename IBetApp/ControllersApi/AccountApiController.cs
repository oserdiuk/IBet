using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IBetApp.ControllersApi
{

    public class LogInViewModel
    {
        public string login { get; set; }
        public string password { get; set; }
    }
    public class AccountApiController : ApiController
    {
        // GET: api/Account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        public object Post([FromBody]LogInViewModel viewModel)
        {
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(true));
        }



        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
