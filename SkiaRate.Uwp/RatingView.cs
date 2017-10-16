using System;
using SkiaSharp.Views.UWP;
using Windows.UI.Xaml;
using SkiaRate;

namespace SkiaRate.Uwp
{
    public class RatingView : SKXamlCanvas
    {
        public RatingView()
        {
            this.PaintSurface += OnPaintCanvas;
        }

        public static readonly DependencyProperty RatingProperty = DependencyProperty.Register(nameof(Rating), typeof(RatingView), typeof(Rating), null);

        public Rating Rating
        {
            get { return (Rating)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        private void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Rating.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }
    }
}
