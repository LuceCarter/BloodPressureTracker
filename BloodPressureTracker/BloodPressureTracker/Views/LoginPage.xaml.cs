using BloodPressureTracker.Controls;
using BloodPressureTracker.ViewModels;
using Xamarin.Forms;

namespace BloodPressureTracker.Views
{
    public partial class LoginPage : GradientContentPage
    {        
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
