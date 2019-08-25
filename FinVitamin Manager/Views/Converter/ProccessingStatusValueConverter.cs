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
    public class ProccessingStatusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((ProccessingStatus)value == ProccessingStatus.Canceled_by_client)
            {
                return "Отменен клиентом";
            }

            if ((ProccessingStatus)value == ProccessingStatus.Canceled_by_manager)
            {
                return "Отменен менеджером";
            }

            if ((ProccessingStatus)value == ProccessingStatus.Expectation)
            {
                return "Ожидание";
            }

            if ((ProccessingStatus)value == ProccessingStatus.Sending)
            {
                return "Отправка";
            }

            if ((ProccessingStatus)value == ProccessingStatus.Sent_to_customer)
            {
                return "Отправлен клиенту";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
