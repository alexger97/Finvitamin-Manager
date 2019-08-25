using FinVitamin_Manager.ViewModels;
using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Interafce
{
    public interface IMainViewModel
    {

        RelayCommand ClicOneCommand { get;  }
        RelayCommand ClicTwoCommand { get; }
        RelayCommand ClicThirdCommand { get;  }
        RelayCommand ClicFourthCommand { get; }
        RelayCommand ClicFiveCommand { get; }


        ICourerManagerViewModel CourerManagerViewModel { get; set; }
        IInvoicesManagerViewModel InvoicesManagerViewModel { get; set; }

        ProductManagerViewModel ProductManagerViewModel { get; set; }


    }
}
