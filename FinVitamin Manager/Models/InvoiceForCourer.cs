using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
    public partial class InvoiceForCourer
    {
        public int Id { get; set; }

        public virtual Courer WorkCourer { get; set; }

        private List<CourerTask> _courerTasks;
        public virtual List<CourerTask> CourerTasks {
            get { if (WorkCourer != null) { _courerTasks = WorkCourer.DiliveryOrders.Where(x=>x.InvoiceForCourer==this).ToList(); return _courerTasks; } return _courerTasks; }

            set { _courerTasks = value; } }

        public DateTime DataForInvoice { get; set; }


        public int CountOfDilivery { get => CourerTasks.Count; }
      public double CostOfDilivery { get { return CourerTasks.Select(x => x.DelivetyCost).ToArray().Sum(); } }

       public double SummWithouthDilivery { get { return CourerTasks.Select(x => x.OrderSpb.Total).ToArray().Sum(); } }

        public bool IsEnded { get { if (CourerTasks != null)
                {
                    bool y = true;
                    foreach (bool tt in CourerTasks.Select(x => x.IsCompleted).ToArray()) { y = y && tt; }
                    if (y) return true; return false;
                }
                else return false; } }
                        
                           






    }

}
