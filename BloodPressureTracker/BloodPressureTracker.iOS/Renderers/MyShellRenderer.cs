using System;
using BloodPressureTracker;
using BloodPressureTracker.iOS.Renderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppShell), typeof(MyShellRenderer))]
namespace BloodPressureTracker.iOS.Renderers
{
    public class MyShellRenderer : ShellRenderer
    {
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection) { var renderer = base.CreateShellSectionRenderer(shellSection); if (renderer != null) { } return renderer; }

        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new TabbarIconsAppearance();
        }
    }

    public class TabbarIconsAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void ResetAppearance(UITabBarController controller)
        {
            DisplayColorIcons(controller);
        }

        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            DisplayColorIcons(controller);
        }

        public void UpdateLayout(UITabBarController controller)
        {
            DisplayColorIcons(controller);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        private void DisplayColorIcons(UITabBarController controller)
        {            
            if (controller.TabBar.Items != null)
            {
                foreach (UITabBarItem tabbaritem in controller.TabBar.Items)
                {
                    tabbaritem.Image = ScalingImageToSize(tabbaritem.Image, new CGSize(30, 30));
                    tabbaritem.Image = tabbaritem.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    tabbaritem.SelectedImage = tabbaritem.SelectedImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);                   
                }
            }
        }

        public UIImage ScalingImageToSize(UIImage sourceImage, CGSize newSize)
        {

            if (UIScreen.MainScreen.Scale == 2.0) //@2x iPhone 6 7 8 
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 2.0f);
            }


            else if (UIScreen.MainScreen.Scale == 3.0) //@3x iPhone 6p 7p 8p...
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 3.0f);
            }

            else
            {
                UIGraphics.BeginImageContext(newSize);
            }

            sourceImage.Draw(new CGRect(0, 0, newSize.Width, newSize.Height));

            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();

            UIGraphics.EndImageContext();

            return newImage;

        }

    }
}

