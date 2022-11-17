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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        Users user;
        public UserPage(Users user)
        {
            InitializeComponent();
            this.user = user;
            
        }
        private void btnBackMain_Click(object sender, RoutedEventArgs e) //назад на главную
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }
    }
}
