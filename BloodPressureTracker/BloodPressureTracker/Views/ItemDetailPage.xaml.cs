using System.ComponentModel;
using Xamarin.Forms;
using BloodPressureTracker.ViewModels;

namespace BloodPressureTracker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
