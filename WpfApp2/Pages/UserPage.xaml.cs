using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        // метод для отображения изображения в личном кабинете. первый аргумент - байтовый массив, в котором хранится изображение в БД, второй аргумент - имя изображения в разметке
        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        { 
            BitmapImage BI = new BitmapImage(); // создаем объект для загрузки изображения
            using (MemoryStream m = new MemoryStream(Barray)) // для считывания байтового потока
            { 
                BI.BeginInit(); // начинаем считывание
                BI.StreamSource = m; // задаем источник потока
                BI.CacheOption = BitmapCacheOption.OnLoad; // переводим изображение
                BI.EndInit(); // заканчиваем считывание
            }
            img.Source = BI; // показываем картинку на экране (imUser – имя картиник в разметке)
            img.Stretch = Stretch.Uniform;
        }

        public UserPage(Users user)
        {
            InitializeComponent();
            this.user = user; // заполняем выше созданный объект информацией об авторизованном пользователе
            tbName.Text = user.Name_User;
            tbSurname.Text = user.Surname_User;
            List<UsersPhoto> u = BaseClass.tBE.UsersPhoto.Where(x => x.id_User == user.id_User).ToList(); // для загрузки картинки находим все фото пользователя в таблице, где хранятся фото
            if (u != null) // если список с фото не пустой, начинает переводить байтовый массив в изображение
            {
                byte[] Bar = u[u.Count - 1].Photo_Binary; // считываем изображение из базы (считываем байтовый массив двоичных данных) - выбираем последнее добавленное изображение
                showImage(Bar, imUser); // отображаем картинку
            }
        }

        private void ChangeDataUser_Click(object sender, RoutedEventArgs e)
        { 

        }

        private void btnOld_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                UsersPhoto u = new UsersPhoto();
                u.id_User = user.id_User;

                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                //OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  // выбор папки для открытия
                OFD.ShowDialog();  // открываем диалоговое окно             
                string path = OFD.FileName;  // считываем путь выбранного изображения
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);  // создаем объект для загрузки изображения в базу
                ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                u.Photo_Binary = Barray;  // заполяем поле photoBinary полученным байтовым массивом
                BaseClass.tBE.UsersPhoto.Add(u);  // добавляем объект в таблицу БД
                BaseClass.tBE.SaveChanges();  // созраняем изменения в БД
                MessageBox.Show("Фото добавлено");
                FrameClass.MainFrame.Navigate(new UserPage(user)); // перезагружаем страницу


            }

            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка!");
            }
        
        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
