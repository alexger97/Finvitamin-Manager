using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVitamin_Manager.Interafce
{
   public interface ICourerAndInvoiceViewModel
    {
        RelayCommand ClicCourersCommand { get; }
        RelayCommand ClicInvoicesCommand { get; }

    }
}
