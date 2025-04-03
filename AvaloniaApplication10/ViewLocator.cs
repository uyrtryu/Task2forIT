using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace AvaloniaApplication10
{
    public class ObjectToBoolConverter : IValueConverter
    {
        public static readonly ObjectToBoolConverter Instance = new();

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}