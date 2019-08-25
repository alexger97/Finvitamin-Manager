using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.Models;
using FinVitamin_Manager.ViewModels.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinVitamin_Manager.ViewModels.Invoices
{
   public class OneInvoiceViewModel : ViewModelBase
    {
        public InvoicesManagerViewModel InvoicesManagerViewModelVM;
        public OneInvoiceViewModel(IInvoicesManagerViewModel InvoicesManagerViewModel)
        {
            InvoicesManagerViewModelVM = (InvoicesManagerViewModel) InvoicesManagerViewModel;
            SelectTaskForInvoice = new ObservableCollection<CourerTask>();
            DateOfDilivery = DateTime.Now;
            SelectTaskForInvoice.CollectionChanged += SelectTaskForInvoice_CollectionChanged;
        }

        private void SelectTaskForInvoice_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("SummWithoutDilivery");
            OnPropertyChanged("SummDiliveryCost");
            OnPropertyChanged("SummTotal");
        }

        private bool isEding;
        public bool IsEding
        {
            get => isEding; set
            {
                isEding = value; OnPropertyChanged("IsEding"); OnPropertyChanged("HeadText"); OnPropertyChanged("SaveText");
            }
        }

        public bool EnabledEnding { get { if (InvoiceForCourerEdit != null) { return InvoiceForCourerEdit.IsEnded; } return false; } }

        private InvoiceForCourer invoiceForCourerEdit;
        public InvoiceForCourer InvoiceForCourerEdit { get => invoiceForCourerEdit; set { invoiceForCourerEdit = value; if (value != null) IsEding = true; OnPropertyChanged("CurrentCourerIFC"); OnPropertyChanged("InvoiceForCourerEdit"); OnPropertyChanged("DateOfDilivery"); OnPropertyChanged("EnabledEnding"); } }

        private string headText;

        public string HeadText
        {
            get
            {
                if (IsEding) { headText = "Редактирование путевого листа"; }

                else { headText = "Добавление нового путевого листа"; }
                return headText;
            }
            set { headText = value; OnPropertyChanged("HeadText"); }
        }

        private string saveText;

        public string SaveText
        {
            get
            {
                if (IsEding) { saveText = "Сохраненить измненения"; }

                else { saveText = "Сохранить новый путевой лист"; }
                return saveText;
            }
            set { saveText = value; OnPropertyChanged("SaveText"); }
        }

        public ObservableCollection<Courer> Courers
        {
            get =>new ObservableCollection<Courer>(InvoicesManagerViewModelVM.ProductContextVM.Courers);
        }



        static InvoiceForCourer FackeNewInvoice = new InvoiceForCourer { Id = -1 };

        private Courer courerIFC;
        public Courer CurrentCourerIFC
        {
            get { if (IsEding) { courerIFC = InvoiceForCourerEdit.WorkCourer; } return courerIFC; }
            set
            {
                courerIFC = value;

                foreach (var item in SelectTaskForInvoice)
                {
                    item.InvoiceForCourer = null;
                }
                SelectTaskForInvoice.Clear();

                OnPropertyChanged("SelectTaskForInvoice");
                OnPropertyChanged("CurrentCourerIFC");
                OnPropertyChanged("CourerTasksForInvoice");
            }
        }


        private DateTime dateOfDilivery;
        public DateTime DateOfDilivery { get { if (IsEding) { dateOfDilivery = InvoiceForCourerEdit.DataForInvoice; } return dateOfDilivery; } set { dateOfDilivery = value; OnPropertyChanged("DateOfDilivery"); OnPropertyChanged("CourerTasksForInvoice"); OnPropertyChanged("CourerTasksForInvoice"); } }

        public ObservableCollection<CourerTask> CourerTasksForInvoice
        {
            get
            {
                if (CurrentCourerIFC != null)
                    return new ObservableCollection<CourerTask>(CurrentCourerIFC.DiliveryOrders.Where(x => x.InvoiceForCourer == null && x.IsCompleted == false && x.DateDilivery.Date == DateOfDilivery.Date)); return null;
            }
        }



        private CourerTask courerTaskSelect;
        public CourerTask CourerTaskSelect { get => courerTaskSelect; set { courerTaskSelect = value; OnPropertyChanged("CourerTaskSelect"); } }

        private CourerTask courerTaskInvoice;
        public CourerTask CourerTaskinInvoice { get => courerTaskInvoice; set { courerTaskInvoice = value; OnPropertyChanged("CourerTaskinInvoice"); } }

        private ObservableCollection<CourerTask> selectTaskForInvoice;
        public ObservableCollection<CourerTask> SelectTaskForInvoice { get => selectTaskForInvoice; set { selectTaskForInvoice = value; OnPropertyChanged("SelectTaskForInvoice"); } }


        private InvoiceForCourer invoiceFor;

        public InvoiceForCourer SelectInvoiceForCourer { get => invoiceFor; set { invoiceFor = value; OnPropertyChanged("SelectInvoiceForCourer"); } }


        private RelayCommand _InvoiceSaveCommand;
        public RelayCommand InvoiceSaveCommand
        {
            get

            {
                if (_InvoiceSaveCommand == null)
                    _InvoiceSaveCommand = new RelayCommand(ExecuteInvoiceSaveCommand, CanExecuteInvoiceSaveCommand);
                return _InvoiceSaveCommand;
            }

        }

        

        public double SummWithoutDilivery { get { if (SelectTaskForInvoice != null) { return SelectTaskForInvoice.Select(x => x.SummWithoutDilivery).ToArray().Sum(); } else return 0; } }

        public double SummDiliveryCost { get { if (SelectTaskForInvoice != null) { return SelectTaskForInvoice.Select(x => x.DelivetyCost).ToArray().Sum(); } else return 0; } }

        public double SummTotal { get { if (SelectTaskForInvoice != null) { return SelectTaskForInvoice.Select(x => x.SummTotal).ToArray().Sum(); } else return 0; } }


        private bool ending;
        public bool Ending { get => ending; set { ending = value;  OnPropertyChanged("Ending"); }  }










        public void ExecuteInvoiceSaveCommand(object parameter)
        {
            if (!IsEding)
            {
                var tt = new InvoiceForCourer { WorkCourer = CurrentCourerIFC, DataForInvoice = DateOfDilivery };
                var CourerTasks = SelectTaskForInvoice.ToList();
                foreach (var item in CourerTasks)
                {
                    item.InvoiceForCourer = tt;
                }
                //ProductContextVM.InvoiceForCourers.Last().CourerTasks = CourerTasks;
                InvoicesManagerViewModelVM.ProductContextVM.SaveChanges();
                SelectTaskForInvoice.Clear();
                MessageBox.Show("Путевой лист успешно сохранен");

            }
            else
            {
                InvoiceForCourerEdit.CourerTasks = SelectTaskForInvoice.ToList();

                if (Ending)
                {
                    MessageBoxResult result = MessageBox.Show($"Внимание!! Вы завершаете путевой лист, при сохранении измененений все заказы путевого листа будут отмеченены выполненными.\n Проверьте получение от курьера {SummWithoutDilivery} рублей  ", "Внимание! Заверешение путевого листа", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        foreach (var tt in SelectTaskForInvoice.Select(x => x.OrderSpb)) { tt.IsCompleted = true; }
                    }



                   
                }

                InvoicesManagerViewModelVM.ProductContextVM.SaveChanges();
                MessageBox.Show("Путевой лист отредактирован");
                SelectTaskForInvoice.Clear();
                InvoicesManagerViewModelVM.ToList();
            }

        }


        public bool CanExecuteInvoiceSaveCommand(object parameter) { if (SelectTaskForInvoice.Count > 0) return true; return false; }



        private RelayCommand _InvoiceAddCourerTaskCommand;
        public RelayCommand InvoiceAddCourerTaskCommand
        {
            get
            {
                if (_InvoiceAddCourerTaskCommand == null)
                    _InvoiceAddCourerTaskCommand = new RelayCommand(ExecuteInvoiceAddCourerTaskCommand, CanExecuteInvoiceAddCourerTaskCommand);
                return _InvoiceAddCourerTaskCommand;
            }

        }


        public void ExecuteInvoiceAddCourerTaskCommand(object parameter)
        {
            SelectTaskForInvoice.Add(CourerTaskSelect);
            if (!IsEding)
                CourerTaskSelect.InvoiceForCourer = FackeNewInvoice;
            else { CourerTaskSelect.InvoiceForCourer = InvoiceForCourerEdit; }
            OnPropertyChanged("CourerTasksForInvoice");
            OnPropertyChanged("SelectTaskForInvoice");
        }

        public bool CanExecuteInvoiceAddCourerTaskCommand(object parameter)
        {
            if (CourerTaskSelect != null) return true;
            return false;
        }

        private RelayCommand _InvoiceDelCourerTaskCommand;
        public RelayCommand InvoiceDelCourerTaskCommand
        {
            get
            {
                if (_InvoiceDelCourerTaskCommand == null)
                    _InvoiceDelCourerTaskCommand = new RelayCommand(ExecuteInvoiceDelCourerTaskCommand, CanExecuteInvoiceDelCourerTaskCommand);
                return _InvoiceDelCourerTaskCommand;
            }

        }


        public void ExecuteInvoiceDelCourerTaskCommand(object parameter)
        {
            CourerTaskinInvoice.InvoiceForCourer = null;
            SelectTaskForInvoice.Remove(CourerTaskinInvoice);

            OnPropertyChanged("CourerTasksForInvoice");
            OnPropertyChanged("SelectTaskForInvoice");


        }

        public bool CanExecuteInvoiceDelCourerTaskCommand(object parameter)
        {
            if (CourerTaskinInvoice != null) return true;
            return false;
        }




        public void ParseIvoice(InvoiceForCourer invoiceForCourer) {
            InvoiceForCourerEdit = invoiceForCourer;
            SelectTaskForInvoice.Clear();
            Ending = invoiceForCourer.IsEnded;
            foreach (var tt in InvoiceForCourerEdit.CourerTasks)
                SelectTaskForInvoice.Add(tt);
            //SelectTaskForInvoice = new ObservableCollection<CourerTask>(InvoiceForCourerEdit.CourerTasks);
        }
        public void Clear()
        {
            if (InvoiceForCourerEdit != null)
                UndoChanges();
            OnPropertyChanged("Courers");
            InvoiceForCourerEdit = null; Ending = false; IsEding = false; SelectInvoiceForCourer = null; SelectTaskForInvoice.Clear(); DateOfDilivery = DateTime.Now;
        }



        void UndoChanges()
        {
            InvoicesManagerViewModelVM.ProductContextVM.ChangeTracker.DetectChanges();

            //get all entries that are changed
            var entries = InvoicesManagerViewModelVM.ProductContextVM.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();

            //somehow try to discard changes on every entry
            foreach (var dbEntityEntry in entries)
            {
                var entity = dbEntityEntry.Entity;

                if (entity == null) continue;
                if (dbEntityEntry.State == EntityState.Modified)
                {

                    dbEntityEntry.Reload();
                }

            }

        }
    }
}
