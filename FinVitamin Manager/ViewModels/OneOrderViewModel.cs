using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.Models.Enums;
using FinVitamin_Manager.ViewModels.Command;
using FinVitamin_Manager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinVitamin_Manager.ViewModels
{
    public class OneOrderViewModel : ViewModelBase
    {

        private bool enabled;
        public bool Enabled { get => enabled; set { enabled = value; OnPropertyChanged("Enabled"); } }

        private bool isEdding;
        public bool IsEdding { get => isEdding; set { isEdding = value; OnPropertyChanged("IsEdding"); } }


        private bool orderSpb;

        public bool OrderSpb { get => orderSpb; set { orderSpb = value; OnPropertyChanged("OrderSpb"); } }

        public ProductContext ProductContextVM;
        public OneOrderViewModel(ProductContext productContext)
        {
            OrderSpb = true;
            ProductContextVM = productContext;

            OrderProductsVM1 = new ObservableCollection<OrderProdust>();
            Enabled = true;

            var time = DateTime.Now;
            ArrivalTime = StartExecute = DateDiliverySpb = DepartureDateRegion = time;
            CustomerName = CustomerPhone = CustomerEmail = CustomerAdress = RecipientFullName = RecipientTelephone = AdressDilivery = TimeDiliverySpb = Comment = "";

            DeliveryCostSpb = SendingCostRegion = "0";


            OrderProductsVM1.CollectionChanged += OrderProductsVM1_CollectionChanged;
            Clear();
          
        }

        private void OrderProductsVM1_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        { OnPropertyChanged("TotalVM"); OnPropertyChanged("TotalToPayVM");

            OnPropertyChanged("CountProducts");

        }

       






        #region GeneralOrder

        private int id;
        public int Id { get => id;set { id = value; OnPropertyChanged("Id"); } }

        private bool isCompleted;
        public bool IsCompleted { get => isCompleted; set { isCompleted = value; OnPropertyChanged("IsCompleted"); } }

        private PaymentStatus paymentStatus;
        public PaymentStatus PaymentStatus
        {
            get => paymentStatus;


            set { paymentStatus = value; OnPropertyChanged("PaymentStatus"); }
        }

        private TypeOfPayment typeOfPayment;
        public TypeOfPayment TypeOfPayment
        {
            get => typeOfPayment;


            set { typeOfPayment = value; OnPropertyChanged("TypeOfPayment"); }
        }


        private ProccessingStatus proccessingStatus;
        public ProccessingStatus ProccessingStatus
        {
            get => proccessingStatus;


            set { proccessingStatus = value; OnPropertyChanged("ProccessingStatus"); }
        }

        private TypeOfDelivery typeOfDeliverySpb;
        public TypeOfDelivery TypeOfDeliverySpb
        {
            get => typeOfDeliverySpb;


            set { typeOfDeliverySpb = value; OnPropertyChanged("TypeOfDeliverySpb");
                if (value==TypeOfDelivery.Pickup )
                {
                    DeliveryCostSpb = "0";
                }

               


            }
        }



        #region OrederTimes
        private DateTime arrivalTime;
        public DateTime ArrivalTime
        {
            get => arrivalTime;


            set { arrivalTime = value; OnPropertyChanged("ArrivalTime"); }
        }


        private DateTime startExecute;
        public DateTime StartExecute
        {
            get => startExecute;


            set { startExecute = value; OnPropertyChanged("StartExecute"); }
        }

        #endregion

        #region Customer

        private string customerName;
        public string CustomerName
        {
            get => customerName;


            set { customerName = value; OnPropertyChanged("CustomerName"); }
        }


        private string customerPhone;
        public string CustomerPhone
        {
            get => customerPhone;


            set { customerPhone = value; OnPropertyChanged("CustomerPhone"); }
        }

        private string customerEmail;
        public string CustomerEmail
        {
            get => customerEmail;


            set { customerEmail = value; OnPropertyChanged("CustomerEmail"); }
        }

        private string customerAdress;
        public string CustomerAdress
        {
            get => customerAdress;


            set { customerAdress = value; OnPropertyChanged("CustomerAdress"); }
        }
        #endregion

        #region Recipient

        private string recipientFullName;
        public string RecipientFullName
        {
            get => recipientFullName;


            set { recipientFullName = value; OnPropertyChanged("RecipientFullName"); }
        }

        private string recipientTelephone;
        public string RecipientTelephone
        {
            get => recipientTelephone;


            set { recipientTelephone = value; OnPropertyChanged("RecipientTelephone"); }
        }

        #endregion

        #region Delivery

        private string adressDilivery;
        public String AdressDilivery
        {
            get => adressDilivery;


            set { adressDilivery = value; OnPropertyChanged("AdressDilivery"); }
        }







        private MetroStation metroStationSpb;
        public MetroStation MetroStationSpb
        {
            get => metroStationSpb;


            set { metroStationSpb = value; OnPropertyChanged("MetroStationSpb"); }
        }



        private DateTime dateDiliverySpb;
        public DateTime DateDiliverySpb
        {
            get => dateDiliverySpb.Date;


            set { dateDiliverySpb = value; OnPropertyChanged("DateDiliverySpb"); }
        }

        private string timeDiliverySpb;
        public string TimeDiliverySpb
        {
            get => timeDiliverySpb;


            set { timeDiliverySpb = value; OnPropertyChanged("TimeDiliverySpb"); }
        }

        private string delivetyCostSpb;
        public string DeliveryCostSpb
        {
            get => delivetyCostSpb;


            set { 
                double result;
                if (double.TryParse(value,out  result))
                {

                    if (result > 0)
                        delivetyCostSpb = value;
                    else { delivetyCostSpb = "0"; }

                }
                else { delivetyCostSpb = "0"; }


                OnPropertyChanged("DeliveryCostSpb"); OnPropertyChanged("TotalToPayVM"); }

        }

        private CourerTask courerTask;

        public CourerTask CourerTask { get => courerTask; set { courerTask = value; OnPropertyChanged("CourerTask"); } }


        #region RegionDelivety

        private SendVariant sendVariantRegion;
        public SendVariant SendVariantRegion
        {
            get => sendVariantRegion;


            set { sendVariantRegion = value; OnPropertyChanged("SendVariantRegion"); }
        }


        private DateTime departureDateRegion;
        public DateTime DepartureDateRegion
        {
            get => departureDateRegion;


            set { departureDateRegion = value; OnPropertyChanged("DepartureDateRegion"); }
        }

        private TypeOfPacking typeOfPackingRegion;
        public TypeOfPacking TypeOfPackingRegion
        {
            get => typeOfPackingRegion;


            set { typeOfPackingRegion = value; OnPropertyChanged("TypeOfPackingRegion"); }
        }

        private string sendingCostRegion;
        public string SendingCostRegion
        {
            get => sendingCostRegion;


            set {
                double result;
                if (double.TryParse(value, out result))
                {
                    if(result>0)
                    sendingCostRegion = value;
                    else { sendingCostRegion = "0"; }
                }
                else { sendingCostRegion = "0"; }


 OnPropertyChanged("SendingCostRegion"); OnPropertyChanged("TotalToPayVM"); }
        }


        #endregion
        #endregion


        #region Pickup

        private TypeOfOffice typeOfOfficeSpb;
        public TypeOfOffice TypeOfOfficeSpb
        {
            get => typeOfOfficeSpb;


            set { typeOfOfficeSpb = value; OnPropertyChanged("TypeOfOfficeSpb");

            
}
        }


        #endregion

        private string comment;
        public string Comment
        {
            get => comment;


            set { comment = value; OnPropertyChanged("Comment"); }
        }



       

        #region Total
        public ObservableCollection<OrderProdust> orderProductsVM1;
        public ObservableCollection<OrderProdust> OrderProductsVM1 { get => orderProductsVM1; set { orderProductsVM1 = value; OnPropertyChanged("OrderProductsVM1"); } }



        public List<OrderProdust> OldOrdersofOrder;


        private double totalVM { get; set; }



        public double TotalVM
        {
            get

            {
                if (this.OrderProductsVM1 == null)
                { return 0; }
                else
                {
                    double summ = 0;
                    foreach (OrderProdust pr in this.OrderProductsVM1.ToList())
                    {
                        summ = summ + pr.Product.Price * pr.Count;
                       // summ += ;

                    }
                    return summ;
                }

            }
        }



          



       
        public double TotalToPayVM { get
            { if (OrderSpb)
                {
                    if (this.TypeOfDeliverySpb == TypeOfDelivery.Delivery)
                    {
                        double result;
                        if (double.TryParse(DeliveryCostSpb,out result))
                        {
                            return TotalVM + result;
                        }
                        else
                        {
                            return -1;
                        }
                         }
                    else { return TotalVM; }

                }
                else {
                    double result;
                    if (double.TryParse(SendingCostRegion, out result))
                    {
                        return TotalVM + result;
                    }

                    else { return -1; }
                }




            }}

        #endregion


        #endregion


        public int CountProducts
        {
            get
            {
                if (OrderProductsVM1 == null)
                {
                    return 0;
                }
                else { return OrderProductsVM1.Count; }
            }
        }













        public void update()  => OnPropertyChanged("OrderProductsVM");


        public void Clear()
        {
        
            var time = DateTime.Now;
            ArrivalTime = StartExecute = DateDiliverySpb = DepartureDateRegion = time;
            CustomerName = CustomerPhone = CustomerEmail = CustomerAdress = RecipientFullName = RecipientTelephone = AdressDilivery = TimeDiliverySpb = Comment = "";

            DeliveryCostSpb = SendingCostRegion= "0";
            
            Id = 0;
            IsCompleted = false;
           IsEdding = false;
            CourerTask = null;
            
            OrderProductsVM1.Clear();
        }


        public void ParseOrderRegion(OrderRegion OR)
        {
            Clear();


            foreach (OrderProdust or in OR.OrderProducts)
            {
                or.OldCount = or.Count;
            }
            
            Id = OR.Id;
            PaymentStatus = OR.PaymentStatus;
            TypeOfPayment = OR.TypeOfPayment;
            ProccessingStatus = OR.ProccessingStatus;

            ArrivalTime = OR.ArrivalTime;
            StartExecute = OR.StartExecute;


            CustomerName = OR.CustomerName;
            CustomerPhone = OR.CustomerPhone;
            CustomerEmail = OR.CustomerEmail;
            CustomerAdress = OR.CustomerAdress;


            RecipientFullName = OR.RecipientFullName;
            RecipientTelephone = OR.RecipientTelephone;

            AdressDilivery = OR.AdressDilivery;

            SendVariantRegion = OR.SendVariant;
            DepartureDateRegion = OR.DepartureDate;

            TypeOfPackingRegion = OR.TypeOfPacking;
            SendingCostRegion = OR.SendingCost.ToString();
            Comment = OR.Comment;
            OrderProductsVM1 = new ObservableCollection<OrderProdust>(OR.OrderProducts);
            OrderSpb = false;
            //TotalVM = OR.Total;
            // TotalToPayVM = OR.TotalToPay;
            OnPropertyChanged("TotalVM"); OnPropertyChanged("TotalToPayVM");

            OnPropertyChanged("CountProducts");
        }

        public void ParseOrderSpb(OrderSpb OR)
        {
            Clear();

            foreach (OrderProdust or in OR.OrderProducts)
            {
                or.OldCount = or.Count;
            }
            Id = OR.Id;
            PaymentStatus = OR.PaymentStatus;
            TypeOfPayment = OR.TypeOfPayment;
            ProccessingStatus = OR.ProccessingStatus;

            ArrivalTime = OR.ArrivalTime;
            StartExecute = OR.StartExecute;


            CustomerName = OR.CustomerName;
            CustomerPhone = OR.CustomerPhone;
            CustomerEmail = OR.CustomerEmail;
            CustomerAdress = OR.CustomerAdress;


            RecipientFullName = OR.RecipientFullName;
            RecipientTelephone = OR.RecipientTelephone;

            AdressDilivery = OR.AdressDilivery;
            TypeOfDeliverySpb = OR.TypeOfDelivery;

            MetroStationSpb = OR.MetroStation;
            DateDiliverySpb = OR.DateDilivery;
            TimeDiliverySpb = OR.TimeDilivery;
            DeliveryCostSpb = OR.DelivetyCost.ToString();
            TypeOfOfficeSpb = OR.TypeOfOffice;
            CourerTask = OR.CourerTask;
            OrderSpb = true;




            Comment = OR.Comment;
            OrderProductsVM1 = new ObservableCollection<OrderProdust>(OR.OrderProducts);
          
            OnPropertyChanged("TotalVM"); OnPropertyChanged("TotalToPayVM");

            OnPropertyChanged("CountProducts");
        }







        #region List



        private OrderProdust currentOrderProduct;
        public OrderProdust CurrentOrderProduct { get => currentOrderProduct; set { currentOrderProduct = value; OnPropertyChanged("CurrentOrderProduct"); } }


        #endregion







        #region Commands

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get

            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddClientCommand, CanExecuteAddClientCommand);
                return _addCommand;
            }

        }



        public void ExecuteAddClientCommand(object parameter)
        {
            var vin = new ListProducts() { DataContext = new ListProductsViewModel(this, ProductContextVM) };
            this.Enabled = false;
            vin.Show();
            vin.Closed += delegate (object sender, System.EventArgs e)
            {
                this.Enabled = true;

            };
        }

        public bool CanExecuteAddClientCommand(object parameter)
        {

            return true;
        }




        private RelayCommand _RefeshCommand;

        public RelayCommand RefeshCommand
        {
            get

            {
                if (_RefeshCommand == null)
                    _RefeshCommand = new RelayCommand(ExecuteRefeshCommand, CanExecuteRefeshtCommand);
                return _RefeshCommand;
            }

        }



        public void ExecuteRefeshCommand(object parameter)
        {
            update();

        }

        public bool CanExecuteRefeshtCommand(object parameter)
        {

            return true;
        }


        private RelayCommand _DellCommand;

        public RelayCommand DellCommand
        {
            get

            {
                if (_DellCommand == null)
                    _DellCommand = new RelayCommand(ExecuteDellCommand, CanExecuteDellCommand);
                return _DellCommand;
            }

        }



        public void ExecuteDellCommand(object parameter)
        {

            OrderProductsVM1.Remove(CurrentOrderProduct);
        }

        public bool CanExecuteDellCommand(object parameter)
        {
            if (CurrentOrderProduct != null)
                return true;
            return false;


        }





        private RelayCommand _SaveCommand;

        public RelayCommand SaveCommand
        {
            get

            {
                if (_SaveCommand == null)
                    _SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
                return _SaveCommand;
            }

        }



        public void ExecuteSaveCommand(object parameter)
        {
            // try
            // {

            if (IsEdding)
            {

                if (OrderSpb)
                {
                    double result;
                    if (!double.TryParse(DeliveryCostSpb, out result))
                    {
                        MessageBox.Show("Ошибка: неверная цена доставки");
                    }
                    else {
                      

                        foreach(OrderProdust orderProdust in OrderProductsVM1.ToList())
                        {

                            if (OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId) != null)
                            {
                                if (!orderProdust.Equals(OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId)))
                                {
                                    int delta = 0;
                                    if (orderProdust.Count > OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId).Count)
                                    {
                                        delta = orderProdust.Count - OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId).Count;
                                        ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).CurrentBalance -= delta;
                                        ProductContextVM.SaveChanges();
                                    }
                                    else
                                    {
                                        delta = OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId).Count - orderProdust.Count;
                                        ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).CurrentBalance += delta;
                                        ProductContextVM.SaveChanges();
                                    }
                                    
ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).PresenceOrderSpbs.First(x => x.OrderSpb.Id == Id).ChangeTime = DateTime.Now;
                                    ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).PresenceOrderSpbs.First(x => x.OrderSpb.Id == Id).Count = orderProdust.Count;
                                    ProductContextVM.SaveChanges();
                                }

                            }

                            else
                            {
                                ProductContextVM.Products.First(x => x.Id == orderProdust.Product.Id).PresenceOrderSpbs.Add(new PresenceOrderSpb { ChangeTime = DateTime.Now, Count = orderProdust.Count, OrderSpb = ProductContextVM.OrdersSpb.Find(Id) });
                                //Remove(ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).PresenceOrderSpbs.First(x => x.OrderSpb.Id == Id));
                                ProductContextVM.Products.First(x => x.Id == orderProdust.Product.Id).CurrentBalance -= orderProdust.Count;
                                ProductContextVM.SaveChanges();
                            }

                         


                        }
                        foreach (OrderProdust order in OldOrdersofOrder)
                            {
                                if (OrderProductsVM1.ToList().Find(x => x.ProductId == order.ProductId) == null)
                                {

                                    ProductContextVM.Products.First(x => x.Id == order.Product.Id).PresenceOrderSpbs.Remove(ProductContextVM.Products.First(x => x.Id == order.Product.Id).PresenceOrderSpbs.First(y => y.OrderSpb == ProductContextVM.OrdersSpb.First(z => z.Id == Id)));
                                ProductContextVM.Products.First(x => x.Id == order.ProductId).CurrentBalance += order.Count;
                                ProductContextVM.SaveChanges();

                                }
                            }


                       



      



                            ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).AdressDilivery = AdressDilivery;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).ArrivalTime = ArrivalTime;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).Comment = Comment;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).CustomerAdress = CustomerAdress;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).CustomerEmail = CustomerEmail;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).CustomerName = CustomerName;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).CustomerPhone = CustomerPhone;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).DateDilivery = DateDiliverySpb.Date;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).DelivetyCost = result;

                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).MetroStation = MetroStationSpb;
                   
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).PaymentStatus = PaymentStatus;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).ProccessingStatus = ProccessingStatus;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).RecipientFullName = RecipientFullName;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).RecipientTelephone = RecipientTelephone;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).StartExecute = StartExecute;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).TimeDilivery = TimeDiliverySpb;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).TypeOfDelivery = TypeOfDeliverySpb;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).TypeOfOffice = TypeOfOfficeSpb;
                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).TypeOfPayment = TypeOfPayment;
                        ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).CourerTask.Courer = CourerTask.Courer;
                    }

                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).IsCompleted = IsCompleted;


                    


                    

                    ProductContextVM.OrdersSpb.First(x => x.Id == this.Id).OrderProducts = OrderProductsVM1.ToList();
                    ProductContextVM.SaveChanges();




                    if (IsCompleted) { MessageBox.Show("Заказ успешно отредактирован и помечен как законченный "); }
                    else {
                        MessageBox.Show("Заказ успешно отредактирован");
                    }
                    Clear();
                }

                else
                {

                    double result;
                    if (!double.TryParse(SendingCostRegion, out result))
                    {
                        MessageBox.Show("Ошибка: неверная цена доставки");
                    }

                    else {

                        foreach (OrderProdust orderProdust in OrderProductsVM1.ToList())
                        {

                            if (OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId) != null)
                            {
                                if (!orderProdust.Equals(OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId)))
                                {
                                    int delta = 0;
                                    if (orderProdust.Count > OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId).Count)
                                    {
                                        delta = orderProdust.Count - OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId).Count;
                                        ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).CurrentBalance -= delta;
                                        ProductContextVM.SaveChanges();
                                    }
                                    else
                                    {
                                        delta = OldOrdersofOrder.Find(x => x.ProductId == orderProdust.ProductId).Count - orderProdust.Count;
                                        ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).CurrentBalance += delta;
                                        ProductContextVM.SaveChanges();
                                    }

                                    ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).PresenceOrderRegions.First(x => x.OrderRegion.Id == Id).ChangeTime = DateTime.Now;
                                    ProductContextVM.Products.First(x => x.Id == orderProdust.ProductId).PresenceOrderRegions.First(x => x.OrderRegion.Id == Id).Count = orderProdust.Count;
                                    ProductContextVM.SaveChanges();
                                }

                            }

                            else
                            {
                                ProductContextVM.Products.First(x => x.Id == orderProdust.Product.Id).PresenceOrderRegions.Add(new PresenceOrderRegion { ChangeTime = DateTime.Now, Count = orderProdust.Count, OrderRegion = ProductContextVM.OrdersRegion.Find(Id) });
                                
                                ProductContextVM.Products.First(x => x.Id == orderProdust.Product.Id).CurrentBalance -= orderProdust.Count;
                                ProductContextVM.SaveChanges();
                            }




                        }
                        foreach (OrderProdust order in OldOrdersofOrder)
                        {
                            if (OrderProductsVM1.ToList().Find(x => x.ProductId == order.ProductId) == null)
                            {

                                ProductContextVM.Products.First(x => x.Id == order.Product.Id).PresenceOrderRegions.Remove(ProductContextVM.Products.First(x => x.Id == order.Product.Id).PresenceOrderRegions.First(y => y.OrderRegion == ProductContextVM.OrdersRegion.First(z => z.Id == Id)));
                                ProductContextVM.Products.First(x => x.Id == order.ProductId).CurrentBalance += order.Count;
                                ProductContextVM.SaveChanges();

                            }
                        }










                        ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).AdressDilivery = AdressDilivery;

                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).ArrivalTime = ArrivalTime;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).Comment = Comment;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).CustomerAdress = CustomerAdress;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).CustomerEmail = CustomerEmail;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).CustomerName = CustomerName;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).CustomerPhone = CustomerPhone;
                   

                    
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).OrderProducts = OrderProductsVM1.ToList();
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).PaymentStatus = PaymentStatus;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).ProccessingStatus = ProccessingStatus;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).RecipientFullName = RecipientFullName;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).RecipientTelephone = RecipientTelephone;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).StartExecute = StartExecute;
                  
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).TypeOfPayment = TypeOfPayment;

                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).DepartureDate = DepartureDateRegion.Date;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).SendingCost = result;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).SendVariant = SendVariantRegion;
                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).TypeOfPacking = TypeOfPackingRegion;
               

                    ProductContextVM.OrdersRegion.First(x => x.Id == this.Id).IsCompleted = IsCompleted;
                    ProductContextVM.SaveChanges();
                    if (IsCompleted) { MessageBox.Show("Заказ успешно отредактирован и помечен как законченный "); }
                    else
                    {
                        MessageBox.Show("Заказ успешно отредактирован");
                    }
                    Clear();
                    }
                }



            }
            else
            {


            

            if (OrderSpb)
            {
                   

                    if(TypeOfDeliverySpb==TypeOfDelivery.Delivery)
                    {

                        double result;
                        if (!double.TryParse(DeliveryCostSpb, out result)&&result>0)
                        {
                          
                            MessageBox.Show("Ошибка: неверная цена доставки");
                        }
                        else
                        {
                            ProductContextVM.CourerTasks.Add(new CourerTask
                            {
                                Courer = CourerTask.Courer,
                                OrderSpb = new Models.OrderSpb
                                {



                                    CustomerAdress = CustomerAdress,
                                    CustomerEmail = CustomerEmail,
                                    CustomerName = CustomerName,
                                    CustomerPhone = CustomerPhone,

                                    RecipientFullName = RecipientFullName,
                                    RecipientTelephone = RecipientTelephone,
                                    TypeOfPayment = TypeOfPayment,
                                    ArrivalTime = ArrivalTime,
                                    PaymentStatus = PaymentStatus,

                                    Comment = Comment,
                                    AdressDilivery = AdressDilivery,
                                    DateDilivery = DateDiliverySpb.Date,
                                    DelivetyCost = result,
                                    ProccessingStatus = ProccessingStatus,
                                    StartExecute = StartExecute,
                                    TimeDilivery = TimeDiliverySpb,
                                    TypeOfDelivery = TypeOfDeliverySpb,
                                    TypeOfOffice = TypeOfOfficeSpb,
                                    IsCompleted = false,
                                    OrderProducts = OrderProductsVM1.ToList(),


                                }
                            });
                        

                            
                            ProductContextVM.SaveChanges();
                           
                          
                            foreach (OrderProdust OrderProduct in OrderProductsVM1.ToList())
                            {
                                Product ProductV = OrderProduct.Product;
                                ProductV.PresenceOrderSpbs.Add(new PresenceOrderSpb { ChangeTime = DateTime.Now, Count = OrderProduct.Count, OrderSpb = ProductContextVM.OrdersSpb.Last() });
                                ProductContextVM.Products.First(x => x.Id == ProductV.Id).CurrentBalance -= OrderProduct.Count;
                                ProductContextVM.SaveChanges();
                            }




                            MessageBox.Show("Успешно сохранен заказ");
                            Clear();
                        }


                    }
                    else
                    {

                    ProductContextVM.OrdersSpb.Add(new Models.OrderSpb
                        {



                            CustomerAdress = CustomerAdress,
                            CustomerEmail = CustomerEmail,
                            CustomerName = CustomerName,
                            CustomerPhone = CustomerPhone,

                            RecipientFullName = RecipientFullName,
                            RecipientTelephone = RecipientTelephone,
                            TypeOfPayment = TypeOfPayment,
                            ArrivalTime = ArrivalTime,
                            PaymentStatus = PaymentStatus,

                            Comment = Comment,
                            AdressDilivery = AdressDilivery,
                            DateDilivery = DateDiliverySpb.Date,
                            DelivetyCost = 0,
                            ProccessingStatus = ProccessingStatus,
                            StartExecute = StartExecute,
                            TimeDilivery = TimeDiliverySpb,
                            TypeOfDelivery = TypeOfDeliverySpb,
                            TypeOfOffice = TypeOfOfficeSpb,
                            IsCompleted = false,
                            OrderProducts = OrderProductsVM1.ToList()
                             
                    });
                       
                        ProductContextVM.SaveChanges();
                        foreach (OrderProdust OrderProduct in OrderProductsVM1.ToList())
                        {
                            Product ProductV = OrderProduct.Product;
                            ProductV.PresenceOrderSpbs.Add(new PresenceOrderSpb { ChangeTime = DateTime.Now, Count = OrderProduct.Count, OrderSpb = ProductContextVM.OrdersSpb.Last() });
                            ProductContextVM.Products.First(x => x.Id == ProductV.Id).CurrentBalance -= OrderProduct.Count;
                            ProductContextVM.SaveChanges();
                        }

                        MessageBox.Show("Успешно сохранен заказ"); Clear();
                    }

            }


            else
            {
                    double result;
                    if (!double.TryParse(SendingCostRegion, out result))
                    {
                        MessageBox.Show("Ошибка: неверная цена доставки");
                    }

                    ProductContextVM.OrdersRegion.Add(new OrderRegion
                {
                    CustomerName = CustomerName,
                    CustomerAdress = CustomerAdress,
                    AdressDilivery = AdressDilivery,
                    ArrivalTime = ArrivalTime,
                    Comment = Comment,
                    CustomerEmail = CustomerEmail,
                    CustomerPhone = CustomerPhone,
                    DepartureDate = DepartureDateRegion.Date,
                    OrderProducts = OrderProductsVM1.ToList(),
                    RecipientFullName = RecipientFullName,
                    PaymentStatus = PaymentStatus,
                    ProccessingStatus = ProccessingStatus,
                    RecipientTelephone = RecipientTelephone,
                    SendingCost = result,
                    SendVariant = SendVariantRegion,
                    StartExecute = StartExecute,
                    TypeOfPacking = TypeOfPackingRegion,
                    TypeOfPayment = TypeOfPayment                 
                });


                ProductContextVM.SaveChanges();

                    foreach (OrderProdust OrderProduct in OrderProductsVM1.ToList())
                    {
                        Product ProductV = OrderProduct.Product;
                        ProductV.PresenceOrderRegions.Add(new PresenceOrderRegion{ ChangeTime = DateTime.Now, Count = OrderProduct.Count, OrderRegion=ProductContextVM.OrdersRegion.Last() });;
                        ProductContextVM.Products.First(x => x.Id == ProductV.Id).CurrentBalance -= OrderProduct.Count;
                        ProductContextVM.SaveChanges();
                    }

                    MessageBox.Show("Успешно сохранен заказ"); Clear();

                } }}



        public bool CanExecuteSaveCommand(object parameter)
        {
            if (OrderProductsVM1.Count > 0)
                return true;
            return false;
        }

        #endregion




        private RelayCommand _ValueUpdateCommand;
        public RelayCommand ValueUpdateCommand
        {
            get
            {
                if (_ValueUpdateCommand == null)
                    _ValueUpdateCommand = new RelayCommand(ExecuteValueUpdate, (x)=>true);
                return _ValueUpdateCommand;
            }
        }



        public void ExecuteValueUpdate(object parameter)
        {
            OnPropertyChanged("TotalVM"); OnPropertyChanged("TotalToPayVM");
        }



        private RelayCommand _SelectCourerCommand;
        public RelayCommand SelectCourerCommand
        {
            get
            {
                if (_SelectCourerCommand == null)
                    _SelectCourerCommand = new RelayCommand(ExecuteSelectCourer, CanExecuteSelectCourer);
                return _SelectCourerCommand;
            }
        }



        public void ExecuteSelectCourer(object parameter)
        {
            Window window = new ListCourerWindow() { DataContext = new ListCourersWindowViewModel(ProductContextVM,this) };
            window.Show();

        }


        public bool CanExecuteSelectCourer(object parameter)
        {

            return true;
        }










    }
}
