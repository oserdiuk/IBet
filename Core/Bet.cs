using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Core
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserFirst")]
        public string UserFirstId { get; set; }

        [ForeignKey("UserSecond")]
        public string UserSecondId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double MoneySum { get; set; }

        [ForeignKey("Interest")]
        public int InterestId { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("Winner")]
        public string WinnerUserId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ApplicationUser UserFirst { get; set; }

        public virtual ApplicationUser UserSecond { get; set; }

        public virtual ApplicationUser Winner { get; set; }

        public virtual Interest Interest { get; set; }

        //TO-DO add private/public field

    }
}
