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
        public float StrokeWidth { get; set; } = 1f;

        public string Path { get; set; }
        public int Count { get; set; } = 5;
        public RatingType RatingType { get; set; } = RatingType.Full;

        public void Draw(SKCanvas canvas, int width, int height)
        {
            canvas.Clear(this.BackgroundColor);

            var path = SKPath.ParseSvgPathData(this.Path);

            var itemsizeX = ((width - (this.Count - 1) * this.Spacing)) / this.Count;
            var scaleX = (itemsizeX / (path.Bounds.Width));
            scaleX = (itemsizeX - scaleX * this.StrokeWidth) / path.Bounds.Width;

            var scaleY = height / (path.Bounds.Height);
            scaleY = (height - scaleY * this.StrokeWidth) / (path.Bounds.Height);

            var scale = Math.Min(scaleX , scaleY);

            canvas.Scale(scale);
            canvas.Translate(this.StrokeWidth / 2, this.StrokeWidth / 2);
            canvas.Translate(-path.Bounds.Left, 0);
            canvas.Translate(0, -path.Bounds.Top);

            using (var strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = this.OnColor,
                StrokeWidth = this.StrokeWidth,
                StrokeJoin = SKStrokeJoin.Round,
                IsAntialias = true
            })
            using (var fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = this.OnColor,
                IsAntialias = true
            })
            {
                for (int i = 0; i < this.Count; i++)
                {
                    canvas.DrawPath(path, fillPaint);
                    canvas.DrawPath(path, strokePaint);
                    canvas.Translate((itemsizeX + this.Spacing) / scale, 0);
                }
            }
        }
    }
}
