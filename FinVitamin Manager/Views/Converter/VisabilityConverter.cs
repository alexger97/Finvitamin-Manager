using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FinVitamin_Manager.Views.Converter
{
    public class VisabilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (parameter==null)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
           
            if(System.Convert.ToInt32(parameter)==1)
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
