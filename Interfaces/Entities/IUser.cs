using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBet.Domain.Interfaces.Entities
{
    public interface IUser
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        int Age { get; set; }

        string City { get; set; }

        string Country { get; set; }

        DateTime RegisterDate { get; set; }

        double MoneyLeft { get; set; }

        bool IsDeleted { get; set; }

        string ImageName { get; set; }

        string Description { get; set; }

        ICollection<IUserInBet> UserInBets { get; set; }

        ICollection<IFriend> Connections { get; set; }

        ICollection<IUserInterest> UserInterests { get; set; }

        ICollection<INews> News { get; set; }
    }
}
