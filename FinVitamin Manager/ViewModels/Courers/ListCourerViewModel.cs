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

namespace FinVitamin_Manager.ViewModels.Courers
{
  public  class ListCourerViewModel : ViewModelBase
    {
        public ICourerManagerViewModel CourerManagerViewModel2;

        public ListCourerViewModel(ICourerManagerViewModel courerManagerViewModel2)
        {
            CourerManagerViewModel2 =(CourerManagerViewModel) courerManagerViewModel2;
        }
        public ObservableCollection<Courer> Courers
        {
            get
            {
                if (CourerManagerViewModel2.ProductContextVM.Courers.ToList() != null) return new ObservableCollection<Courer>(CourerManagerViewModel2.ProductContextVM.Courers.ToList());
                else { return new ObservableCollection<Courer>(); }
            }
        }
        private Courer courer;
        public Courer CurrentCourer { get => courer; set { courer = value; OnPropertyChanged("CurrentCourer"); } }


        private RelayCommand _CourerDeleteCommand;
        public RelayCommand CourerDeleteCommand
        {
            get

            {
                if (_CourerDeleteCommand == null)
                    _CourerDeleteCommand = new RelayCommand(ExecuteCourerDeleteCommand, CanExecuteCourerDeleteCommand);
                return _CourerDeleteCommand;
            }

        }



        public void ExecuteCourerDeleteCommand(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить курьера ", "Все данные о курьере будут удалены", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {



                CourerManagerViewModel2.ProductContextVM.Remove(CurrentCourer); CourerManagerViewModel2.ProductContextVM.SaveChanges();
                OnPropertyChanged("Courers");
                MessageBox.Show("Удаление курьера завершено");
            }
        }



        public bool CanExecuteCourerDeleteCommand(object parameter) { if (CurrentCourer != null) return true; return false; }



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
            CourerManagerViewModel2.ParseFromList(CurrentCourer);
           
        }

        public bool CanExecuteEditCommand(object parameter)
        {
            if (CurrentCourer != null)
            {
                return true;
            }

            return false;


        }

        public void Update()
        {
            OnPropertyChanged("Courers");
        }
    }
}
