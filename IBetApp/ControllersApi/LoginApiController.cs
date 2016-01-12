using IBet.Domain.Core;
using IBet.Infrastructure.Data;
using IBetApp.ModelsApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace IBetApp.ControllersApi
{
    public class LoginApiController : ApiController
    {
        // GET: api/Account
        UnitOfWork unitOfWork = new UnitOfWork();

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
            try
            {
                var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                var user = manager.UserManager.Find(viewModel.login, viewModel.password);
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(user, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
            }
            catch (Exception ex)
            {

                throw;
            }
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
