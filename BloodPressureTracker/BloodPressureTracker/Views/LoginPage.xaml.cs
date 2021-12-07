using Xamarin.Forms;

namespace BloodPressureTracker.Views
{
    public partial class LoginPage : ContentPage
    {        
        public LoginPage()
        {
            InitializeComponent();            
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
