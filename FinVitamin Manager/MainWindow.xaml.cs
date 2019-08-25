using FinVitamin_Manager.Interafce;
using FinVitamin_Manager.Models.UserContorolVM;
using FinVitamin_Manager.UserControls;
using FinVitamin_Manager.ViewModels.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinVitamin_Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            this.DataContext = mainViewModel;
            var ordermenu = new List<SubItem>();
            ordermenu.Add(new SubItem("Добавить заказ", mainViewModel.ClicOneCommand, null));
            ordermenu.Add(new SubItem("Список заказов", mainViewModel.ClicTwoCommand, null));
           
            var item6 = new ItemMenu("Заказы", ordermenu, PackIconKind.ClipboardTextOutline);


            var courermenu = new List<SubItem>();
            courermenu.Add(new SubItem("Добавить курьера", mainViewModel.CourerManagerViewModel.ClicAddCommand, null));
            courermenu.Add(new SubItem("Список курьеров", mainViewModel.CourerManagerViewModel.ClicListCourer, null));

            var menu2 = new ItemMenu("Курьеры", courermenu, PackIconKind.AccountCardDetailsOutline);


            var invoiceList = new List<SubItem>();
            invoiceList.Add(new SubItem("Добавить путевой лист", mainViewModel.InvoicesManagerViewModel.InvoiceAddCommand, null));
            invoiceList.Add(new SubItem("Список путевых листов", mainViewModel.InvoicesManagerViewModel.InvoiceListCommand, null));

            var menu3 = new ItemMenu("Путевые листы", invoiceList, PackIconKind.TrainCar);

            var productlist = new List<SubItem>();
            productlist.Add(new SubItem("Добавить товар", mainViewModel.ProductManagerViewModel.ClicOneCommand, null));
            productlist.Add(new SubItem("Список товаров", mainViewModel.ProductManagerViewModel.ClicTwoCommand, null));

            var menu4 = new ItemMenu("Товары", productlist, PackIconKind.Shopify);



            One.Children.Add(new UserControlMenuItem(item6));
            One.Children.Add(new UserControlMenuItem(menu2));
            One.Children.Add(new UserControlMenuItem(menu4));
            One.Children.Add(new UserControlMenuItem(menu3));
        }
    }
}
