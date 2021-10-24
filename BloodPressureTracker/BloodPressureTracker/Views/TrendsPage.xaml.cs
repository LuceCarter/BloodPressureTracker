using System;
using System.Collections.Generic;
using BloodPressureTracker.ViewModels;
using Xamarin.Forms;

namespace BloodPressureTracker.Views
{
    public partial class TrendsPage : ContentPage
    {
        TrendsViewModel viewModel;
        public TrendsPage()
        {
            InitializeComponent();
            viewModel = new TrendsViewModel();            
        }       
    }
}
