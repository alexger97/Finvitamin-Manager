using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.Models.Enums;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinVitamin_Manager.ViewModels
{
  public  class ProductManagerViewModel:ViewModelBase, IProductManagerViewModel
    {

        public MainViewModel MainViewModel;
       

        private bool addProduct;
        public bool AddProduct { get => addProduct; set {

                addProduct = value;
                if (value)
                {
                    ListProducts = false;
                }
                else { ListProducts = true; }

                OnPropertyChanged("AddProduct"); } }


        private bool isEdding;
        public bool IsEdding
        {
            get => isEdding; set
            {

                isEdding = value;
                

                OnPropertyChanged("IsEdding");
            }
        }

        private int selectIndexTab;
        public int SelectIndexTab { get => selectIndexTab; set { selectIndexTab = value; OnPropertyChanged("SelectIndexTab"); } }

   

        private bool listProducts;
        public bool ListProducts { get => listProducts; set { listProducts = value; OnPropertyChanged("ListProducts"); } }


        private Product currentProduct;

        public Product CurrentProduct { get => currentProduct; set { currentProduct = value; OnPropertyChanged("CurrentProduct"); } }

       public ObservableCollection<Product> Products { get { return new ObservableCollection<Product>(ProductContext.Products.ToList()); } }


        private ObservableCollection<PresenceOrderRegion> presenceOrderRegions;
        public ObservableCollection<PresenceOrderRegion> PresenceOrderRegions { get => presenceOrderRegions; set { presenceOrderRegions = value; OnPropertyChanged("PresenceOrderRegions"); } }

        private ObservableCollection<PresenceOrderSpb> presenceOrderSpbs;
        public ObservableCollection<PresenceOrderSpb> PresenceOrderSpbs { get => presenceOrderSpbs; set { presenceOrderSpbs = value; OnPropertyChanged("PresenceOrderSpbs"); } }

        private PresenceOrderRegion currentPresenceOrderRegion;
        public PresenceOrderRegion CurrentPresenceOrderRegion { get => currentPresenceOrderRegion; set { currentPresenceOrderRegion = value; OnPropertyChanged("CurrentPresenceOrderRegion"); } }

        private PresenceOrderSpb currentPresenceOrderSpb;
        public PresenceOrderSpb CurrentPresenceOrderSpb { get => currentPresenceOrderSpb; set { currentPresenceOrderSpb = value; OnPropertyChanged("CurrentPresenceOrderSpb"); } }
        void SetPresence (Product product)
        {

            PresenceOrderRegions = new ObservableCollection<PresenceOrderRegion>( product.PresenceOrderRegions);

            PresenceOrderSpbs = new ObservableCollection<PresenceOrderSpb>( product.PresenceOrderSpbs);
                   }



        #region Product
        private int id;
        public int Id { get => id; set { id = value; OnPropertyChanged("Id"); } }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }


        private string decsription;
        public string Decsription { get => decsription; set { decsription = value; OnPropertyChanged("Decsription"); } }

        private string weight;
        public string Weight { get => weight; set { weight = value; OnPropertyChanged("Weight"); } }

        private string purchasePrice;
        public string PurchasePrice { get => purchasePrice; set { purchasePrice = value; OnPropertyChanged("PurchasePrice"); } }

        private ProviderType providerType;
        public ProviderType ProviderType { get => providerType; set { providerType = value; OnPropertyChanged("ProviderType"); } }


        private string price;
        public string Price { get => price; set { price = value;OnPropertyChanged("Price"); } }

        private int currentBalance;
        public int CurrentBalance { get => currentBalance; set { currentBalance = value; OnPropertyChanged("CurrentBalance"); } }
        #endregion

        public ProductContext ProductContext;

        public ProductManagerViewModel(ProductContext productContext, MainViewModel mainViewModel)
        {
            ProductContext = productContext;
            MainViewModel = mainViewModel;
        }

        void Clear()
        {
            Name = Decsription = Weight = PurchasePrice = Price = "" ;

            CurrentBalance = 0; 
    }

        #region Commands
        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get

            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(ExecuteAddProductCommand, CanExecuteAddProductCommand);
                return _addCommand;
            }

        }



        public void ExecuteAddProductCommand(object parameter)
        {
            double WeightS;
            double PurchasePriceS;
            double PriceS;

            if(double.TryParse(Weight,out WeightS)&& double.TryParse(PurchasePrice, out PurchasePriceS)&& double.TryParse(Price, out PriceS))
            {
                if(IsEdding)
                {
                    ProductContext.Products.First(x => x.Id == Id).Decsription = Decsription;
                    ProductContext.Products.First(x => x.Id == Id).CurrentBalance = CurrentBalance;
                    ProductContext.Products.First(x => x.Id == Id).Name = Name;
                    ProductContext.Products.First(x => x.Id == Id).Price = PriceS;
                    ProductContext.Products.First(x => x.Id == Id).ProviderType = ProviderType;
                    ProductContext.Products.First(x => x.Id == Id).PurchasePrice = PurchasePriceS;
                    ProductContext.Products.First(x => x.Id == Id).Weight = WeightS;
                    ProductContext.SaveChanges();
                    MessageBox.Show("Товар успешно отредактирован");
                    Clear();
                }
                else
                {


                
                ProductContext.Products.Add(new Models.Product { Decsription = Decsription, Name = Name, CurrentBalance = CurrentBalance, Price = PriceS, ProviderType = ProviderType, PurchasePrice = PurchasePriceS, Weight = WeightS , PresenceOrderRegions=new List<PresenceOrderRegion>(), PresenceOrderSpbs= new List<PresenceOrderSpb>()});

                ProductContext.SaveChanges();
                MessageBox.Show("Товар успешно добавлен");
                    Clear();
                }
            }

            else
            {
                MessageBox.Show("Ошибка ввода числовых данных");
            }


        }

        public bool CanExecuteAddProductCommand(object parameter)
        {
            if((Name=="")||
               ( Decsription == "") ||(Weight=="")||
               (PurchasePrice=="")||
               (Price=="")||(CurrentBalance<1))
            return false;
            return true;
        }



        private RelayCommand _clicOneCommand;

        public RelayCommand ClicOneCommand
        {
            get

            {
                if (_clicOneCommand == null)
                    _clicOneCommand = new RelayCommand(ExecuteClicOneCommand, CanExecuteClicOneCommand);
                return _clicOneCommand;
            }

        }



        public void ExecuteClicOneCommand(object parameter)
        {
            MainViewModel.CurrentPage = MainViewModel.PageThird;
            IsEdding = false;
            AddProduct = false;
            AddProduct = true;
            SelectIndexTab = 0;
            Clear();

        }

        public bool CanExecuteClicOneCommand(object parameter)
        {
          
            return true;
        }
        private RelayCommand _clicTwoCommand;

        public RelayCommand ClicTwoCommand
        {
            get

            {
                if (_clicTwoCommand == null)
                    _clicTwoCommand = new RelayCommand(ExecuteClicTwoCommand, CanExecuteClicTwoCommand);
                return _clicTwoCommand;
            }

        }



        public void ExecuteClicTwoCommand(object parameter)
        {

            AddProduct = false;
            OnPropertyChanged("Products");
            MainViewModel.CurrentPage = MainViewModel.PageThird;

        }

        public bool CanExecuteClicTwoCommand(object parameter)
        {

            return true;
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

           

            Clear();
            AddProduct = true;
            IsEdding = true;
            Id = CurrentProduct.Id;
            Name = CurrentProduct.Name;
            Decsription = CurrentProduct.Decsription;
            Weight = CurrentProduct.Weight.ToString();
            PurchasePrice = CurrentProduct.PurchasePrice.ToString();
            ProviderType = CurrentProduct.ProviderType;
            Price = CurrentProduct.Price.ToString();
            CurrentBalance = CurrentProduct.CurrentBalance;
            SetPresence(CurrentProduct);
            SelectIndexTab = 1;


        }

        public bool CanExecuteEditCommand(object parameter)
        {

            if ( CurrentProduct==null) { return false; }
            return true;
        }



        private RelayCommand _OpenOrderCommand;

        public RelayCommand OpenOrderCommand
        {
            get

            {
                if (_OpenOrderCommand == null)
                    _OpenOrderCommand = new RelayCommand(ExecuteOpenOrderCommand, CanExecuteOpenOrderCommand);
                return _OpenOrderCommand;
            }

        }



        public void ExecuteOpenOrderCommand(object parameter)
        {

           
        }

        public bool CanExecuteOpenOrderCommand(object parameter)
        {
            //  if (CurrentPresenceOrderRegion != null)
            return true;
           // return false;


        }




        #endregion
    }
}
