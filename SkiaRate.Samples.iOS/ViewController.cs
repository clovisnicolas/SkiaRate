using System;
using UIKit;
using SkiaRate.iOS;
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

            view1.AddSubview(new RatingView() { Frame = view1.Bounds, Rating = Sample.StarRating });
            view2.AddSubview(new RatingView() { Frame = view2.Bounds, Rating = Sample.FavRating });
            view3.AddSubview(new RatingView() { Frame = view3.Bounds, Rating = Sample.CircleRating });
        }
    }
}
