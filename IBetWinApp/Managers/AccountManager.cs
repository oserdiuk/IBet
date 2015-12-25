using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Managers
{
    public class AccountManager
    {
        public static async Task Login(string login, string pass)
        {
            string result = await ApiManager.ExecutePostRequest("api/accountapi",
                new Dictionary<string, string>
                {
                    ["login"] = login,
                    ["password"] = pass
                });
            int a = 5;
            //TODO: deserialize response
        }
    }
}
