using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkiaRate
{
    public class Rating
    {

        /// <summary>
        /// Gets or sets the spacing between two rating elements
        /// </summary>
        public float Spacing { get; set; } = 8;
        public SKColor BackgroundColor { get; set; } = SKColors.Transparent;
        public SKColor OnColor { get; set; } = SKColors.Gold;
        public SKColor OnOutlineColor { get; set; } = SKColors.Transparent;
        public SKColor OffColor { get; set; } = SKColors.Transparent;
        public SKColor OffOutlineColor { get; set; } = SKColors.LightGray;
        public float StrokeWidth { get; set; } = 0.1f;
        public string Path { get; set; }
        public int Count { get; set; } = 5;
        public RatingType RatingType { get; set; } = RatingType.Full;
        public float Value { get; set; }

        public void SetValue(double x, double y)
        {
            this.Value = (float)x / (this.ItemWidth);
        }

        private float ItemWidth { get; set; }
        private float ItemHeight { get; set; }

        public void Draw(SKCanvas canvas, int width, int height)
        {
            canvas.Clear(this.BackgroundColor);
           
            var path = SKPath.ParseSvgPathData(this.Path);

            this.ItemWidth = ((width - (this.Count - 1) * this.Spacing)) / this.Count;
            var scaleX = (this.ItemWidth / (path.Bounds.Width));
            scaleX = (this.ItemWidth - scaleX * this.StrokeWidth) / path.Bounds.Width;

            this.ItemHeight = height;
            var scaleY = this.ItemHeight / (path.Bounds.Height);
            scaleY = (this.ItemHeight - scaleY * this.StrokeWidth) / (path.Bounds.Height);

            var scale = Math.Min(scaleX , scaleY);

            canvas.Scale(scale);
            canvas.Translate(this.StrokeWidth / 2, this.StrokeWidth / 2);
            canvas.Translate(-path.Bounds.Left, 0);
            canvas.Translate(0, -path.Bounds.Top);

            using (var strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = this.OnOutlineColor,
                StrokeWidth = this.StrokeWidth,
                StrokeJoin = SKStrokeJoin.Round,
                IsAntialias = true,
            })
            using (var fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = this.OnColor,
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
                        strokePaint.Color = this.OffOutlineColor;
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
                        strokePaint.Color = this.OffOutlineColor;
                        canvas.DrawPath(path, strokePaint);
                    }

                    canvas.Translate((this.ItemWidth + this.Spacing) / scale, 0);
                }
            }
        }
    }
}
