using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.ViewModels
{
   public class ListOrdersViewModel:ViewModelBase
    {

        public MainViewModel MainViewModel;
        public OneOrderViewModel OneOrderViewModel;

        private ObservableCollection<OrderSpb> order;
        public ObservableCollection<OrderSpb> OrdersSpb { get => order; set { order = value; OnPropertyChanged("OrdersSpb"); } }

        private ObservableCollection<OrderRegion> orderRegion;
        public ObservableCollection<OrderRegion> OrdersRegion { get => orderRegion; set { orderRegion = value; OnPropertyChanged("OrdersRegion"); } }

        private ObservableCollection<OrderSpb> ordersSpbDilivery;
        public ObservableCollection<OrderSpb> OrdersSpbDilivery { get { return new ObservableCollection<OrderSpb>(OrdersSpb.Where(x => x.TypeOfDelivery == Models.Enums.TypeOfDelivery.Delivery).ToList());  }
            set { ordersSpbDilivery = value; OnPropertyChanged("OrdersSpbDilivery"); } }




        private ObservableCollection<OrderSpb> ordersSpbPickUp;
        public ObservableCollection<OrderSpb> OrdersSpbPickUp { get {  return new ObservableCollection<OrderSpb>(OrdersSpb.Where(x => x.TypeOfDelivery == Models.Enums.TypeOfDelivery.Pickup).ToList()); }
            set { ordersSpbPickUp = value; OnPropertyChanged("OrdersSpbPickUp"); } }




        ProductContext ProductContextVM;
        public  ListOrdersViewModel(ProductContext productContext,MainViewModel mainViewModel )
        {
            var uu = productContext.OrderProdusts.ToList();
            ProductContextVM = productContext;
            OrdersSpb = new ObservableCollection<OrderSpb>(ProductContextVM.OrdersSpb.ToList());
            OrdersRegion = new ObservableCollection<OrderRegion>(ProductContextVM.OrdersRegion.ToList());


            MainViewModel = mainViewModel;

           OneOrderViewModel = MainViewModel.OneOrderViewModel;
            //OrdersSpbDilivery = new ObservableCollection<OrderSpb>(OrdersSpb.Where(x => x.TypeOfDelivery == Models.Enums.TypeOfDelivery.Delivery).ToList());
            // OrdersSpbPickUp = new ObservableCollection<OrderSpb>(OrdersSpb.Where(x => x.TypeOfDelivery == Models.Enums.TypeOfDelivery.Pickup).ToList());
            

        }




        private OrderRegion currentRegionOrder;
        public OrderRegion CurrentRegionOrder { get => currentRegionOrder; set { currentRegionOrder = value;OnPropertyChanged("CurrentRegionOrder"); } }

        private OrderSpb currentSpbOrder;
          public OrderSpb CurrentSpbOrder { get => currentSpbOrder; set { currentSpbOrder = value; OnPropertyChanged("CurrentSpbOrder"); } }


      public  void update()
        {

            OrdersSpb = new ObservableCollection<OrderSpb>(ProductContextVM.OrdersSpb.ToList());
            OrdersRegion = new ObservableCollection<OrderRegion>(ProductContextVM.OrdersRegion.ToList());
            OnPropertyChanged("OrdersSpbDilivery"); OnPropertyChanged("OrdersSpbPickUp");
        }


        private RelayCommand _EditCommand;

        public RelayCommand EditCommand
        {
            get

            {
                if (_EditCommand == null)
                    _EditCommand = new RelayCommand(ExecuteEditCommand, CanExecuteEditCommand);
                return _EditCommand;
            }

        }



        public void ExecuteEditCommand(object parameter)
        {
            if (parameter is OrderSpb)
            {

                var tt = ((OrderSpb)parameter);

                List<OrderProdust> orderProdusts = new List<OrderProdust>();

               foreach  (OrderProdust or in tt.OrderProducts)
                {
                    orderProdusts.Add(new OrderProdust { Product = or.Product, Id = or.Id, ProductId = or.ProductId, Count = or.Count });

                }



                var yy = parameter; 
                MainViewModel.OneOrderViewModel.ParseOrderSpb(tt);
                MainViewModel.OneOrderViewModel.IsEdding = true;
                MainViewModel.OneOrderViewModel.OldOrdersofOrder = orderProdusts;
                // MainViewModel.ExecuteClicOneCommand(null);
                MainViewModel.CurrentPage = MainViewModel.AddOrder;
            }

            if (parameter is OrderRegion)
            {

                var tt = ((OrderRegion)parameter);

                List<OrderProdust> orderProdusts = new List<OrderProdust>();

                foreach (OrderProdust or in tt.OrderProducts)
                {
                    orderProdusts.Add(new OrderProdust { Product = or.Product, Id = or.Id, ProductId = or.ProductId, Count = or.Count });

                }


                MainViewModel.OneOrderViewModel.ParseOrderRegion(parameter as OrderRegion);
                    MainViewModel.OneOrderViewModel.IsEdding = true;
                MainViewModel.OneOrderViewModel.OldOrdersofOrder = orderProdusts;
                MainViewModel.CurrentPage = MainViewModel.AddOrder;
                // MainViewModel.ExecuteClicOneCommand(null);
            }

        }

        public bool CanExecuteEditCommand(object parameter)
        {

            return true;
        }



    }
}
