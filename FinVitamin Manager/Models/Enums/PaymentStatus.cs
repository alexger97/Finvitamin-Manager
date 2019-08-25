using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models.Enums
{
 public  enum PaymentStatus
    {
        [Description("Не определен")]
        NotDetermined,
        [Description("Выставлен счет")]
        Invoiced,
        [Description("Оплачено")]
        Paid
    }
}
