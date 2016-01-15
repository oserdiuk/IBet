using IBetWinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Managers
{
    public class FriendsManager
    {
        
        public static async Task<List<UserModel>> GetCurrentUserFriends()
        {
            string result = await ApiManager.ExecuteGetRequest("api/friends",
                new Dictionary<string, string>
                {
                    ["userId"] = DataStoreManager.SharedManager.CurrentUser.Id
                });
            List<UserModel> friends = JsonUtil.DeserializeObject<List<UserModel>>(result);
            return friends;
        }
    }
}
