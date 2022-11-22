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
using System.Windows.Shapes;
using WpfApp2.Classes;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeUserData.xaml
    /// </summary>
    public partial class ChangeUserData : Window
    {
        Users user;
        public ChangeUserData(Users user)
        {
            InitializeComponent();
            this.user = user;
            tbName.Text = user.Name_User;
            tbsurname.Text = user.Name_User;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            user.Name_User = tbName.Text;
            user.Surname_User = tbsurname.Text;
            BaseClass.tBE.SaveChanges();
            this.Close();
        }
    }
}
