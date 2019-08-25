using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models.Enums
{
   public enum SendVariant
    {
        [Description("Почта России")]
        RussiaPost,

        [Description("EMS")]
        EMS,
        [Description("CDEK")]
        CDEK
    }
}
