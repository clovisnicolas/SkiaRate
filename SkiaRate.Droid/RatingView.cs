using SkiaSharp.Views.Android;
using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using SkiaSharp;
using Android.Graphics;

namespace SkiaRate
{
    public partial class RatingView : SKCanvasView
    {

        #region constructors
        public RatingView(Context context) : base(context)
        {
            this.PaintSurface += RatingView_PaintSurface;
        }

        public RatingView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            this.PaintSurface += RatingView_PaintSurface;
        }

        public RatingView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            this.PaintSurface += RatingView_PaintSurface;
        }

        protected RatingView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            this.PaintSurface += RatingView_PaintSurface;
        }

        #endregion

        #region fields

        private double value = 0;
        private string path = PathConstants.Star;
        private int count = 5;
        private RatingType ratingType = RatingType.Floating;

        #endregion

        #region properties

        public double Value
        {
            get { return this.value; }
            set
            {
                if (value != this.value)
                {
                    this.value = this.ClampValue(value);
                    this.Invalidate();
                }
            }
        }

        public string Path
        {
            get { return this.path; }
            set
            {
                if (value != this.path)
                {
                    this.path = value;
                    this.Invalidate();
                }
            }
        }
        public int Count
        {
            get { return this.count; }
            set
            {
                if (value != this.count)
                {
                    this.count = value;
                    this.Invalidate();
                }
            }
        }

        public Color ColorOn
        {
            get { return this.SKColorOn.ToColor(); }
            set
            {
                if (value.ToSKColor() != this.SKColorOn)
                {
                    this.SKColorOn = value.ToSKColor();
                    this.Invalidate();
                }
            }
        }

        public Color OutlineOnColor
        {
            get { return this.SKOutlineOnColor.ToColor(); }
            set
            {
                if (value.ToSKColor() != this.SKOutlineOnColor)
                {
                    this.SKOutlineOnColor = value.ToSKColor();
                    this.Invalidate();
                }
            }
        }

        public Color OutlineOffColor
        {
            get { return this.SKOutlineOffColor.ToColor(); }
            set
            {
                if (value.ToSKColor() != this.SKOutlineOffColor)
                {
                    this.SKOutlineOffColor = value.ToSKColor();
                    this.Invalidate();
                }
            }
        }

        public RatingType RatingType
        {
            get { return this.ratingType; }
            set
            {
                if (value != this.ratingType)
                {
                    this.ratingType = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region methods

        public override bool OnTouchEvent(MotionEvent e)
        {
            this.SetValue(e.GetX(), e.GetY());
            this.Invalidate();
            return true;
        }

        private void RatingView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }

        #endregion

    }
}
