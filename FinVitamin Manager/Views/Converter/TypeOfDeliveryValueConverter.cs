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
    public class TypeOfDeliveryValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if ((TypeOfDelivery)value== TypeOfDelivery.Delivery)
            {
                return "Доставка по городу";
            }

           
            if ((TypeOfDelivery)value == TypeOfDelivery.Pickup)
            {
                return "Самовывоз";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
