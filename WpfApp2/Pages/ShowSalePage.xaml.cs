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
            listProduct.ItemsSource = BaseClass.tBE.Product.ToList();

            List<Kind> BT = BaseClass.tBE.Kind.ToList();

            //программное заполнение выпадающего списка
            cbmProduct.Items.Add("Все продукты");
            for (int i=0; i<BT.Count; i++)
            {
                cbmProduct.Items.Add(BT[i].Category);
            }
            cbmProduct.SelectedIndex = 0;
            
        }
        private void btnCreateSale_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new CreateProductPage());
        }
        void Filter()  // метод для одновременной фильтрации, поиска и сортировки
        {
            List<Product> productList = new List<Product>();  // пустой список, который далее будет заполнять элементами, удавлетворяющими условиям фильтрации, поиска и сортировки

            string category = cbmProduct.SelectedValue.ToString();  // выбранный пользователем тип товара
            int index = cbmProduct.SelectedIndex;

            // поиск значений, удовлетворяющих условия фильтра
            if (index != 0)
            {
                productList = BaseClass.tBE.Product.Where(x => x.Kind.Category == category).ToList();
            }
            else  // если выбран пункт "Типы", то сбрасываем фильтрацию:
            {
                productList = BaseClass.tBE.Product.ToList();
            }


            // поиск совпадений по названиям продуктов
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                productList = productList.Where(x => x.Name_Product.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }

            listProduct.ItemsSource = productList;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Buttondeleate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);

            Product product = BaseClass.tBE.Product.FirstOrDefault(x => x.id_Product == index);

            BaseClass.tBE.Product.Remove(product);
            BaseClass.tBE.SaveChanges();

            FrameClass.MainFrame.Navigate(new ShowSalePage());
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void tbAmountSale_Loaded() //Общее количество проданного товара
        //{ 

        //}
        //private void tbSale_Loaded() //Сумма полученных средств за определенный вид товара
        //{

        //}
        //private void tbENDSale_Loaded() //Сумма полученных с операции средств
        //{

        //}

    }
}
