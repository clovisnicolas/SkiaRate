using System;
using UIKit;
using SkiaSharp;
using SkiaSharp.Views.iOS;

namespace SkiaRate.Samples.iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            view1.AddSubview(new RatingView() { Frame = view1.Bounds, Value = 4 });
            view2.AddSubview(new RatingView() { Frame = view2.Bounds, Path = PathConstants.Heart, ColorOn = MaterialColors.Red.ToUIColor()});
            view3.AddSubview(new RatingView() { Frame = view3.Bounds, Path = PathConstants.Like, Count = 1, ColorOn = MaterialColors.LightBlue.ToUIColor() });
        }
    }
}
