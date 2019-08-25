﻿using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FinVitamin_Manager.Views.Converter
{
   public class OrderRigionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((FinVitamin_Manager.Models.OrderRegion)value is FinVitamin_Manager.Models.OrderRegion)
            {

               System.Convert.ToInt32(parameter);
                // Convert.ToInt32()



                var tt = (FinVitamin_Manager.Models.OrderRegion)value;

                switch (System.Convert.ToInt32(parameter))
                {
                   
                    case 1: { return tt.Id ;   }
                    case 2: { return tt.StartExecute.Date.ToShortDateString(); }
                    case 3: { return tt.CustomerName + " " + tt.CustomerPhone; }
                    case 4: { return tt.RecipientFullName + "  " + tt.RecipientTelephone; }
                    case 5: { return tt.AdressDilivery; }
                    
                   
                    case 6: { return tt.DepartureDate.Date.ToShortDateString();   }
                    case 7: {
                            if (tt.SendVariant==Models.Enums.SendVariant.CDEK)
                            return "CDEK";
                            if (tt.SendVariant == Models.Enums.SendVariant.EMS)
                                return "EMS";
                            if (tt.SendVariant == Models.Enums.SendVariant.RussiaPost)
                                return "Почта России";
                            return null;
                        }
                    case 8: { return tt.SendingCost; }

                    case 9: { return tt.TotalToPay; }
                    case 10:
                        {
                            if (tt.ProccessingStatus == ProccessingStatus.Canceled_by_client) return "Отменен клиентом";
                            if (tt.ProccessingStatus == ProccessingStatus.Canceled_by_manager) return "Отменен менеджером";
                            if (tt.ProccessingStatus == ProccessingStatus.Expectation) return "Ожидание";
                            if (tt.ProccessingStatus == ProccessingStatus.Sending) return "Отправка";
                            if (tt.ProccessingStatus == ProccessingStatus.Sent_to_customer) return "Отправлен клиенту";
                            return null;
                        }
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
