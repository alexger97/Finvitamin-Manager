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
   public class ProductConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Product)value is Product)
            {

               System.Convert.ToInt32(parameter);
               // Convert.ToInt32()



                switch (System.Convert.ToInt32(parameter))
                {

                    case 1: { return (value as Product).Name;   }
                    case 2: { return (value as Product).Decsription;  }
                    case 3: { return (value as Product).Price;  }
                    //  case 4: { return (value as Product).ProviderType.ToString(); break; }
                    case 5: { return (value as Product).PurchasePrice; }
                    case 6: { return (value as Product).Weight;  }
                    case 7: { return (value as Product).PurchasePrice;  }
                    case 8: { return (value as Product).Price; }
                    case 9: { return (value as Product).CurrentBalance; }

                }
            }

              


              return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
