using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace Practice18_var11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Dictionary<RadioButton, String> brichki = new();
        private static RadioButton selectedRB;
        public MainWindow()
        {
            InitializeComponent();
            // Ну, короче, мне было скучно, и я решил прикрутить ещё парсинг из xml
            XmlDocument xml = new();
            // Не получается распаковать из проекта
            //Assembly asm = Assembly.GetExecutingAssembly();
            string path = "Brichki.xml";
            //xml.Load(asm.GetManifestResourceStream(path));
            // Грузим-грузим
            xml.Load(path);
            // обход всех узлов в корневом элементе
            foreach (XmlNode node_brichka in xml.DocumentElement.ChildNodes)
            {
                RadioButton btn = new();
                btn.Content = node_brichka.ChildNodes.Item(0).InnerText;
                btn.Click += new RoutedEventHandler(RadioSelectHandler);

                brichki.Add(btn, node_brichka.ChildNodes.Item(1).InnerText);
                main.Items.Add(btn);
            }
        }

        /// <summary>
        /// Функция только для радиокнопок, немного костылей, чтобы всё заработало ещё и по нажатию кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RadioSelectHandler(object sender, RoutedEventArgs e) {
            RadioButton btn = sender as RadioButton;
            if (doAuto.IsChecked == false)
            {
                selectedRB = btn;
                return;
            }
            ShowMessage(btn);
        }

        public void UselessButtonClick(object sender, RoutedEventArgs e)
        {
            if (selectedRB == null)
            {
                MessageBox.Show("Выберите марку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ShowMessage(selectedRB);
        }

        public void ShowMessage(RadioButton btn)
        {
            MessageBox.Show($"{brichki[btn]}", $"Страна-производитель марки {btn.Content}");
        }

        private void doAuto_Click(object sender, RoutedEventArgs e)
        {
            whereAreYouFrom.IsEnabled = !(bool)doAuto.IsChecked;
        }

        private void ya_lublu_pivo_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.avito.ru/ryazan/posuda_i_tovary_dlya_kuhni/kruzhka_dlya_piva_2762323668",
                UseShellExecute = true
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] about = new string[4] { "В главных ролях" , "Рустам Юсубов, ИСП-21", "Пивная кружка за 150 рублей", "И задание №11 из 18 практической:\n\n" +
                "Выведите на экран следующую информацию:\r\nМАРКА АВТОМОБИЛЯ\r\n1. Пежо 2. Лада 3. Рено 4. Нива\r\n5. Форд 6. Вольво 7. БМВ 8. Мерседес\r\nВведите номер марки и определите марку и страну-производителя."};
            foreach (string s in about)
            {
                MessageBox.Show(s, "О программе");
            }
        }
    }
}
