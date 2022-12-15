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
        PageChange pc = new PageChange();
        List<Product> ProductFilter = new List<Product>();
        public ShowSalePage()
        {
            InitializeComponent();
            BaseClass.tBE = new ShopModelEntities();
            ProductFilter = BaseClass.tBE.Product.ToList();

            listProduct.ItemsSource = BaseClass.tBE.Product.ToList();
            List<Kind> BT = BaseClass.tBE.Kind.ToList();

            pc.CountPage = BaseClass.tBE.Product.ToList().Count;
            DataContext = pc; // добавляем объект для отображения страниц в ресурсы страницы

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

            //вывод элемента с фото
            if (cbPhoto.IsChecked == true)
            {
                productList = productList.Where(x=>x.Photo!=null).ToList();
            }

            // сортировка
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    {
                        productList.Sort((x, y) => x.Name_Product.CompareTo(y.Name_Product));
                    }
                    break;
                case 2:
                    {
                        productList.Sort((x, y) => x.Name_Product.CompareTo(y.Name_Product));
                        productList.Reverse();
                    }
                    break;
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

            //Создаем объект, который содержит инвормацию о продукте, который нужно удалить
            Product product = BaseClass.tBE.Product.FirstOrDefault(x => x.id_Product == index);

            BaseClass.tBE.Product.Remove(product);
            BaseClass.tBE.SaveChanges();

            FrameClass.MainFrame.Navigate(new ShowSalePage()); //перезагрузка страницы для отображения списка без удаленного продукта
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);

            //Создаем объект, который содержит продукт, который редактируем
            Product product = BaseClass.tBE.Product.FirstOrDefault(x => x.id_Product == index);

            FrameClass.MainFrame.Navigate(new CreateProductPage(product)); 

        }

        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = ProductFilter.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = ProductFilter.Count; // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listProduct.ItemsSource = ProductFilter.Skip(0).Take(pc.CurrentPage).ToList();   // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e) // обработка нажатия на один из Textblock в меню с номерами страниц
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid) // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                    default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;  
            }

            listProduct.ItemsSource = ProductFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList(); // оображение записей постранично с определенным количеством на каждой странице
        }

        private void tbRevenue_Loaded(object sender, RoutedEventArgs e) //Сколько денег будет получено после продажи товара, стоимость закупки не учитывается
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);

            //ищем в таблице, где хранится информация про количество товара и стоимости продажи
            List<Product> P = BaseClass.tBE.Product.Where(x=>x.id_Product==index).ToList();

            int sum = 0;

            //вычисляем количество денег
            foreach (Product prod in P)
            {
                sum += Convert.ToInt32(prod.Amount_Product * prod.SellingPrice);
            }

            tb.Text = "Выручка составит: " + sum.ToString()+ " руб.";
        }

        private void cbPhoto_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void GoFirstPage_MouseDown(object sender, MouseButtonEventArgs e) //переходим на первую страницу
        {
            pc.CurrentPage = 1;
            listProduct.ItemsSource = ProductFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }

        private void GoLastPage_MouseDown(object sender, MouseButtonEventArgs e) //переходим на последнюю страницу
        {
            pc.CurrentPage = pc.CountPages;
            listProduct.ItemsSource = ProductFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }
    }
}
