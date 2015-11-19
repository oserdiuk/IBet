using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBet.Domain.Core
{
    public class Friend
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("UserFriend")]
        public string UserFriendId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ApplicationUser UserFriend { get; set; }

    }
}