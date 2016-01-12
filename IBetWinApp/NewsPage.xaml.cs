using IBetWinApp.Managers;
using IBetWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IBetWinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsPage : Page
    {
        private List<NewsModel> news;
        public NewsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.news = (List<NewsModel>)e.Parameter;
            this.newsListView.ItemsSource = this.news;

            UserModel user = DataStoreManager.SharedManager.CurrentUser;
            this.userNameTb.Text = user.UserName;
            string userAvatarSource = String.Format(@"http://localhost:54407/Content/Images/{0}", user.ImageName);
            this.userAvatar.Source = new BitmapImage(new Uri(userAvatarSource, UriKind.Absolute));
        }

        private void MyBetsButton_Click(object sender, RoutedEventArgs e)
        {
            UserModel user = DataStoreManager.SharedManager.CurrentUser;
            List<BetModel> bets = user.UserInBets.Select(u => u.Bet).ToList<BetModel>();
            this.Frame.Navigate(typeof(BetsPage), bets);
        }
    }
}
