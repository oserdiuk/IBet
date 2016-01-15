using IBetWinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Managers
{
    public class AccountManager
    {
        
        public static async Task<UserModel> Login(string login, string pass)
        {
            string result = await ApiManager.ExecutePostRequest("api/loginapi",
                new Dictionary<string, string>
                {
                    ["login"] = login,
                    ["password"] = pass
                });
            UserModel user = null;
            user = JsonUtil.DeserializeObject<UserModel>(result);
            return user;
        }
    }
}
