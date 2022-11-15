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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }
        private void btnBackMain_Click(object sender, RoutedEventArgs e) //назад на главную
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }
        private void btnAutorization_Click(object sender, RoutedEventArgs e) //авторизация
        {
            int p = pbPasword.Password.GetHashCode();

            Users autoUser = BaseClass.tBE.Users.FirstOrDefault(x => x.Login == tboxLogin.Text && x.Password == p);

            if (autoUser == null)
            {
                MessageBox.Show("Проверьте введенные данные!","Такого пользователя нет");
            }
            else 
            {
                switch (autoUser.id_Role) //проверка роли пользователя, если он найден
                {
                case 1:
                        FrameClass.MainFrame.Navigate(new AdminPage(autoUser)); //окно администратора
                        break;
                        case 2:
                        FrameClass.MainFrame.Navigate(new UserPage());
                        break;
                        default:
                        MessageBox.Show("Пока");
                        break;
                }
            }
        }
    }
}
