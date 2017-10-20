using SkiaSharp.Views.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace SkiaRate.Droid
{
    public class RatingView : SKCanvasView
    {
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

        public override bool OnTouchEvent(MotionEvent e)
        {
            this.Rating.SetValue(e.GetX(), e.GetY());
            this.Invalidate();
            return true;
        }

        private Rating rating;

        public Rating Rating
        {
            get { return this.rating; }
            set
            {
                if(this.rating != value)
                {
                    this.rating = value;
                    this.Invalidate();
                }
            }
        }

        private void RatingView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            this.Rating?.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
        }

    }
}
