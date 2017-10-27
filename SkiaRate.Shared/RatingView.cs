using SkiaSharp;
using System;

namespace SkiaRate
{
    public partial class RatingView
    {
        #region properties
        /// <summary>
        /// Gets or sets the spacing between two rating elements
        /// </summary>
        public float Spacing { get; set; } = 8;

        /// <summary>
        /// Gets or sets the color of the canvas background.
        /// </summary>
        /// <value>The color of the canvas background.</value>
        public SKColor CanvasBackgroundColor { get; set; } = SKColors.Transparent;

        /// <summary>
        /// Gets or sets the width of the stroke.
        /// </summary>
        /// <value>The width of the stroke.</value>
		public float StrokeWidth { get; set; } = 0.1f;

        #endregion

        #region public methods

        /// <summary>
        /// Clamps the value between 0 and the number of items.
        /// </summary>
        /// <returns>The value.</returns>
        /// <param name="val">Value.</param>
        public double ClampValue(double val)
        {
            if (val < 0)
                return 0;
            else if (val > this.Count)
                return this.Count;
            else
                return val;
        }

        /// <summary>
        /// Sets the Rating value
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetValue(double x, double y)
        {
            var val = this.CalculateValue(x);
            switch (this.RatingType)
            {
                case RatingType.Full:
                    this.Value = ClampValue((double)Math.Ceiling(val));
                    break;
                case RatingType.Half:
                    this.Value = ClampValue((double)Math.Round(val * 2)/2);
                    break;
                case RatingType.Floating:
                    this.Value = ClampValue(val);
                    break;
            }
        }

        /// <summary>
        /// Draws the rating view
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Draw(SKCanvas canvas, int width, int height)
        {
            canvas.Clear(this.CanvasBackgroundColor);
           
            var path = SKPath.ParseSvgPathData(this.Path);

            var itemWidth = ((width - (this.Count - 1) * this.Spacing)) / this.Count;
            var scaleX = (itemWidth / (path.Bounds.Width));
            scaleX = (itemWidth - scaleX * this.StrokeWidth) / path.Bounds.Width;

            this.ItemHeight = height;
            var scaleY = this.ItemHeight / (path.Bounds.Height);
            scaleY = (this.ItemHeight - scaleY * this.StrokeWidth) / (path.Bounds.Height);

            this.CanvasScale = Math.Min(scaleX , scaleY);
            this.ItemWidth = path.Bounds.Width * this.CanvasScale;

            canvas.Scale(this.CanvasScale);
            canvas.Translate(this.StrokeWidth / 2, this.StrokeWidth / 2);
            canvas.Translate(-path.Bounds.Left, 0);
            canvas.Translate(0, -path.Bounds.Top);

            using (var strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = this.SKOutlineOnColor,
                StrokeWidth = this.StrokeWidth,
                StrokeJoin = SKStrokeJoin.Round,
                IsAntialias = true,
            })
            using (var fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = this.SKColorOn,
                IsAntialias = true,
            })
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (i <= this.Value - 1) // Full
                    {
                        canvas.DrawPath(path, fillPaint);
                        canvas.DrawPath(path, strokePaint);
                    }
                    else if (i < this.Value) //Partial
                    {
                        float filledPercentage = (float)(this.Value - Math.Truncate(this.Value));
                        strokePaint.Color = this.SKOutlineOffColor;
                        canvas.DrawPath(path, strokePaint);

                        using (var rectPath = new SKPath())
                        {
                            var rect = SKRect.Create(path.Bounds.Left + path.Bounds.Width * filledPercentage, path.Bounds.Top, path.Bounds.Width * (1 - filledPercentage), this.ItemHeight);
                            rectPath.AddRect(rect);
                            canvas.ClipPath(rectPath, SKClipOperation.Difference);
                            canvas.DrawPath(path, fillPaint);
                        }
                    }
                    else //Empty
                    {
                        strokePaint.Color = this.SKOutlineOffColor;
                        canvas.DrawPath(path, strokePaint);
                    }

                    canvas.Translate((this.ItemWidth + this.Spacing) / this.CanvasScale, 0);
                }
            }

        }

        #endregion

        #region private

        private float ItemWidth { get; set; }
        private float ItemHeight { get; set; }
        private float CanvasScale { get; set; }
        private SKColor SKColorOn { get; set; } = MaterialColors.Amber;
        private SKColor SKOutlineOnColor { get; set; } = SKColors.Transparent;
        private SKColor SKOutlineOffColor { get; set; } = MaterialColors.Grey;

        private double CalculateValue(double x)
        {
            if (x < this.ItemWidth)
                return (double)x / this.ItemWidth;
            else if (x < this.ItemWidth + this.Spacing)
                return 1;
            else
                return 1 + CalculateValue(x - (this.ItemWidth + this.Spacing));
        }

        #endregion
    }
}
