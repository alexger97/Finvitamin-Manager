using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Service
{
   public class CourerTaskManager
    {
        public static ProductContext ProductContext;


        public static List<CourerTask> CourerTasksST { get { return ProductContext.CourerTasks.ToList(); } }

        public Dictionary<int, CourerTask> CourerTaskDictonary { get => ProductContext.CourerTasks.ToDictionary((x) => x.OrderSpb.Id); }

        public CourerTaskManager(ProductContext pc)
        {
            ProductContext = pc;
           
        }

        public CourerTaskManager()
        {
        }

        public void AddTask(int orderid, int courerid)
        {
            if (!CourerTaskDictonary.ContainsKey(orderid)) { ProductContext.CourerTasks.Add(new CourerTask { OrderSpb = ProductContext.OrdersSpb.First(x => x.Id == orderid), Courer=ProductContext.Courers.First(x=>x.Id==courerid) });  ProductContext.SaveChanges(); }

        }

        public CourerTask GetCourerTask(int id)
        {

            try
            {
                return ProductContext.CourerTasks.First(x=>x.CourerId==id);
            }
            catch { return null; }

        }


    }
}
