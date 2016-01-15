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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IBetWinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendsPage : Page
    {
        public FriendsPage()
        {
            this.InitializeComponent();
            this.Loaded += FriendsPage_Loaded;
        }

        private async void FriendsPage_Loaded(object sender, RoutedEventArgs e)
        {
            var userFriends = await FriendsManager.GetCurrentUserFriends();
            this.friendsListView.ItemsSource = userFriends;
        }

        private void MyBetsButton_Click(object sender, RoutedEventArgs e)
        {
            UserModel user = DataStoreManager.SharedManager.CurrentUser;
            List<BetModel> bets = user.UserInBets.Select(u => u.Bet).ToList<BetModel>();
            this.Frame.Navigate(typeof(BetsPage), bets);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void UserProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewsPage));
        }
    }
}
