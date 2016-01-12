using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface IBetBet
    {
        int Id { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }

        double MoneySum { get; set; }

        int InterestId { get; set; }

        string Description { get; set; }

        int StatusId { get; set; }

        bool IsDeleted { get; set; }

        IInterest Interest { get; set; }

        bool IsPublic { get; set; }
    }
}
