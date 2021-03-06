using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BloodPressureTracker.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
