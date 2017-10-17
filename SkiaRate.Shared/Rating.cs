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
        public SKColor OffOutlineColor { get; set; } = SKColors.Black;

        public string Path { get; set; }
        public int Count { get; set; } = 5;
        public RatingType RatingType { get; set; } = RatingType.Full;

        public void Draw(SKCanvas canvas, int width, int height)
        {
            canvas.Clear(this.BackgroundColor);
            var itemsize = CalculateItemSize(width, height);
            var path = SKPath.ParseSvgPathData(this.Path);
            var scale = itemsize / path.Bounds.Width;
            canvas.Scale(scale);

            using (var strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = this.OnColor,
                StrokeWidth = 1,
                StrokeJoin = SKStrokeJoin.Round
            })
            using (var fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = this.OnColor,
            })
            {
                for (int i = 0; i < this.Count; i++)
                {
                    canvas.DrawPath(path, fillPaint);
                    canvas.DrawPath(path, strokePaint);
                    canvas.Translate((itemsize + this.Spacing) / scale, 0);
                }
            }
        }
        protected float CalculateItemSize(int width, int height)
        {
            return Math.Min(height, (width - (this.Count * this.Spacing)) / this.Count);
        }
    }
}
