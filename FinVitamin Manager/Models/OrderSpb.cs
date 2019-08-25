﻿using FinVitamin_Manager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Models
{
    public partial class OrderSpb
    {
       
        public int Id { get; set; }

        public string IdString { get => "S" + Id.ToString(); }

        public bool IsCompleted { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public TypeOfPayment TypeOfPayment { get; set; }

        public ProccessingStatus ProccessingStatus { get; set; }


        public TypeOfDelivery TypeOfDelivery { get; set; }


        #region OrederTimes
        public DateTime ArrivalTime { get; set; }

        public DateTime StartExecute { get; set; }

        #endregion

        #region Customer

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAdress { get; set; }
        #endregion


        #region Recipient

        public string RecipientFullName { get; set; }

        public string RecipientTelephone { get; set; }

        #endregion

        #region Delivery
        public MetroStation MetroStation { get; set; }

        public String AdressDilivery { get; set; }

        public DateTime DateDilivery { get; set; }

        public string TimeDilivery { get; set; }

        public double  DelivetyCost { get; set; }


        public virtual CourerTask CourerTask { get; set; }
        #endregion


        #region Pickup

        public TypeOfOffice TypeOfOffice { get; set; }


        #endregion



        public string Comment { get; set; }



        public virtual List<OrderProdust> OrderProducts { get; set; }

        #region Total
        //   public double Total { get; set; }
        //  public double TotalToPay { get; set; }
        #endregion


        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}
