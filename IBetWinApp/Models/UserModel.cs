using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

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

        public BitmapImage AvatarImage
        {
            get
            {
                string avatarURI = String.Format(@"http://localhost:54407/Content/Images/{0}", this.ImageName);
                return new BitmapImage(new Uri(avatarURI, UriKind.Absolute));
            }
        }

        /*
        xmlns:converters="using:IBetWinApp.Converters">
    <Page.Resources>
        <converters:StringFormatConverter x:Key="StringFormatConverter" />
    </Page.Resources>
        */
        public ICollection<UserInBetModel> UserInBets { get; set; }
        public ICollection<NewsModel> News { get; set; }
        public ICollection<FriendModel> Connections { get; set; }

    }
}
