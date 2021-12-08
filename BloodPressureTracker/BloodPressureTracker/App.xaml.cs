using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BloodPressureTracker.Helpers;


using BloodPressureTracker.Views;

namespace BloodPressureTracker
{
    public partial class App : Application
    {
        public static Realms.Sync.App RealmApp;
        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            RealmApp = Realms.Sync.App.Create(AppSecrets.RealmAppId);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

