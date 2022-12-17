using SistemaAPP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace SistemaAPP
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new Xamarin.Forms.NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
