using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBetApp.Models
{
    public class UserInfoViewModel
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

        public List<NewsInfoViewModel> News { get; set; }
    }

    public class UserSummaryViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string ImageName { get; set; }
    }

}
