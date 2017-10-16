using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace SkiaRate
{
    public class StarRating : Rating
    {
        public override void DrawRating(SKCanvas canvas, int width, int height)
        {
            float itemSize = CalculateItemSize(width,height);
            float radius = itemSize / 2;

            for(int i = 0; i < this.Count; i++)
            {
                SKPath path = new SKPath { FillType = SKPathFillType.Winding };
                SKPoint center = new SKPoint(radius + i * (itemSize + this.Spacing), height / 2);

                path.MoveTo(radius + i * (itemSize + this.Spacing), height / 2 - radius);
                for (int j = 1; j < 5; j++)
                {
                    double angle = j * 4 * Math.PI / 5;
                    path.LineTo(center + new SKPoint(radius * (float)Math.Sin(angle),
                                                    -radius * (float)Math.Cos(angle)));
                }
                path.Close();

                SKPaint strokePaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = this.OnColor,
                    StrokeWidth = 3,
                    StrokeJoin = SKStrokeJoin.Round
                };

                SKPaint fillPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = this.OnColor,
                };

                canvas.DrawPath(path, fillPaint);
                canvas.DrawPath(path, strokePaint);
            }
        }
    }
}
