using System;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using System.Diagnostics;
using SkiaSharp;

namespace SkiaRate.Forms
{
    public class RatingView : SKCanvasView
    {
        private PanGestureRecognizer panGestureRecognizer = new PanGestureRecognizer();
        private double touchX;
        private double touchY;

        public RatingView()
        {
            this.BackgroundColor = Color.Transparent;
            this.PaintSurface += Handle_PaintSurface;
            this.EnableTouchEvents = true;
            this.panGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
            this.GestureRecognizers.Add(panGestureRecognizer);
        }

        public static readonly BindableProperty RatingProperty = BindableProperty.Create(nameof(Rating), typeof(Rating), typeof(RatingView), default(Rating));


        public Rating Rating
        {
            get { return (Rating)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }
        protected override void OnTouch(SKTouchEventArgs e)
        {
            this.touchX = e.Location.X;
            this.touchY = e.Location.Y;
            this.Rating.SetValue(touchX, touchY);
            this.InvalidateSurface();
        }
        private void Handle_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Rating?.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }
        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var point = ConvertToPixel(new Point(e.TotalX, e.TotalY));
            if(e.StatusType != GestureStatus.Completed)
            {
                this.Rating.SetValue(touchX + point.X, touchY + e.TotalY);
                this.InvalidateSurface();
            }
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(this.CanvasSize.Width * pt.X / this.Width),
                               (float)(this.CanvasSize.Height * pt.Y / this.Height));
        }

    }
}
