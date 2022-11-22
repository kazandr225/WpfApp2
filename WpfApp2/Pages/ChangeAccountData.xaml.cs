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
using System.Windows.Shapes;
using WpfApp2.Classes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeAccountData.xaml
    /// </summary>
    public partial class ChangeAccountData : Window
    {
        Users user;
        public ChangeAccountData(Users user)
        {
            InitializeComponent();
            this.user = user;
            tbLogin.Text = user.Login;
            //pbPassword.Password = user.Password;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Проверка на логин. Если введенный логин будет соответствовать уже существующему, то выведется соответстввующее сообщение
                var changeUser = BaseClass.tBE.Users.FirstOrDefault(x => x.Login == tbLogin.Text);
                if (changeUser != null)
                {
                    MessageBox.Show("Пожалуйста, придумайте другой логин", "Этот логин занят!");
                }
                //Если допущена ошибка, то вызываем соответствующее сообщение
                if (!PasswordVerification(pbPassword)) return;

                user.Login = tbLogin.Text;
                user.Password = pbPassword.Password.GetHashCode();
                BaseClass.tBE.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка изменения данных, проверьте введенные данные", "Возникла ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool PasswordVerification(PasswordBox passbox)
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
    }
    
}
