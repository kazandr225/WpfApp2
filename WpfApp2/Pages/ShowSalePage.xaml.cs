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
using WpfApp2.Classes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowSalePage.xaml
    /// </summary>
    public partial class ShowSalePage : Page
    {
        public ShowSalePage()
        {
            InitializeComponent();
            listSale.ItemsSource = BaseClass.tBE.Sale.ToList();
        }

        private void tbAmountSale_Loaded() //Общее количество проданного товара
        { 
        
        }
        private void tbSale_Loaded() //Сумма полученных средств за определенный вид товара
        {

        }
        private void tbENDSale_Loaded() //Сумма полученных с операции средств
        {

        }
        
    }
}
