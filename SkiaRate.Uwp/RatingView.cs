using System;
using SkiaSharp.Views.UWP;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI;
using SkiaSharp;

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

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(double), typeof(RatingView), new PropertyMetadata(default(double), OnValueChanged));
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(nameof(Path), typeof(string), typeof(RatingView), new PropertyMetadata(PathConstants.Star, OnPropertyChanged));
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(int), typeof(RatingView), new PropertyMetadata(5, OnPropertyChanged));
        public static readonly DependencyProperty ColorOnProperty = DependencyProperty.Register(nameof(ColorOn), typeof(SKColor), typeof(RatingView), new PropertyMetadata(MaterialColors.Amber.ToColor(), ColorOnChanged));
        public static readonly DependencyProperty OutlineOnColorProperty = DependencyProperty.Register(nameof(OnOutlineColor), typeof(SKColor), typeof(RatingView), new PropertyMetadata(SKColors.Transparent, OutlineOnColorChanged));
        public static readonly DependencyProperty OutlineOffColorProperty = DependencyProperty.Register(nameof(OutlineOffColor), typeof(SKColor), typeof(RatingView), new PropertyMetadata(MaterialColors.Grey.ToColor(), OutlineOffColorChanged));
        public static readonly DependencyProperty RatingTypeProperty = DependencyProperty.Register(nameof(RatingType), typeof(RatingType), typeof(RatingView),new PropertyMetadata(RatingType.Floating, OnPropertyChanged));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
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

        public Color ColorOn
        {
            get { return (Color)GetValue(ColorOnProperty); }
            set { SetValue(ColorOnProperty, value); }
        }

        public Color OnOutlineColor
        {
            get { return (Color)GetValue(OutlineOnColorProperty); }
            set { SetValue(OutlineOnColorProperty, value); }
        }

        public Color OutlineOffColor
        {
            get { return (Color)GetValue(OutlineOffColorProperty); }
            set { SetValue(OutlineOffColorProperty, value); }
        }

        public RatingType RatingType
        {
            get { return (RatingType)GetValue(RatingTypeProperty); }
            set { SetValue(RatingTypeProperty, value); }
        }

        #endregion

        #region Methods

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RatingView).Invalidate();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as RatingView;
            view.Value = view.ClampValue((double)e.NewValue);
            OnPropertyChanged(d, e);
        }


        private static void ColorOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as RatingView;
            view.SKColorOn = ((Color)e.NewValue).ToSKColor();
            OnPropertyChanged(d, e);
        }

        private static void OutlineOnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as RatingView;
            view.SKOutlineOnColor = ((Color)e.NewValue).ToSKColor();
            OnPropertyChanged(d, e);
        }
        private static void OutlineOffColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as RatingView;
            view.SKOutlineOffColor = ((Color)e.NewValue).ToSKColor();
            OnPropertyChanged(d, e);
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
