using IBetWinApp.Managers;
using IBetWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class BetsPage : Page
    {
        private List<BetModel> bets;
        public BetsPage()
        {
            this.InitializeComponent();
            this.Loaded += BetsPage_Loaded;
        }

        private void BetsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.bets = (List<BetModel>)e.Parameter;
            this.betsListView.ItemsSource = this.bets;
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

        private void myFriendsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FriendsPage));
        }

        private void userProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewsPage));
        }
    }
}
