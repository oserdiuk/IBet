using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetWinApp.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double MoneyLeft { get; set; }
        public string ImageName { get; set; }

        public ICollection<UserInBetModel> UserInBets { get; set; }
        public ICollection<NewsModel> News { get; set; }
    }
}
