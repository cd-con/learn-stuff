using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice17_var11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsDigitsOnly(params string[] args)
        {
            // Проверка от моей невнимательности
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            foreach (string arg in args)
            {
                foreach (char c in arg)
                {
                    if (c < '0' || c > '9')
                        return false;
                }
            }
            return true;
        }

        bool isGreaterThanValue(int value, params int[] args)
        {
            // Проверка от моей невнимательности
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            foreach (int arg in args)
            {
                if (arg <= value)
                {
                    return false;
                }
            }
            return true;
        }

        bool isObjectsNotNull(params object[] args)
        {
            // Проверка от моей невнимательности
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            foreach (object arg in args)
            {
                if (arg is null)
                {
                    return false;
                }
            }
            return true;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pork_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.avito.ru/ryazan/produkty_pitaniya/mesyachnyy_zapas_svininy_2786941288",
                UseShellExecute = true
            });
        }

        private void Size_GotFocus(object sender, RoutedEventArgs e)
        {
            Size.Text = "";
        }

        private void ConvertBytesToMB(object sender, RoutedEventArgs e)
        {
            if (Size.Text.Length > 0 && IsDigitsOnly(Size.Text))
            {
                Task2Result.Content = $"{Math.Round((int.Parse(Size.Text) / 1024f), 2).ToString()} мегабайт";
                return;
            }
            if (Task2Result != null)
            {
                Task2Result.Content = "Невалидный ввод (допускаются только цифры)";
            }
        }

        private void x1_GotFocus(object sender, RoutedEventArgs e)
        {
            x1.Text= "";
        }

        private void y1_GotFocus(object sender, RoutedEventArgs e)
        {
            y1.Text = "";
        }

        private void x2_GotFocus(object sender, RoutedEventArgs e)
        {
            x2.Text = "";
        }

        private void y2_GotFocus(object sender, RoutedEventArgs e)
        {
            y2.Text = "";
        }

        private void CalcSquareOfRect(object sender, TextChangedEventArgs e)
        {
            if (isObjectsNotNull(x1, x2, y1, y2, Task1Result))
            {

                if (isGreaterThanValue(0, x1.Text.Length, y1.Text.Length, x2.Text.Length, y2.Text.Length) && IsDigitsOnly(x1.Text, x2.Text, y1.Text, y2.Text))
                {
                    int x = Math.Abs(int.Parse(x2.Text) - int.Parse(x1.Text));
                    int y = Math.Abs(int.Parse(y2.Text) - int.Parse(y1.Text));
                    int per = x * 2 + y * 2;
                    int square = x * y;
                    Task1Result.Content = $"Периметр: {per.ToString()}; Площадь {square.ToString()}";
                }
                else
                {
                    Task1Result.Content = $"Невалидный ввод (допускаются только цифры)";
                }
            }
        }

        private void ToadCode_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://map.toadcode.ru",
                UseShellExecute = true
            });
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа сделана студентом группы ИСП-21 Юсубовым Рустамом.", "О программе");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Для кого придумали крестик?", "Выхода нет...");
            if (r == MessageBoxResult.OK || r == MessageBoxResult.Cancel)
            {
                MainWindow1.Close();
            }
        }
    }
}
