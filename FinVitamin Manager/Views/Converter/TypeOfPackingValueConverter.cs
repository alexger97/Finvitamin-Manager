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
    public class TypeOfPackingValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if ((TypeOfPacking)value== TypeOfPacking.pc1)
            {
                return "ПК-1";
            }

            if ((TypeOfPacking)value == TypeOfPacking.pc2)
            {
                return "ПК-2";
            }

            if ((TypeOfPacking)value == TypeOfPacking.pc3)
            {
                return "ПК-3";
            }

            if ((TypeOfPacking)value == TypeOfPacking.pc4)
            {
                return "ПК-4";
            }

            if ((TypeOfPacking)value == TypeOfPacking.pc5)
            {
                return "ПК-5";
            }
            if ((TypeOfPacking)value == TypeOfPacking.pc6)
            {
                return "ПК-6";
            }


            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
