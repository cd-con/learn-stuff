using System;
using System.Linq;
using System.Windows;

namespace Practice19_var11
{
    public partial class MainWindow : Window
    {
        private Random globalRnd = new();
        /// <summary>
        /// Вывод ошибки пользователю
        /// </summary>
        /// <param name="fieldReference">Основной объект ошибки</param>
        /// <param name="message">Сообщение юзверю</param>
        /// <param name="cause">Перенос фокуса пользователя на поле, если не пусто</param>
        private void ErrorHandler(FrameworkElement fieldReference, string message = "Неопознанная ошибка.", FrameworkElement? cause = null)
        {
            MessageBox.Show($"Произошла следующая ошибка, связаная с объектом {fieldReference.Name}:\n\n{message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            if (cause != null) { cause.Focus(); return; }
            fieldReference.Focus();
        }

        /// <summary>
        /// Находится ли значение в диапазоне
        /// </summary>
        /// <param name="num">Число</param>
        /// <param name="max">Нижний порог</param>
        /// <param name="min">Верхний порог</param>
        /// <returns></returns>
        private bool inRange(int num, int max, int min = 0)
        {
            return num >= min && num <= max;
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Task19_1_AddUserValue_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Task19_1_AddValue.Text, out int val))
            {
                Task19_1_List.Items.Add(val);
                Task19_1_AddValue.Text = "";
                Task19_1_AddValue.Focus();
                return;
            }
            ErrorHandler(Task19_1_AddValue, "Невалидное значение");
        }

        private void Task19_1_AddRndValues_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Task19_1_AddRndCount.Text, out int val))
            {
                if (inRange(val, 1000, 1))
                {
                    for (int i = 0; i < val; i++)
                    {
                        Task19_1_List.Items.Add(globalRnd.Next(-999,999));
                    }
                    Task19_1_AddRndCount.Focus();
                    return;
                }
                ErrorHandler(Task19_1_AddRndCount, "Значение вне допустимого диапазона.");
                return;
            }
            ErrorHandler(Task19_1_AddRndCount, "Невалидное значение");
        }

        private void Task19_1_RemoveSelectedValue_Click(object sender, RoutedEventArgs e)
        {
            if (Task19_1_List.SelectedItem != null)
            {
                Task19_1_List.Items.Remove(Task19_1_List.SelectedItem);
                return;
            }
            ErrorHandler(Task19_1_List, "Для исполнения этого действия нужно выбрать элемент из списка.");
        }

        private void Task19_1_ClearList_Click(object sender, RoutedEventArgs e)
        {
            if (Task19_1_List.Items.Count > 0)
            {
                Task19_1_List.Items.Clear();
                return;
            }
            ErrorHandler(Task19_1_List, "Список уже пуст.");
        }

        private void Task19_1_Execute_Click(object sender, RoutedEventArgs e)
        {
            if (Task19_1_List.Items.Count > 0)
            {
                int[] numsGreater0 = Task19_1_List.Items.OfType<int>().Where(x => x > 0).ToArray();
                int[] numsLess0 = Task19_1_List.Items.OfType<int>().Where(x => x < 0).ToArray();
                int res = numsGreater0.Sum() - numsLess0.Sum(x => x = Math.Abs(x));
                MessageBox.Show($"Значения больше 0 ({numsGreater0.Sum()}):\n{string.Join(", ",numsGreater0)}" +
                    $"\n\nЗначения меньше 0 ({numsLess0.Sum(x => x = Math.Abs(x))}):\n{string.Join(", ", numsLess0)}" +
                    $"\n\nРазность сумм: {res}");
                Task19_1_Answer.Text = res.ToString();
                return;
            }
            Task19_1_Answer.Text = "Ошибка!";
            ErrorHandler(Task19_1_List, "Список пуст. Добавьте хотя-бы одно значение.", Task19_1_AddValue);
        }
    }
}
