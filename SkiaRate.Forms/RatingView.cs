using System;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using System.Diagnostics;
using SkiaSharp;

namespace SkiaRate.Forms
{
    public class RatingView : SKCanvasView
    {
        public RatingView()
        {
            this.BackgroundColor = Color.Transparent;
            this.PaintSurface += Handle_PaintSurface;
            this.EnableTouchEvents = true;
        }

        public static readonly BindableProperty RatingProperty = BindableProperty.Create(nameof(Rating), typeof(Rating), typeof(RatingView), default(Rating));


        public Rating Rating
        {
            get { return (Rating)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        private void Handle_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Rating?.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }

        protected override void OnTouch(SKTouchEventArgs e)
        {
            this.Rating.SetValue(e.Location.X, e.Location.Y);
            this.InvalidateSurface();
        }
    }
}
