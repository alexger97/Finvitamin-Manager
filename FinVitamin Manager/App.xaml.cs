using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.Service;
using FinVitamin_Manager.ViewModels;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinVitamin_Manager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        


        protected override void OnStartup(StartupEventArgs e)
        {
            ProductContext ProductContextVm = new ProductContext();
            CourerTaskManager courerTaskManager = new CourerTaskManager(ProductContextVm);

            var vv = new MainWindow(new MainViewModel(ProductContextVm));
            vv.Show();
       

        }


     

       
    }
}
