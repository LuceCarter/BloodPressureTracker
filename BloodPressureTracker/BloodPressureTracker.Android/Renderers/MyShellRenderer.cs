using System;
using Android.Content;
using BloodPressureTracker;
using BloodPressureTracker.Droid.Renderers;
using Google.Android.Material.BottomNavigation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AppShell), typeof(MyShellRenderer))]
namespace BloodPressureTracker.Droid.Renderers
{
    public class MyShellRenderer : ShellRenderer
    {
        public MyShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomBottomNavAppearanceTracker(this);
        }

        internal class CustomBottomNavAppearanceTracker : IShellBottomNavViewAppearanceTracker
        {

            private MyShellRenderer myShellRenderer = null;

            public CustomBottomNavAppearanceTracker(MyShellRenderer myShellRenderer)
            {
                this.myShellRenderer = myShellRenderer;
            }

            public void Dispose()
            {
                //throw new System.NotImplementedException();
            }

            public void ResetAppearance(BottomNavigationView bottomView)
            {
                bottomView.ItemIconTintList = null;
            }

            public void SetAppearance(BottomNavigationView bottomView, ShellAppearance appearance)
            {
                bottomView.ItemIconTintList = null;
            }

            public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
            {
                bottomView.ItemIconTintList = null;                
            }
        }
    }
}
