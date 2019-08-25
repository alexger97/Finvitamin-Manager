using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Interafce
{
   public interface IProductManagerViewModel
    {
        RelayCommand ClicOneCommand { get; }
        RelayCommand ClicTwoCommand { get;  }
    }
}
