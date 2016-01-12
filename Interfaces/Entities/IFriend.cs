using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface IFriend
    {
        string UserId { get; set; }

        string UserFriendId { get; set; }

        bool IsDeleted { get; set; }

        IUser User { get; set; }

        IUser UserFriend { get; set; }
    }
}
