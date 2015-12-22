using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetApp.Models
{
    public class BetInfoViewModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double MoneySum { get; set; }

        public string InterestName { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public bool IsPublic { get; set; }
    }
}
