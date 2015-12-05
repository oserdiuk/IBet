using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBet.Domain.Core
{
    public class UserInBet
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Bet")]
        public int BetId { get; set; }

        [ForeignKey("News")]
        public int NewsId { get; set; }

        public bool IsWinner { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Bet Bet { get; set; }
        public virtual News News { get; set; }

    }
}