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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();

            cbRole.ItemsSource = BaseClass.tBE.Role.ToList();
            cbRole.SelectedValuePath = "idRole";
            cbRole.DisplayMemberPath = "Role";
            cbRole.SelectedIndex = 1;
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            //добавляем пол
            int g = 0;
            if (rbMen.IsChecked == true) g = 1;
            if (rbWomen.IsChecked == true) g = 2;

            //объект для записей в БД
            Users userTable = new Users()
            {
                Surname_User = tboxSurname.Text,
                Name_User = tboxName.Text,
                Patronymic_User = tboxPatronymic.Text,
                Birthday_User = Convert.ToDateTime(dpBirthday.SelectedDate),
                Login = tboxLogin.Text,
                Password = pbPassword.Password.GetHashCode(),
                id_Gender = g,
                id_Role = cbRole.SelectedIndex + 1

            };
            BaseClass.tBE.Users.Add(userTable);
            BaseClass.tBE.SaveChanges();
            MessageBox.Show("Вы зарегистрировались!");
            FrameClass.MainFrame.Navigate(new MainPage());
        }
        private void btnBackMain_Click(object sender, RoutedEventArgs e)
        { 
        FrameClass.MainFrame.Navigate(new MainPage());
        }

    }
}
