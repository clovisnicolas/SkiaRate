using System;
using System.Globalization;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
namespace SkiaRate.Samples.Forms
{
    public class ValueToColorConverter : IValueConverter
    {
        public ValueToColorConverter()
        {
        }

        public SKColor MinColor { get; set; } = MaterialColors.Red;
        public SKColor MaxColor { get; set; } = MaterialColors.LightBlue;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = int.Parse(parameter as string);
            var current = (double)value;
            var amount = current / count;
            return new SKColor(
                (byte)(MinColor.Red + amount * (MaxColor.Red - MinColor.Red)),
                (byte)(MinColor.Green + amount * (MaxColor.Green - MinColor.Green)),
                (byte)(MinColor.Blue + amount * (MaxColor.Blue - MinColor.Blue)),
                (byte)(MinColor.Alpha + amount * (MaxColor.Alpha - MinColor.Alpha))).ToFormsColor();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValueToMoviesColorConverter : IValueConverter
    {
        public ValueToMoviesColorConverter()
        {
        }

        public SKColor MinColor { get; set; } = MaterialColors.Lime;
        public SKColor MaxColor { get; set; } = MaterialColors.DeepOrange;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var count = int.Parse(parameter as string); 
            var current = (double)value;
            var amount = current / count;
            return new SKColor(
                (byte)(MinColor.Red + amount * (MaxColor.Red - MinColor.Red)),
                (byte)(MinColor.Green + amount * (MaxColor.Green - MinColor.Green)),
                (byte)(MinColor.Blue + amount * (MaxColor.Blue - MinColor.Blue)),
                (byte)(MinColor.Alpha + amount * (MaxColor.Alpha - MinColor.Alpha))).ToFormsColor();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
