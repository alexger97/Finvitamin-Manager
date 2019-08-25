using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
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
   public class ListProductsViewModel:ViewModelBase
    {
        public ProductContext ProductContextVM;
        public ObservableCollection<Product> Products { get { return new ObservableCollection<Product>(ProductContextVM.Products.ToList()); }  }

        OneOrderViewModel OneOrderViewModel;

        private Product currentproduct;
        public Product CurrentProduct { get => currentproduct; set { currentproduct = value; OnPropertyChanged("CurrentProduct"); } }

        
        public ListProductsViewModel(OneOrderViewModel oneOrderView,ProductContext  productContext)
        {

            OneOrderViewModel = oneOrderView;
            ProductContextVM = productContext;
        }




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
        {if (OneOrderViewModel.OrderProductsVM1.ToList().Find(x=>x.Product.Id==CurrentProduct.Id)==null)
            {
                OneOrderViewModel.OrderProductsVM1.Add(new OrderProdust { Product = CurrentProduct, Count = 1 });
                OneOrderViewModel.update();
            }
            else { MessageBox.Show("Товар уже присутствует в заказе!"); }
           

        }

        public bool CanExecuteAddClientCommand(object parameter)
        {

            if (CurrentProduct != null) return true;

            return false;



        }







    }
}
