using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void btnRegistration_Click(object sender, RoutedEventArgs e) //Событие для кнопки регистрации
        {
            try
            {
                //добавляем пол
                int rol = 2;
                int g = 0;
                if (rbMen.IsChecked == true) g = 1;
                if (rbWomen.IsChecked == true) g = 2;

                //Проверка на логин. Если введенный логин будет соответствовать уже существующему, то выведется соответстввующее сообщение
                var regUser = BaseClass.tBE.Users.FirstOrDefault(x => x.Login == tboxLogin.Text);
                if (regUser != null)
                {
                    MessageBox.Show("Пожалуйста, придумайте другой логин", "Этот логин занят!");
                }
                //Если допущена ошибка, то вызываем соответствующее сообщение
                if (!PasswordVerigication(pbPassword)) return;

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
                    id_Role = rol

                };
                BaseClass.tBE.Users.Add(userTable);
                BaseClass.tBE.SaveChanges();
                MessageBox.Show("Вы зарегистрировались!", "Добро пожаловать в систему!");
                FrameClass.MainFrame.Navigate(new MainPage());
            }
            catch 
            {
                MessageBox.Show("Ошибка регистрации, проверьте введенные данные", "Возникла ошибка",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        private bool PasswordVerigication(PasswordBox passbox) //Метод для проверки пароля
        {
            string pass = passbox.Password;

            Regex CapitalSymb = new Regex("(?=.*[A-Z])"); // Заглавный латинский символ
            Regex SmallSymbs = new Regex("(?=.*[a-z])"); // Три строчных латинских символа
            Regex Numbers = new Regex("(?=.*[0-9])"); // Цифры
            Regex SpecSymb = new Regex("(?=.*[!@#$%^&*()+=])"); // Спец символы

            if (!CapitalSymb.IsMatch(pass))
            {
                MessageBox.Show("В пароле должен содержаться как минимум 1 заглавный латинский символ", "Вы допустили ошибку в пароле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!SmallSymbs.IsMatch(pass))
            {
                MessageBox.Show("Пароль должен содержать как минимум 3 прописных латинских символа", "Вы допустили ошибку в пароле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!Numbers.IsMatch(pass))
            {
                MessageBox.Show("Пароль должен содержать как минимум 2 цифры", "Вы допустили ошибку в пароле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!SpecSymb.IsMatch(pass))
            {
                MessageBox.Show("Пароль должен содержать в себе как минимум один спец. символ", "Вы допустили ошибку в пароле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (pass.Length < 8)
            {
                MessageBox.Show("Пароль должен быть не менее 8 символов", "Вы допустили ошибку в пароле", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            else
            { 
            return true;
            } 
        }
        private void btnBackMain_Click(object sender, RoutedEventArgs e) //Назад на главную
        { 
        FrameClass.MainFrame.Navigate(new MainPage());
        }

    }
}
