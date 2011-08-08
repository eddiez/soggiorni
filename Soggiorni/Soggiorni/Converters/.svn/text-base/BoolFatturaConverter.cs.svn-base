using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace Soggiorni.Converters
{
    [ValueConversion(typeof(bool), typeof(String))]
    public class BoolFatturaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isFattura = (bool)value;
            if (isFattura) return "Fattura";
            else return "Ricevuta Fiscale";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    }
}
