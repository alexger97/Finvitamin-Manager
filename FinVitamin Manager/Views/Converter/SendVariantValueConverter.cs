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
    public class SendVariantValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((SendVariant)value == SendVariant.CDEK)
            {
                return "SDEK";
            }

            if ((SendVariant)value == SendVariant.EMS)
            {
                return "EMS";
            }

            if ((SendVariant)value == SendVariant.RussiaPost)
            {
                return "Почта России";
            }

            

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
