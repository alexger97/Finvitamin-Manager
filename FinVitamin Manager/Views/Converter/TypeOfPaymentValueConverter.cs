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
    public class TypeOfPaymentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((TypeOfPayment)value == TypeOfPayment.Alfa)
            {
                return "АльфаБанк";
            }

            if ((TypeOfPayment)value == TypeOfPayment.Cash)
            {
                return "Наличные";
            }

            if ((TypeOfPayment)value == TypeOfPayment.PayPal)
            {
                return "PayPal";
            }

            if ((TypeOfPayment)value == TypeOfPayment.Qiwi)
            {
                return "Qiwi";
            }

            if ((TypeOfPayment)value == TypeOfPayment.Sberbank)
            {
                return "Сбербанк";
            }

            if ((TypeOfPayment)value == TypeOfPayment.Webmoney)
            {
                return "WebMoney";
            }

            if ((TypeOfPayment)value == TypeOfPayment.YandexMoney)
            {
                return "ЯндексДеньги";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
