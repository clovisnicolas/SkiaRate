using System;
using SkiaSharp.Views.UWP;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace SkiaRate
{
    public partial class RatingView : SKXamlCanvas
    {
        public RatingView()
        {
            this.PaintSurface += OnPaintCanvas;
            this.Tapped += RatingView_Tapped;
            this.ManipulationStarted += RatingView_ManipulationStarted;
            this.ManipulationDelta += RatingView_ManipulationDelta;
            this.ManipulationMode = ManipulationModes.TranslateX;
        }


        #region Bindable Properties

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(float), typeof(RatingView), new PropertyMetadata(default(float), OnValueChanged));
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(nameof(Path), typeof(string), typeof(RatingView), new PropertyMetadata(PathConstants.Star, OnValueChanged));
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(int), typeof(RatingView), new PropertyMetadata(5, OnValueChanged));

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, this.ClampValue(value)); }
        }

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        #endregion

        #region Methods

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RatingView).Invalidate();
        }

        private void RatingView_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            this.SetValue(e.Position.X + e.Delta.Translation.X, e.Position.Y + e.Delta.Translation.Y);
            this.Invalidate();
        }

        private void RatingView_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            this.SetValue(e.Position.X, e.Position.Y);
            this.Invalidate();
        }

        private void RatingView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var view = sender as UIElement;
            this.SetValue(e.GetPosition(view).X, e.GetPosition(view).Y);
            this.Invalidate();
        }

        private void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }

        #endregion  
    }
}
