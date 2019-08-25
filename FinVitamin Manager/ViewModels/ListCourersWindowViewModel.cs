using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.Service;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.ViewModels
{
    class ListCourersWindowViewModel:ViewModelBase
    {
        OneOrderViewModel CurrentVM;
        CourerTaskManager CourerTask;
        public ListCourersWindowViewModel(ProductContext productContext, OneOrderViewModel oneOrderViewModel)
        {
            ProductContextVM = productContext;
            CurrentVM = oneOrderViewModel;
            CourerTask = new CourerTaskManager(ProductContextVM);
        }


        public ProductContext ProductContextVM;


        public ObservableCollection<Courer> Courers { get { return new ObservableCollection<Courer>(ProductContextVM.Courers.ToList()); } }



        private Courer courer;

        public Courer Courer { get => courer; set { courer = value; OnPropertyChanged("Courer"); } }


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

            CurrentVM.CourerTask = new CourerTask { Courer = Courer };        }


        public bool CanExecuteSelectCourer(object parameter)
        {

          if(Courer!=null)  return true;
            return false;
        }


    }
}
