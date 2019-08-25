using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models.Enums
{
  public  enum ProccessingStatus
    {
        [Description("Ожидание")]
        Expectation,

        [Description("Отправка")]
        Sending,

        [Description("Отправлен клиенту")]
        Sent_to_customer,

        [Description("Отменен клиентом")]
        Canceled_by_client,

        [Description("Отменен менеджером")]
        Canceled_by_manager

    }
}
