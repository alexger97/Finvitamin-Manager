using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.ViewModels.Command;
using FinVitamin_Manager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using FinVitamin_Manager.ViewModels.Courers;
using FinVitamin_Manager.ViewModels.Invoices;
using FinVitamin_Manager.Views.Courers;
using FinVitamin_Manager.Views.Invoices;
using FinVitamin_Manager.Interafce;

namespace FinVitamin_Manager.ViewModels
{
   public class MainViewModel: ViewModelBase, IMainViewModel
    {

        
        private Page currentpage;
      public   Page CurrentPage { get => currentpage; set { currentpage = value; OnPropertyChanged("CurrentPage"); } }

        public ProductContext ProductContextVM;
        public OneOrderViewModel OneOrderViewModel;
        public ListOrdersViewModel ListOrdersViewModel;
        public ProductManagerViewModel ProductManagerViewModel { get; set; }




        public ICourerManagerViewModel CourerManagerViewModel { get; set; }
        public ListCourerViewModel ListCourerViewModel;
        public OneCourerViewModel OneCourerViewModel;


        public IInvoicesManagerViewModel InvoicesManagerViewModel { get; set; }
        public ListInvoicesViewModel ListInvoicesViewModel;
        public OneInvoiceViewModel OneInvoiceViewModel;

        
      public  Page AddOrder;
        public Page ListOrder;
        public  Page PageThird;
        public Page StartPage;


       

        public Page CourerManager;
        public Page InvoiceManager;

        public Page AddCourer;
        public Page ListCourer;


        public Page AddInvoice;
        public Page ListInvoice;





        public MainViewModel(ProductContext productContext)
        {
            ProductContextVM = productContext;

            ListOrdersViewModel = new ListOrdersViewModel(ProductContextVM, this);
            OneOrderViewModel = new OneOrderViewModel(ProductContextVM);         
            ProductManagerViewModel = new ProductManagerViewModel(ProductContextVM,this);

            //Курьеры VM
           
            OneCourerViewModel = new OneCourerViewModel(CourerManagerViewModel);
            ListCourerViewModel = new ListCourerViewModel(CourerManagerViewModel);

            //Курьеры View
            ListCourer = new ListCourersView() { DataContext = ListCourerViewModel };
            AddCourer = new OneCourerView() { DataContext = OneCourerViewModel };
CourerManagerViewModel = new CourerManagerViewModel(AddCourer, ListCourer, ProductContextVM,this);
            OneCourerViewModel.CourerManagerViewModel2 = CourerManagerViewModel;
            ListCourerViewModel.CourerManagerViewModel2 = CourerManagerViewModel;

            CourerManager = new CourersManagerView() { DataContext = CourerManagerViewModel };
   //Invoices VM
            OneInvoiceViewModel = new OneInvoiceViewModel(InvoicesManagerViewModel);
            ListInvoicesViewModel = new ListInvoicesViewModel(InvoicesManagerViewModel);
  //Invoices View
            AddInvoice = new OneInvoice() { DataContext= OneInvoiceViewModel };
            ListInvoice = new InvoicesListView() { DataContext= ListInvoicesViewModel };
   InvoicesManagerViewModel = new InvoicesManagerViewModel(AddInvoice, ListInvoice, ProductContextVM,this);
            InvoiceManager = new InvoiceManagerView() { DataContext= InvoicesManagerViewModel };
            OneInvoiceViewModel.InvoicesManagerViewModelVM = (InvoicesManagerViewModel)InvoicesManagerViewModel;
            ListInvoicesViewModel.InvoicesManagerViewModel = (InvoicesManagerViewModel)InvoicesManagerViewModel;







           

            


            AddOrder = new OrderOneView() { DataContext = OneOrderViewModel };

            ListOrder = new ListOrders() { DataContext = ListOrdersViewModel };

            PageThird = new ProductManagerView() { DataContext = ProductManagerViewModel };

            StartPage = new StartView();

          
            CurrentPage = StartPage;
          
        }



