using System.Globalization;

namespace Prosper.Converters;

	public class AmountToColorConverter : IValueConverter
{
    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var isIncome = ((Label)parameter).Text;
        var amount = (decimal)value;
        if (isIncome.ToLower() == "true")
        {
            return Colors.DarkGreen;
        }
        else
        {
            return Colors.DarkRed;
        }
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

