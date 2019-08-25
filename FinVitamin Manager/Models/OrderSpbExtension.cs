using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
    public partial class OrderSpb
    {
        public double Total
        {

            get {
                if(this.OrderProducts==null)
                { return 0; }
                else
                {
                     double summ = 0;
                    foreach(OrderProdust pr in this.OrderProducts)
                    {
                        summ += pr.Product.Price * pr.Count; 

                    }
                    return summ;
                }
                    
                    
                    }
        }


        public double TotalToPay
        {

            get { return Total + this.DelivetyCost; }
        }


    }
}
