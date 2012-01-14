using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace Soggiorni.Converters
{
    [ValueConversion(typeof(decimal), typeof(String))]
    public class DecimalConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //decimal currency = decimal.Parse(value.ToString());
            //return ((int)currency).ToString();
            decimal currency = (decimal)value;
            return (currency).ToString("N2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }


    }
}
