using System;
using System.Globalization;
using Xamarin.Forms;
using SkiaSharp;
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
            var count = float.Parse(parameter as string);
            var current = (float)value;
            var amount = current / count;
            return new SKColor(
                (byte)(MinColor.Red + amount * (MaxColor.Red - MinColor.Red)),
                (byte)(MinColor.Green + amount * (MaxColor.Green - MinColor.Green)),
                (byte)(MinColor.Blue + amount * (MaxColor.Blue - MinColor.Blue)),
                (byte)(MinColor.Alpha + amount * (MaxColor.Alpha - MinColor.Alpha)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
