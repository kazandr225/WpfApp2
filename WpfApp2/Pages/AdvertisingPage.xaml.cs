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
using System.Windows.Media.Animation;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdvertisingPage.xaml
    /// </summary>
    public partial class AdvertisingPage : Page
    {
        public AdvertisingPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation WA = new DoubleAnimation(); // создание объекта для настройки анимации
            WA.From = 100; // начальное значение свойства
            WA.To = 300; // конечное значение свойства
            WA.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            btnAdd.BeginAnimation(WidthProperty, WA); // «навешивание» анимации на свойство ширины кнопки

            DoubleAnimation WAA = new DoubleAnimation();
            WAA.From = 100; // начальное значение свойства
            WAA.To = 150; // конечное значение свойства
            WAA.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WAA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WAA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            btnAdd.BeginAnimation(HeightProperty, WAA);

            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ
            MA.From = new Thickness(100, 100, 100, 100);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(1);
            MA.AutoReverse = false;
            btnAdd.BeginAnimation(MarginProperty, MA);

            ColorAnimation BA = new ColorAnimation(); // создание объекта для настройки анимации
            ColorConverter CC = new ColorConverter(); // создание объекта для конвертации кода в цвет
            Color Cstart = (Color)CC.ConvertFrom("#ff0000"); // присваивание начального цвета эл-ту
            btnAdd.Background = new SolidColorBrush(Cstart); // закрашивание эл-та сплошным цветом
            BA.From = Cstart; // начальное значение свойства
            BA.To = (Color)CC.ConvertFrom("#00ff00"); // конечное значение свойства
            BA.Duration = TimeSpan.FromSeconds(5);
            btnAdd.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);

            ThicknessAnimation IM = new ThicknessAnimation(); //изменение границ картинки
            IM.From = new Thickness(15, 75, 100, 300);
            IM.To = new Thickness(0, 0, 0, 0);
            IM.Duration = TimeSpan.FromSeconds(1);
            IM.AutoReverse = false;
            img.BeginAnimation(MarginProperty, IM);

            DoubleAnimation IM1 = new DoubleAnimation(); //Ширина картинки
            IM1.From = 100; // начальное значение свойства
            IM1.To = 300; // конечное значение свойства
            IM1.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            IM1.AutoReverse = false; // воспроизведение временной шкалы в обратном порядке
            img.BeginAnimation(WidthProperty, IM1); // «навешивание» анимации на свойство ширины кнопки

            DoubleAnimation IM2 = new DoubleAnimation(); //Высота картинки
            IM2.From = 100; // начальное значение свойства
            IM2.To = 150; // конечное значение свойства
            IM2.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            IM2.AutoReverse = false; // воспроизведение временной шкалы в обратном порядке
            img.BeginAnimation(HeightProperty, IM2);

            DoubleAnimation TB1 = new DoubleAnimation();
            TB1.From = 20; // начальное значение свойства
            TB1.To = 35; // конечное значение свойства
            TB1.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            //TB1.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            TB1.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            tbTap.BeginAnimation(FontSizeProperty, TB1);

            DoubleAnimation TB2 = new DoubleAnimation();
            TB2.From = 20; // начальное значение свойства
            TB2.To = 35; // конечное значение свойства
            TB2.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            //TB2.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            TB2.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            tbTap1.BeginAnimation(FontSizeProperty, TB2);


        }
    }
}


