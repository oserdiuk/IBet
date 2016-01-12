using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface IInterest
    {
        int Id { get; set; }

         string InterestTitle { get; set; }

         bool IsDeleted { get; set; }

         ICollection<IBetBet> Bets { get; set; }

         ICollection<IUserInterest> UserInterests { get; set; }
    }
}
