using FinVitamin_Manager.Models.Enums;
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
    public class PaymentStatusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if ((PaymentStatus)value== PaymentStatus.Invoiced)
            {
                return "Выставлен счет";
            }

            if ((PaymentStatus)value == PaymentStatus.NotDetermined)
            {
                return "Не определен";
            }

            if ((PaymentStatus)value == PaymentStatus.Paid)
            {
                return "Оплачено";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
