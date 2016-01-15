using IBetWinApp.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using IBetWinApp.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IBetWinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //this.loginTB.Text = "o_serdyuk@hotmail.com";
           // this.passTB.Text = "Qwerty_123";
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserModel signedInUser = await AccountManager.Login(this.loginTB.Text, this.passTB.Password);
                string displayMessage;
                if (signedInUser != null)
                {
                    displayMessage = "Successfully logged in";
                }
                else
                {
                    displayMessage = "Log In failed";
                }

                DataStoreManager.SharedManager.CurrentUser = signedInUser;
                //var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                //localSettings.Values["curUser"] = signedInUser;

                await new MessageDialog(displayMessage).ShowAsync();
                if (signedInUser != null )
                {
                    this.Frame.Navigate(typeof(NewsPage), signedInUser.News);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
