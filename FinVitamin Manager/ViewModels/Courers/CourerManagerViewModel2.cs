using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinVitamin_Manager.ViewModels.Courers
{
    class CourerManagerViewModel:ViewModelBase, ICourerManagerViewModel
    {
        public ProductContext ProductContextVM { get; set; }

        public ListCourerViewModel ListCourerViewModel;
        public OneCourerViewModel OneCourerViewModel;
        public MainViewModel MainViewModel;

        public CourerManagerViewModel (Page p1, Page p2, ProductContext productContext,MainViewModel mainViewModel)
        {
            OneCourer = p1;
            ListCourers = p2;

            MainViewModel = mainViewModel;
            ListCourerViewModel =(ListCourerViewModel) p2.DataContext;
            OneCourerViewModel = (OneCourerViewModel)p1.DataContext;
            ProductContextVM = productContext;
        }

        private Page listCourers;
       public Page ListCourers { get => listCourers; set { listCourers = value; OnPropertyChanged("ListCourers"); } }

        private Page oneCourer;
        public Page OneCourer { get => oneCourer; set { oneCourer = value; OnPropertyChanged("OneCourer"); } }

        private Page currentPage;
        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged("CurrentPage"); } }



        private RelayCommand _ClicAddCommand;

        public RelayCommand ClicAddCommand
        {
            get

            {
                if (_ClicAddCommand == null)
                    _ClicAddCommand = new RelayCommand(ExecuteClicAddCommand, CanExecuteClicAddCommand);
                return _ClicAddCommand;
            }

        }

        public void ExecuteClicAddCommand(object parameter)
        {
            MainViewModel.CurrentPage = MainViewModel.CourerManager;
            MainViewModel.CurrentPage=MainViewModel.
            CurrentPage = OneCourer;
        }

        public bool CanExecuteClicAddCommand(object parameter)
        {
            return true;
        }


        public void ParseFromList(Courer courer)
        {
            OneCourerViewModel.Parse(courer);
            CurrentPage = OneCourer;
        }


        private RelayCommand _ClicListCourerCommand;

        public RelayCommand ClicListCourer
        {
            get

            {
                if (_ClicListCourerCommand == null)
                    _ClicListCourerCommand = new RelayCommand(ExecuteListCourerCommand, CanExecuteListCourerCommand);
                return _ClicListCourerCommand;
            }

        }

     

        public void ExecuteListCourerCommand(object parameter)
        {
            CurrentPage = ListCourers;
            MainViewModel.CurrentPage = MainViewModel.CourerManager;
            ListCourerViewModel.Update();
        }

        public bool CanExecuteListCourerCommand(object parameter)
        {
            return true;
        }


    }
}
