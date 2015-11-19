using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IBet.Domain.Core
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }

        public string InterestTitle { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

        public virtual ICollection<UserInterest> UserInterests { get; set; }
    }
}