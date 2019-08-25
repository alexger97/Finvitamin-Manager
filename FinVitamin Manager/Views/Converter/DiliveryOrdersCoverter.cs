using FinVitamin_Manager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FinVitamin_Manager.Views.Converter
{
    class DiliveryOrdersCoverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tt = (List<CourerTask>)(value);
            if ( tt!=null)
            {
                return tt.Select(x => x.IsCompleted == false && x.InvoiceForCourer == null).ToArray().Count().ToString();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
