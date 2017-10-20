using System;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;
using System.Linq;
using CoreGraphics;
using Foundation;
namespace SkiaRate.iOS
{
    public class RatingView : SKCanvasView
    {
        public RatingView()
        {
            this.BackgroundColor = UIColor.Clear;
            this.PaintSurface += Handle_PaintSurface;
        }

        private nfloat scale = UIScreen.MainScreen.Scale;
        private Rating rating;

        public Rating Rating
        {
            get { return this.rating; }
            set
            {
                if (this.rating != value)
                {
                    this.rating = value;
                    this.SetNeedsDisplayInRect(this.Bounds);
                }
            }
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            this.HandleTouches(touches, evt);
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            this.HandleTouches(touches, evt);
        }

        private void HandleTouches(NSSet touches, UIEvent evt)
        {
            var touch = touches.FirstOrDefault() as UITouch;
            CGPoint point = touch.LocationInView(this);

            this.Rating.SetValue(point.X * this.scale, point.Y * this.scale);
            this.SetNeedsDisplayInRect(this.Bounds);
        }

        private void Handle_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Rating?.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }
    }
}
