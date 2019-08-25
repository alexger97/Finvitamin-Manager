using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinVitamin_Manager.ViewModels
{
    class CourerAndInvoiceViewModel :ViewModelBase, ICourerAndInvoiceViewModel
    {

        public CourerAndInvoiceViewModel(Page p1, Page p2)
        {
            Courers = p1;
            Invoices = p2;
        }

      private Page currentPage;
      public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged("CurrentPage"); } }

      private Page courers;
     public Page Courers { get => courers; set { courers = value; OnPropertyChanged("Courers"); } }

      private Page invoices;
      public  Page Invoices { get => invoices; set { invoices = value; OnPropertyChanged("Invoices"); } }


        private RelayCommand _ClicCourersCommand;

        public RelayCommand ClicCourersCommand
        {
            get{
                if (_ClicCourersCommand == null)
                    _ClicCourersCommand = new RelayCommand(ExecuteClicCourersCommand, CanExecuteClicCourersCommand);
                return _ClicCourersCommand;
            }

        }

        public void ExecuteClicCourersCommand(object parameter)
        { CurrentPage = Courers; }

        public bool CanExecuteClicCourersCommand(object parameter) => true;


        private RelayCommand _ClicInvoicesCommand;

        public RelayCommand ClicInvoicesCommand
        {
            get
            {
                if (_ClicInvoicesCommand == null)
                    _ClicInvoicesCommand = new RelayCommand(ExecuteClicInvoicesCommand, CanExecuteClicInvoicesCommand);
                return _ClicInvoicesCommand;
            }

        }

        public void ExecuteClicInvoicesCommand(object parameter)
        { CurrentPage = Invoices; }

        public bool CanExecuteClicInvoicesCommand(object parameter) => true;





    }
}
