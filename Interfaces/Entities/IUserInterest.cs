using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface IUserInterest
    {
        string UserId { get; set; }

        int InterestId { get; set; }

        bool IsDeleted { get; set; }

        IUser User { get; set; }

        IInterest Interest { get; set; }
    }
}