        private RelayCommand _ClicOneCommand;

        public RelayCommand ClicOneCommand
        {
            get

            {
                if (_ClicOneCommand == null)
                    _ClicOneCommand = new RelayCommand(ExecuteClicOneCommand, CanExecuteClicOneCommand);
                return _ClicOneCommand;
            }

        }



        public void ExecuteClicOneCommand(object parameter)
        {
            if( OneOrderViewModel.IsEdding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование заказа, изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    OneOrderViewModel.Clear();
                    CurrentPage = AddOrder;
                }
            }
            else
            {
               CurrentPage = AddOrder;
                //CurrentPage = StartPage;
                OneOrderViewModel.Clear();
            }

            
            //OneOrderViewModel.Clear();
          //  OneOrderViewModel.IsEdding = false;
        }

        public bool CanExecuteClicOneCommand(object parameter)
        {
                return true;
        }



        private RelayCommand _ClicTwoCommand;

        public RelayCommand ClicTwoCommand
        {
            get
            {
                if (_ClicTwoCommand == null)
                    _ClicTwoCommand = new RelayCommand(ExecuteClicTwoCommand, CanExecuteClicTwoCommand);
                return _ClicTwoCommand;
            }

        }
        public void ExecuteClicTwoCommand(object parameter)
        {
            if (OneOrderViewModel.IsEdding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование заказа, изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    OneOrderViewModel.Clear();
                    CurrentPage = ListOrder;
                }
            }
            else
            {
                CurrentPage = ListOrder;
            }
            ListOrdersViewModel.update();
        }

        public bool CanExecuteClicTwoCommand(object parameter)
        {
            return true;
        }

        private RelayCommand _ClicThirdCommand;

        public RelayCommand ClicThirdCommand
        {
            get

            {
                if (_ClicThirdCommand == null)
                    _ClicThirdCommand = new RelayCommand(ExecuteClicThirdCommand, CanExecuteClicThirdCommand);
                return _ClicThirdCommand;
            }

        }



        public void ExecuteClicThirdCommand(object parameter)
        {
            if (OneOrderViewModel.IsEdding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование заказа, изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    OneOrderViewModel.Clear();
                    CurrentPage = PageThird;
                }
            }
            else
            {
                CurrentPage = CourerManager;
            }
        }

        public bool CanExecuteClicThirdCommand(object parameter)
        {
            return true;
        }

        private RelayCommand _ClicFourthCommand;

        public RelayCommand ClicFourthCommand
        {
            get
            {
                if (_ClicFourthCommand == null)
                    _ClicFourthCommand = new RelayCommand(ExecuteClicFourthCommand, CanExecuteClicFourthCommand);
                return _ClicFourthCommand;
            }

        }

    

        public void ExecuteClicFourthCommand(object parameter)
        {
            if (OneOrderViewModel.IsEdding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование заказа, изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    OneOrderViewModel.Clear();
                    CurrentPage = InvoiceManager;
                }
            }
            else
            {
                CurrentPage = InvoiceManager;
            }
            
        }

        public bool CanExecuteClicFourthCommand(object parameter)
        {
            return true;
        }




        private RelayCommand _ClicFiveCommand;

        public RelayCommand ClicFiveCommand
        {
            get
            {
                if (_ClicFiveCommand == null)
                    _ClicFiveCommand = new RelayCommand(ExecuteClicFiveCommand, CanExecuteClicFiveCommand);
                return _ClicFiveCommand;
            }

        }



        public void ExecuteClicFiveCommand(object parameter)
        {
            if (OneOrderViewModel.IsEdding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование заказа, изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    OneOrderViewModel.Clear();
                    CurrentPage = PageThird;
                }
            }
            else
            {
                CurrentPage = PageThird;
            }

        }

        public bool CanExecuteClicFiveCommand(object parameter)
        {
            return true;
        }









    }
}
