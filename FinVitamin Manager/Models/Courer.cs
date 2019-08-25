using FinVitamin_Manager.Models.Enums;
using FinVitamin_Manager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
 public   class Courer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Vk { get; set; }

        public MetroStation Metro { get; set; }

        public bool HaveCar { get; set; }

        public DateTime DateOfBirdth { get; set; }

      
        private List<CourerTask> _diliveryOrders;
    public virtual List<CourerTask> DiliveryOrders { get { _diliveryOrders = CourerTaskManager.CourerTasksST.Where(x => x.Courer.Id == Id).ToList(); return _diliveryOrders;  } set { _diliveryOrders = value; } }

    }
}
