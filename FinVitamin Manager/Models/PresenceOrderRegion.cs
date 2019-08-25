using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
   public class PresenceOrderRegion
    {
        public int Id { get; set; }
        public virtual  OrderRegion OrderRegion { get; set; }

      public int Count { get; set; }

      public DateTime ChangeTime { get; set; }


    }
}
