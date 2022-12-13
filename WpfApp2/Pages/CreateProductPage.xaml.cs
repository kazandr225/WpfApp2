using Microsoft.Win32;
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
    /// Логика взаимодействия для CreateProductPage.xaml
    /// </summary>
    public partial class CreateProductPage : Page
    {
        Product PRODUCT;
        bool flagUpdate = false;
        string path;

        public void uploadFields()
        {
            cmbContractor.ItemsSource = BaseClass.tBE.Contractor.ToList();
            cmbContractor.SelectedValuePath = "id_Contractor";
            cmbContractor.DisplayMemberPath = "Name_Contractor";

            cmbKind.ItemsSource = BaseClass.tBE.Kind.ToList();
            cmbKind.SelectedValuePath = "id_Kind";
            cmbKind.DisplayMemberPath = "Category";


        }
        public CreateProductPage(Product product)
        {
            InitializeComponent();
            uploadFields();
            flagUpdate = true;
            PRODUCT = product;
            tbName_Product.Text = product.Name_Product; //выводим название продукта
            tbAmount_Product.Text = Convert.ToString(product.Amount_Product); //выводим количество продукта
            tbPurchaseCost.Text = Convert.ToString(product.PurchaseCost); //выводим цену закупки
            tbSellingPrice.Text = Convert.ToString(product.SellingPrice); //выводим цену продажи
            cmbKind.SelectedIndex = (int)(product.id_Kind - 1); //выводим вид продукта
            cmbContractor.SelectedIndex = product.Supply.Contractor.id_Contractor - 1;//выводим поставщика


        }
        //конструктор для создания нового продукта
        public CreateProductPage()
        { 
            InitializeComponent();
            uploadFields();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                //если флаг раввен false, то создаем объект для добавления продукта
                if (flagUpdate == false)
                { 
                    PRODUCT = new Product();
                }
                //Заполняем поля таблицы
                PRODUCT.Name_Product = tbName_Product.Text;
                PRODUCT.id_Kind = cmbKind.SelectedIndex + 1;
                PRODUCT.PurchaseCost = Convert.ToInt32(tbPurchaseCost);
                PRODUCT.SellingPrice = Convert.ToInt32(tbSellingPrice);
                PRODUCT.Amount_Product = Convert.ToInt32(tbAmount_Product);
                PRODUCT.

                //если флаг равен false, то добовляем объект в базу
                if (flagUpdate == false)
                {
                    BaseClass.tBE.Product.Add(PRODUCT);
                }

                BaseClass.tBE.SaveChanges();
                MessageBox.Show("Инфрмация добавлена");
            }
            catch 
            {
                MessageBox.Show("что-то пошло не по плану");
            }
        }

        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();
            
        }
    }
}
