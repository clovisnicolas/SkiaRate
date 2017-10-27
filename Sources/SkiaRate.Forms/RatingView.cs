using System;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using System.Diagnostics;
using SkiaSharp;

namespace SkiaRate
{
    public partial class RatingView : SKCanvasView
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

        #region BindableProperties

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(double), typeof(RatingView), default(double), propertyChanged: OnValueChanged);
        public static readonly BindableProperty PathProperty = BindableProperty.Create(nameof(Path), typeof(string), typeof(RatingView), PathConstants.Star, propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int), typeof(RatingView), 5, propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty ColorOnProperty = BindableProperty.Create(nameof(ColorOn), typeof(Color), typeof(RatingView), MaterialColors.Amber.ToFormsColor(), propertyChanged: ColorOnChanged);
        public static readonly BindableProperty OutlineOnColorProperty = BindableProperty.Create(nameof(OutlineOnColor), typeof(Color), typeof(RatingView), SKColors.Transparent.ToFormsColor(), propertyChanged: OutlineOnColorChanged);
        public static readonly BindableProperty OutlineOffColorProperty = BindableProperty.Create(nameof(OutlineOffColor), typeof(Color), typeof(RatingView), MaterialColors.Grey.ToFormsColor(), propertyChanged: OutlineOffColorChanged);
        public static readonly BindableProperty RatingTypeProperty = BindableProperty.Create(nameof(RatingType), typeof(RatingType), typeof(RatingView), RatingType.Floating, propertyChanged: OnPropertyChanged);

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
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

        public Color ColorOn
        {
            get { return (Color)GetValue(ColorOnProperty); }
            set { SetValue(ColorOnProperty, value); }
        }

        public Color OutlineOnColor
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


        private void Handle_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }

        protected override void OnTouch(SKTouchEventArgs e)
        {
            this.touchX = e.Location.X;
            this.touchY = e.Location.Y;
            this.SetValue(touchX, touchY);
            this.InvalidateSurface();
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var point = ConvertToPixel(new Point(e.TotalX, e.TotalY));
            if(e.StatusType != GestureStatus.Completed)
            {
                this.SetValue(touchX + point.X, touchY + e.TotalY);
                this.InvalidateSurface();
            }
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as RatingView;
            view.InvalidateSurface();
        }

        private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as RatingView;
            view.Value = view.ClampValue((double)newValue);
            OnPropertyChanged(bindable, oldValue, newValue);
        }

        private static void ColorOnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as RatingView;
            view.SKColorOn = ((Color)newValue).ToSKColor();
            OnPropertyChanged(bindable, oldValue, newValue);
        }

        private static void OutlineOffColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as RatingView;
            view.SKOutlineOffColor = ((Color)newValue).ToSKColor();
            OnPropertyChanged(bindable, oldValue, newValue);
        }

        private static void OutlineOnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as RatingView;
            view.SKOutlineOnColor = ((Color)newValue).ToSKColor();
            OnPropertyChanged(bindable, oldValue, newValue);
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(this.CanvasSize.Width * pt.X / this.Width),
                               (float)(this.CanvasSize.Height * pt.Y / this.Height));
        }

    }
}
