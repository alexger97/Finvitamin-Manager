using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
    
    public class OrderProdust:IEquatable<OrderProdust>
    {

      public int Id { get; set; }
      public virtual Product Product { get; set; }

        public int ProductId { get; set; }
        public  int Count { get; set; }
        
        public int OldCount { get; set; }
        public int CanAdd { get { if (Product != null) { return Product.CurrentBalance + OldCount; } return 0; } }

        public bool Equals(OrderProdust other)
        {
            if (other is null)
                return false;

            return this.ProductId == other.ProductId && this.Count == other.Count;
        }

        public override bool Equals(object obj) => Equals(obj as OrderProdust);
        public override int GetHashCode() => (ProductId, Count).GetHashCode();

    }
}
