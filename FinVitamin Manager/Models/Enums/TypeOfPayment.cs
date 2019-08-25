using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models.Enums
{
  public  enum TypeOfPayment
    {

        [Description("Наличные")]
        Cash,


        [Description("Сбербанк")]
        Sberbank,

        [Description("АльфаБанк")]
        Alfa,
        [Description("ЯндексДеньги")]
        YandexMoney,
        [Description("Qiwi")]
        Qiwi,
        [Description("WebMoney")]
        Webmoney,
        [Description("PayPal")]
        PayPal



        


    }
}
