﻿using System;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            dgUsers.ItemsSource = BaseClass.tBE.Users.ToList();
        }

        private void btnShowUser_Click(object sender, RoutedEventArgs e) //вывести список пользователей
        {
            dgUsers.Visibility = Visibility.Visible;
            btnShowUser.Visibility = Visibility.Collapsed;
            btnPrivateUser.Visibility = Visibility.Visible;
        }
        private void btnPrivateUser_Click(object sender, RoutedEventArgs e) //скрыть список пользователей
        { 
            dgUsers.Visibility= Visibility.Collapsed;
            btnPrivateUser.Visibility= Visibility.Visible;
            btnPrivateUser.Visibility = Visibility.Collapsed;
        }
        private void btnMain_Click(object sender, RoutedEventArgs e) //назад на главную
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }
        private void btnShowSells() //показать продажи
        { 
        
        }

    }
}