using FinVitamin_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
    public class CourerTask
    {
        public int Id { get; set; }

        public int OrderSpbId { get; set; }
        public virtual OrderSpb OrderSpb { get; set; }

        public int CourerId { get; set; }
        public virtual Courer Courer { get; set; }

      

        public MetroStation MetroStation { get => OrderSpb.MetroStation; }

        public String AdressDilivery { get => OrderSpb.AdressDilivery; }

        public DateTime DateDilivery { get => OrderSpb.DateDilivery; }

        public string TimeDilivery { get => OrderSpb.TimeDilivery; }

        public string ClientInformation { get => OrderSpb.RecipientFullName + " " + OrderSpb.RecipientTelephone; }

        public double Weight { get => OrderSpb.OrderProducts.Select(x => x.Product.Weight).ToArray().Sum(); }

        public double SummWithoutDilivery { get => OrderSpb.Total; }

        public double SummTotal { get => OrderSpb.TotalToPay; }
        public double DelivetyCost { get => OrderSpb.DelivetyCost; }

        public string Comment { get => OrderSpb.Comment; }
        public bool IsCompleted { get => OrderSpb.IsCompleted; }

        public virtual InvoiceForCourer  InvoiceForCourer {get; set;}
        
    }
}
