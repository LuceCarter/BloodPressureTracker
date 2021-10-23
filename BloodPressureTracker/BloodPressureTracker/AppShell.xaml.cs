using System;
using System.Collections.Generic;
using BloodPressureTracker.ViewModels;
using BloodPressureTracker.Views;
using Xamarin.Forms;

namespace BloodPressureTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

