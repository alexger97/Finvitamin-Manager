using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
  public  class PresenceOrderSpb
    {
        public int Id { get; set; }
        public virtual OrderSpb OrderSpb { get; set; }

      public int Count { get; set; }

      public DateTime ChangeTime { get; set; }
    }
}
