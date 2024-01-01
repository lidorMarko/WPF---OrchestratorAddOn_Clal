using System;
using System.Globalization;
using System.Windows.Data;

namespace OrchestratorAddOn.Classes
{
    public class SubtractConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double originalHeight && double.TryParse(parameter as string, out double subtractValue))
            {
                return originalHeight - subtractValue;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
