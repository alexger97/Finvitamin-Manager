using FinVitamin_Manager.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinVitamin_Manager.Models.UserContorolVM
{
    public class SubItem
    {
        public SubItem(string name,  RelayCommand Command,UserControl screen = null )
        {
            Name = name;
            Screen = screen;
            RelayCommand = Command;
        }
        public string Name { get; private set; }
        public UserControl Screen { get; private set; }

        public RelayCommand RelayCommand { get; set; }
    }
}
