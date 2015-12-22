using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IBetApp.Models
{
    public class AddingUserMoneyViewModel
    {
        public string UserId { get; set; }
        
        [DisplayName("Sum of money to add")]
        public double MoneyToAdd { get; set; }

        public AddingUserMoneyViewModel()
        {
            HttpContext.Current.User.Identity.GetUserId();
        }
    }
}
