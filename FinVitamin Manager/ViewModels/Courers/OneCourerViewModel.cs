using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Enums;
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
  public  class OneCourerViewModel:ViewModelBase
    {
        private bool isEding;
        public bool IsEding { get => isEding; set { isEding = value; OnPropertyChanged("IsEding"); } }

        public ICourerManagerViewModel CourerManagerViewModel2;

        public OneCourerViewModel(ICourerManagerViewModel courerManagerViewModel2)
        {
            CourerManagerViewModel2 = courerManagerViewModel2;
            DateOfBirdth = DateTime.Parse("01/01/1970");
        }


        private Courer courer;
        public Courer CurrentCourer { get => courer; set { courer = value;
                OnPropertyChanged("CurrentCourer");
                OnPropertyChanged("EndedOrders");
                OnPropertyChanged("EarnMoney");
                OnPropertyChanged("OrdersinWork");
                OnPropertyChanged("CourerTask");
                if (value != null) IsEding = true;
            } }

        private int id;
        public int Id { get => id; set { id = value; OnPropertyChanged("Id"); } }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }

        private int age;
        public int Age { get => age; set { age = value; OnPropertyChanged("Age"); } }

        private string vk;
        public string Vk { get => vk; set { vk = value; OnPropertyChanged("Vk"); } }

        private MetroStation metro;
        public MetroStation Metro { get => metro; set { metro = value; OnPropertyChanged("Metro"); } }

        private bool haveCar;
        public bool HaveCar { get => haveCar; set { haveCar = value; OnPropertyChanged("HaveCar"); } }

        private DateTime dateOfBirth;
        public DateTime DateOfBirdth { get => dateOfBirth; set { dateOfBirth = value; OnPropertyChanged("DateOfBirdth"); } }


        #region Statistic

        public int EndedOrders { get { if(CurrentCourer!=null) return CurrentCourer.DiliveryOrders.Where(x => x.IsCompleted).Count(); return 0; } }

        public double EarnMoney { get { if (CurrentCourer != null) return CurrentCourer.DiliveryOrders.Where(x => x.IsCompleted).Select(x => x.DelivetyCost).Sum(); return 0; } }

        public int OrdersinWork { get { if (CurrentCourer != null) return CurrentCourer.DiliveryOrders.Where(x => x.IsCompleted == false).Count(); return 0;  } }
   
        public ObservableCollection<CourerTask> CourerTask { get { if (CurrentCourer != null) new ObservableCollection<CourerTask>(CurrentCourer.DiliveryOrders); return null; } }
        
        #endregion








    public void Clear()
        {
            Name = "";
            Age = 15;
            Vk = "";
            HaveCar = false;
            DateOfBirdth = DateTime.Parse("1/1/1980");
            IsEding = false;
        }


        public void Parse(Courer courer)
        {
            CurrentCourer = courer;
            Name = CurrentCourer.Name;
            Age = CurrentCourer.Age;
            Vk = CurrentCourer.Vk;
            Metro = CurrentCourer.Metro;
            HaveCar = CurrentCourer.HaveCar;
            DateOfBirdth = CurrentCourer.DateOfBirdth;
        }


        private RelayCommand _SaveCommand;

        public RelayCommand SaveCommand
        {
            get

            {
                if (_SaveCommand == null)
                    _SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
                return _SaveCommand;
            }

        }



        public void ExecuteSaveCommand(object parameter)
        {
            try
            {


                if (!IsEding)
                {
                    CourerManagerViewModel2.ProductContextVM.Courers.Add(new Courer { Age = Age, DateOfBirdth = DateOfBirdth.Date, HaveCar = HaveCar, Metro = Metro, Name = Name, Vk = Vk });
                    CourerManagerViewModel2.ProductContextVM.SaveChanges();
                    Clear();
                    MessageBox.Show("Курьер успешно сохранен");
                }
                else
                {
                    CurrentCourer.HaveCar = HaveCar; Name = Name; Age = Age; DateOfBirdth = DateOfBirdth; CurrentCourer.Vk = Vk; CurrentCourer.Metro = Metro; CourerManagerViewModel2.ProductContextVM.SaveChanges();
                    MessageBox.Show("Курьер успешно отредактирован");
                    Clear();
                    CourerManagerViewModel2.ExecuteListCourerCommand(null);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Ошибка доавления курьера" + x.Message);
            }

        }

        public bool CanExecuteSaveCommand(object parameter)
        {
            if (Age < 10 || Name == "" || Vk == "") return false;
            return true;
        }












    }
}
