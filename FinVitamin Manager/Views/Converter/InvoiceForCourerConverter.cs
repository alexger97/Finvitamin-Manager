using FinVitamin_Manager.Models;
using System;
using System.Collections.Generic;

using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FinVitamin_Manager.Views.Converter
{
    class InvoiceForCourerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           bool invoiceEnding = (bool)(value);
           switch (System.Convert.ToInt32(parameter)){

           
                case 1:if (invoiceEnding) { return "Завершен"; } else return "В исполнении" ;
                case 2:if (invoiceEnding) { return new  SolidColorBrush(Color.FromRgb(0, 235, 70)); } else return new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
