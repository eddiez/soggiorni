using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;

namespace Soggiorni.Converters
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateConverter:IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //DateTime date = DateTime.Parse(value.ToString());
            DateTime date = (DateTime)value;
            if (date == DateTime.MinValue) return "";
            return date.ToString(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
        

    }
}
