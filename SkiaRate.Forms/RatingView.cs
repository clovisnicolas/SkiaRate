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

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(float), typeof(RatingView), default(float), propertyChanged: OnValueChanged);
        public static readonly BindableProperty PathProperty = BindableProperty.Create(nameof(Path), typeof(string), typeof(RatingView), PathConstants.Star, propertyChanged: OnValueChanged);
        public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int), typeof(RatingView), 5, propertyChanged: OnValueChanged);
        public static readonly BindableProperty OnColorProperty = BindableProperty.Create(nameof(OnColor), typeof(SKColor), typeof(RatingView), MaterialColors.Amber, propertyChanged: OnValueChanged);
        public static readonly BindableProperty OnOutlineColorProperty = BindableProperty.Create(nameof(OnOutlineColor), typeof(SKColor), typeof(RatingView), SKColors.Transparent, propertyChanged: OnValueChanged);
        public static readonly BindableProperty OffOutlineColorProperty = BindableProperty.Create(nameof(OffOutlineColor), typeof(SKColor), typeof(RatingView), MaterialColors.Grey, propertyChanged: OnValueChanged);
        public static readonly BindableProperty RatingTypeProperty = BindableProperty.Create(nameof(RatingType), typeof(RatingType), typeof(RatingView), RatingType.Floating, propertyChanged: OnValueChanged);

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

        public SKColor OnColor
        {
            get { return (SKColor)GetValue(OnColorProperty); }
            set{ SetValue(OnColorProperty, value);}
        }

        public SKColor OnOutlineColor
        {
            get { return (SKColor)GetValue(OnOutlineColorProperty); }
            set { SetValue(OnOutlineColorProperty, value); }
        }

        public SKColor OffOutlineColor
        {
            get { return (SKColor)GetValue(OffOutlineColorProperty); }
            set { SetValue(OffOutlineColorProperty, value); }
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

        private static void OnValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as RatingView;
            view.InvalidateSurface();
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(this.CanvasSize.Width * pt.X / this.Width),
                               (float)(this.CanvasSize.Height * pt.Y / this.Height));
        }

    }
}
