using FinVitamin_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
 public   class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Decsription { get; set; }
        public double Weight { get; set; }

        public double PurchasePrice { get; set; }

        public ProviderType ProviderType { get; set; }



        public double Price { get; set; }

        public int CurrentBalance { get; set; }


        public virtual List<PresenceOrderRegion> PresenceOrderRegions { get; set; }

        public virtual List<PresenceOrderSpb> PresenceOrderSpbs { get; set; }

    }
}
