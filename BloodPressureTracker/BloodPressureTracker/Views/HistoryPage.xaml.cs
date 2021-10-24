using System;
using System.Collections.Generic;
using BloodPressureTracker.ViewModels;
using Xamarin.Forms;

namespace BloodPressureTracker.Views
{
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;
        public HistoryPage()
        {
            InitializeComponent();
            viewModel = new HistoryViewModel();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.InitialiseRealm();
        }
    }
}
