using System;
using System.Globalization;

namespace Prosper.Converters;

public class AmountToCurencyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var isIncome = ((Label)parameter).Text;
        var amount = (decimal)value;
        if (isIncome.ToLower() == "true")
        {
            return $"+{amount:C}";
        }
        else
        {
            return $"-{amount:C}";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

