using FinVitamin_Manager.Interafce;
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

namespace FinVitamin_Manager.ViewModels.Invoices
{
 public   class InvoicesManagerViewModel : ViewModelBase, IInvoicesManagerViewModel
    {
        public ProductContext ProductContextVM;

        public OneInvoiceViewModel OneInvoiceVM;

        public ListInvoicesViewModel ListInvoicesViewModel;
        public MainViewModel MainViewModel;
        public InvoicesManagerViewModel(Page p1, Page p2, ProductContext productContext, MainViewModel mainViewModel)
        {
            OneInvoice = p1;

            MainViewModel = mainViewModel;
            OneInvoiceVM = ((OneInvoiceViewModel)p1.DataContext);
            ListInvoices = p2;
            ListInvoicesViewModel= ((ListInvoicesViewModel)p2.DataContext);
            ProductContextVM = productContext;
        }
       


        private Page oneInvoice;
        public Page OneInvoice { get => oneInvoice; set { oneInvoice = value; OnPropertyChanged("OneInvoice"); } }

        private Page listInvoices;
        public Page ListInvoices { get => listInvoices; set { listInvoices = value; OnPropertyChanged("ListInvoices"); } }



        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged("CurrentPage"); } }


        private RelayCommand _InvoiceAddCommand;
        public RelayCommand InvoiceAddCommand
        {
            get
            {
                if (_InvoiceAddCommand == null)
                    _InvoiceAddCommand = new RelayCommand(ExecuteInvoiceAddCommand, CanExecuteInvoiceAddCommand);
                return _InvoiceAddCommand;
            }

        }



        public void ExecuteInvoiceAddCommand(object parameter)
        {
            if (OneInvoiceVM.IsEding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование путевого листа? Изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    MainViewModel.CurrentPage = MainViewModel.CourerManager;
                    OneInvoiceVM.Clear(); CurrentPage = OneInvoice;
                }
            }
            else { MainViewModel.CurrentPage = MainViewModel.InvoiceManager; OneInvoiceVM.Clear(); CurrentPage = OneInvoice; }
            
            
        }

        public bool CanExecuteInvoiceAddCommand(object parameter)
        {
            return true;
        }


        private RelayCommand _InvoiceListCommand;
        public RelayCommand InvoiceListCommand
        {
            get

            {
                if (_InvoiceListCommand == null)
                    _InvoiceListCommand = new RelayCommand(ExecuteInvoiceListCommand, CanExecuteInvoiceListCommand);
                return _InvoiceListCommand;
            }

        }

        public void ToList()
        {
            CurrentPage = ListInvoices;
            ListInvoicesViewModel.Update();
        }

        public void ExecuteInvoiceListCommand(object parameter) {


            if (OneInvoiceVM.IsEding)
            {
                MessageBoxResult result = MessageBox.Show("Прекратить редактирование путевого листа? Изменения не сохранятся", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    MainViewModel.CurrentPage = MainViewModel.CourerManager;
                    CurrentPage = ListInvoices;
                    ListInvoicesViewModel.Update();
                }
            }
            else { MainViewModel.CurrentPage = MainViewModel.InvoiceManager;
                CurrentPage = ListInvoices; ListInvoicesViewModel.Update() ; }
             }

        public bool CanExecuteInvoiceListCommand(object parameter) => true;


        public void EditInvoice (InvoiceForCourer  invoice)
            {
            OneInvoiceVM.ParseIvoice(invoice);
            CurrentPage = OneInvoice;
            }




    }
}
