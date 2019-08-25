using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.Models;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinVitamin_Manager.ViewModels.Invoices
{
 public   class ListInvoicesViewModel:ViewModelBase
    {
       public InvoicesManagerViewModel InvoicesManagerViewModel;
        public ListInvoicesViewModel(IInvoicesManagerViewModel invoicesManagerViewModel)
        {
            InvoicesManagerViewModel = (InvoicesManagerViewModel)invoicesManagerViewModel;
            DateTime = DateTime.Now.Date;
        }

        private InvoiceForCourer currentInvoice;
        public InvoiceForCourer CurrentInvoice { get => currentInvoice; set { currentInvoice = value; OnPropertyChanged("CurrentInvoice"); } }

        public ObservableCollection<InvoiceForCourer> AllInvoice { get => new ObservableCollection<InvoiceForCourer>(InvoicesManagerViewModel.ProductContextVM.InvoiceForCourers.ToList()); }

        public ObservableCollection<Courer> ListCourers { get => new ObservableCollection<Courer>(InvoicesManagerViewModel.ProductContextVM.Courers); }

        #region Filters
        private bool isEnded;

        public bool IsEnded { get => isEnded; set { isEnded = value; OnPropertyChanged("IsEnded"); OnPropertyChanged("FillterCollection"); } }

        private bool useOneData;
        public bool UseOneData { get => useOneData; set { useOneData = value; OnPropertyChanged("UseOneData"); OnPropertyChanged("FillterCollection"); } }

        private bool useOneCourer;
        public bool UseOneCourer { get => useOneCourer; set { useOneCourer = value; OnPropertyChanged("UseOneCourer"); OnPropertyChanged("FillterCollection"); } }


        private Courer selectedCourer;
        public Courer SelectedCourer { get => selectedCourer; set { selectedCourer = value;OnPropertyChanged("SelectedCourer"); OnPropertyChanged("FillterCollection"); } }

        private DateTime dataFilter;
        public DateTime DateTime { get => dataFilter; set { dataFilter = value; OnPropertyChanged("DateTime"); OnPropertyChanged("FillterCollection");  } }


        public ObservableCollection<InvoiceForCourer> FillterCollection { get
            {
                 IEnumerable<InvoiceForCourer> invoicies = AllInvoice;
                if (UseOneData) 
                    invoicies =  invoicies.Where(x => x.DataForInvoice.Date == DateTime.Date);   
                if (UseOneCourer) invoicies = invoicies.Where(x=>x.WorkCourer == SelectedCourer);

                if (IsEnded) invoicies = invoicies.Where(x => x.IsEnded == true);

                return new ObservableCollection<InvoiceForCourer>(invoicies);
            } }

        #endregion







        private RelayCommand _InvoiceEditCommand;
        public RelayCommand InvoiceEditCommand
        {
            get

            {
                if (_InvoiceEditCommand == null)
                    _InvoiceEditCommand = new RelayCommand(ExecuteInvoiceEditCommand, CanExecuteInvoiceEditCommand);
                return _InvoiceEditCommand;
            }

        }



        public void ExecuteInvoiceEditCommand(object parameter)
        {
            InvoicesManagerViewModel.EditInvoice(CurrentInvoice);
        }

        public bool CanExecuteInvoiceEditCommand(object parameter) { if (CurrentInvoice != null) return true; return false; }



        public void Update()
        {
            OnPropertyChanged("AllInvoice");
            OnPropertyChanged("ListCourer");
            OnPropertyChanged("FillterCollection");


        }

        private RelayCommand _InvoiceDeleteCommand;
        public RelayCommand InvoiceDeleteCommand
        {
            get

            {
                if (_InvoiceDeleteCommand == null)
                    _InvoiceDeleteCommand = new RelayCommand(ExecuteInvoiceDeleteCommand, CanExecuteInvoiceDeleteCommand);
                return _InvoiceDeleteCommand;
            }

        }



        public void ExecuteInvoiceDeleteCommand(object parameter)
        {

            MessageBoxResult result = MessageBox.Show( "Все заказы будут отмечены как необработанные", "Вы действительно хотите удалить путевой лист?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                foreach (var item in CurrentInvoice.CourerTasks)
                {
                    item.InvoiceForCourer = null;
                }
                InvoicesManagerViewModel.ProductContextVM.SaveChanges();

                MessageBox.Show("Путевой лист успешно был удален");

                InvoicesManagerViewModel.ProductContextVM.InvoiceForCourers.Remove(CurrentInvoice);
                InvoicesManagerViewModel.ProductContextVM.SaveChanges();
                OnPropertyChanged("AllInvoice");
            }



        }


        public bool CanExecuteInvoiceDeleteCommand(object parameter)
        {
            if (CurrentInvoice != null) return true; return false;
        }
    }
}
