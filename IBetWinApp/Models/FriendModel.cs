using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Models
{
    public class FriendModel
    {
        public string UserId { get; set; }
        public string UserFriendId { get; set; }


        public UserModel User { get; set; }

        public UserModel UserFriend { get; set; }
    }
}
