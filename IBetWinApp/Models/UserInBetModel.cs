using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Models
{
    public class UserInBetModel
    {
        public string UserId { get; set; }

        public int BetId { get; set; }

        public int NewsId { get; set; }

        public bool IsWinner { get; set; }

        public BetModel Bet { get; set; }
    }
}
