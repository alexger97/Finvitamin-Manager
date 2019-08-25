using FinVitamin_Manager.Models;
using FinVitamin_Manager.Models.Context;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Interafce
{
  public  interface ICourerManagerViewModel
    {
        RelayCommand ClicAddCommand { get; }

        RelayCommand ClicListCourer { get; }

        ProductContext ProductContextVM{ get; set; }
        void ParseFromList(Courer courer);
        void ExecuteListCourerCommand(object parameter);
}
}
