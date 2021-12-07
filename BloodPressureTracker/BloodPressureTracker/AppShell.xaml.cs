using System;
using System.Collections.Generic;
using BloodPressureTracker.ViewModels;
using BloodPressureTracker.Views;
using Xamarin.Forms;

namespace BloodPressureTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        LoginViewModel viewModel;
        public AppShell()
        {
            InitializeComponent();
            viewModel = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var isLoggedIn = viewModel.CheckIsLoggedIn();

            if(isLoggedIn)
            {
                Shell.Current.GoToAsync("///Main");
            }

            Shell.Current.GoToAsync("///Login");
        }
    }
}

