using SkiaSharp.Views.Android;
using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

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

        private float value = 0;
        private string path = PathConstants.Star;
        private int count = 5;

        #endregion

        #region properties

        public float Value
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
