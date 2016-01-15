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
    public class FriendsController : ApiController
    {
        // GET: api/Account
        UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        public object Get(string userId)
        {
            var manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var friendsIds = unitOfWork.FriendsRepository.GetAll().ToList();
            var friends = friendsIds.Where(f => f.UserId == userId);
            var users = friends.Select(f => f.UserFriend);
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(users, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
        }

        // POST: api/Account
        public void Post([FromBody]LogInViewModel viewModel)
        {
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
