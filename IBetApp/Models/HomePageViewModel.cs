using IBet.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetApp.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<TopUserViewModel> Users { get; set; }
        public IEnumerable<NewBetsViewModel> Bets { get; set; }

    }
    public class TopUserViewModel
    {
        public string UserName { get; set; }
        public string PictureName { get; set; }
        public int NumberOfVictories { get; set; }
    }

    public class NewBetsViewModel
    {
        public string BetInterest { get; set; }
        public DateTime Time { get; set; }
        public int Money { get; set; }
    }
}
