using System;
using System.Windows;

namespace Practice20_var11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random globalRnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void About_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Хм, даже не знаю кто выполнил эти практические, держи рекламу. ", "О программе");
            System.Diagnostics.Process.Start("https://www.avito.ru/ryazan/koshki/neveroyatnye_shotlandskie_kotyata_2995585950");

        }

        private void YouShallNotPass_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("YOU SHALL NOT PASS!", "Gendalf");
            Close();
        }

        private void PracticeInfo_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("11. Генерировать случайные числа Х, распределенные в диапазоне от -4 до 7 и вычислять для \r\nчисел > 0 \r\nX\r\n, а для чисел < 0 функцию x\r\n2\r\n. Вычисления прекратить, когда подряд \r\nпоявится два одинаковых случайных числа. На экран необходимо выводить \r\nсгенерированное число и результат расчета функции на разных строках.");
        }

        private void Task20_1_Calc_Click(object sender, RoutedEventArgs e)
        {
            int prevNum = int.MaxValue;
            int rndNum = 0;
            Task20_1_Result.Text = "Результат";
            while (prevNum != rndNum)
            {
                (prevNum, rndNum) = (rndNum, globalRnd.Next(-4, 7));
                Task20_1_Result.Text += $"; {rndNum}=>{(rndNum > 0 ? Math.Sqrt(rndNum) : Math.Pow(rndNum, 2))}";
            }
        }
    }
}
