using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface IUserInBet
    {
        string UserId { get; set; }

        int BetId { get; set; }

        int NewsId { get; set; }

        bool IsWinner { get; set; }

        IUser User { get; set; }
        IBetBet Bet { get; set; }
        INews News { get; set; }
    }
}
