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
    public class DiliveryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parametr = System.Convert.ToInt32(parameter);

            if (parametr==1)
            { 


            if (value != null)
            {
                var tt = System.Convert.ToInt32(value);

                if (tt==0) { return Visibility.Visible; }
                    else { return Visibility.Collapsed; }
                }
            }

            if (parametr == 2)
            {


                if (value != null)
                {
                    var tt = System.Convert.ToInt32(value);

                    if (tt == 0) { return Visibility.Collapsed; }
                    else { return Visibility.Visible; }
                }
            }




            return  Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
