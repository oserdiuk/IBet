using Foolproof;
using IBet.Data.Repositories;
using IBet.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace IBetApp.Models
{
    public class CreateBetViewModel
    {
        [DisplayName("Your money: ")]
        public double UserMoneyLeft { get; set; }

        [DisplayName("Start date: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
//TODO fix date not editable
        [DisplayName("End of bet date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DisplayName("Money for this bet: ")]
        [GreaterThan("UserMoneyLeft", ErrorMessage = "You have not enough money.")]
        public double MoneySum { get; set; }

        [DisplayName("Interest: ")]
        public int InterestName { get; set; }

        [DisplayName("Description: ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public IEnumerable<UserInfoViewModel> Users { get; set; }
        public IEnumerable<UserInfoViewModel> UsersToPass { get; set; }
        public List<SelectListItem> Interests { get; set; }

        public CreateBetViewModel()
        {
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now.AddDays(7);
        }

        public void AddInterests(List<Interest> interests)
        {
            this.Interests = new List<SelectListItem>();
            foreach (var item in interests)
            {
                if (!Interests.Select(i => i.Text.ToLower()).Contains(item.InterestTitle.ToLower()))
                {
                    this.Interests.Add(new SelectListItem()
                    {
                        Text = item.InterestTitle,
                        Value = Convert.ToString(item.Id)
                    });
                }
            }
        }
    }
}
