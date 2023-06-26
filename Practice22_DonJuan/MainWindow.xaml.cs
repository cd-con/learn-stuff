using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace Practice21_var11
{

    public partial class MainWindow : Window
    {
        // Сделаем нечестно - будем использовать отдельную матрицу
        private int[,] MatrixStorage = new int[0,0];
        private int[,] IMatrix {
            get => MatrixStorage;
            set
            {
                MatrixStorage = value;
                Matrix.ItemsSource = Convert.ToDataTable(IMatrix).DefaultView;
            }
        }
        readonly Random random = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InputHandler(object sender, TextChangedEventArgs args)
        {
            if (sender is TextBox textBox && textBox.Text.Length == 0)
            {
                textBox.Text = "Введите значение";
                textBox.SelectAll();
            }
        }

        public static bool IsNumInRange(int num, int[] range) => range == null || num >= range[0] && num <= range[1];

        // Заполнение одномерной матрицей
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Val.Text, out int size))
            {
                IMatrix = GenerateArray(1, size);
            }
            else
            {
                MessageBox.Show("Невалидный ввод");
                Val.Focus();
            }
        }

        // Заполнение двумерной матрицей
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(X.Text, out int columns) && int.TryParse(Y.Text, out int rows))
                IMatrix = GenerateArray(rows, columns);
            else
                MessageBox.Show("Невалидный ввод");
        }


        public int[,] GenerateArray(int rows = 1, int columns = 1, int range_top = 10, int range_bottom = -10)
        {
            int[,] array = new int[rows, columns];            

            for (int column = 0; column < columns; column++)
                for (int row = 0; row < rows; row++)
                    array[row, column] = random.Next(range_bottom, range_top);

            return array;
        }

        // Рассчёт первого задания
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (IMatrix == null)
            {
                MessageBox.Show("Пустой массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (IMatrix.GetLength(0) > 1)
            {
                MessageBox.Show("Это не одномерный массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            for (int column = 0; column < IMatrix.GetLength(1); column++)
                for (int row = 0; row < IMatrix.GetLength(0); row++)
                    result += IMatrix[row, column] > 15 ? IMatrix[row, column] : 0;
            MessageBox.Show($"Результат 1 задачи: {result}");
        }

        // Решение второй задачи
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (IMatrix == null)
            {
                MessageBox.Show("Пустой массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string output = string.Empty;
            for (int column = 0; column < IMatrix.GetLength(1); column++)
            {
                int[] intColumn = Enumerable.Range(0, IMatrix.GetLength(0)).Select(x => IMatrix[x, column]).ToArray();
                double columnAvg = intColumn.Sum(x => x) / System.Convert.ToDouble(intColumn.Length);
                int[] greaterAvg = intColumn.Where(x => x > columnAvg).ToArray();
                if(greaterAvg.Length > 0)
                    output += $"Столбец {column + 1} имеет среднее значение {columnAvg} и числа {string.Join("; ", greaterAvg)}; которые превышают его.\n";
                else
                    output += $"Столбец {column + 1} имеет среднее значение {columnAvg} и не имеет чисел, превышающих его.\n";

            }
            MessageBox.Show($"Результат 2 задачи:\n{output}");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IMatrix = new int[0, 0];
            // Оно реально здесь работает
            // Особенно если много раз тыкнуть :)
            GC.Collect();
        }

        private void Matrix_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int column = e.Column.DisplayIndex;
            int row = e.Row.GetIndex();
            if (int.TryParse(((TextBox)e.EditingElement).Text, out int value))
            {
                IMatrix[row, column] = value;
            }
            else
            {
                MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение
            
            if (IMatrix == null)
            {
                MessageBox.Show("Пустой массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveFileDialog saveDialog = new()
            {
                DefaultExt = ".matrix",
                Filter = "Матрица (*.txt)|*.txt|Все файлы|*.*"
            };

            if (saveDialog.ShowDialog() == true)
            {
                using StreamWriter stream = new(saveDialog.FileName);
                for (int row = 0; row < IMatrix.GetLength(0); row++)
                    stream.WriteLine(string.Join(' ', Enumerable.Range(0, IMatrix.GetLength(1)).Select(x => IMatrix[row, x]).ToArray()));
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Открыть файл

            OpenFileDialog openDialog = new()
            {
                DefaultExt = ".txt",
                Filter = "Матрица (*.txt)|*.txt|Все файлы|*.*"
            };

            if (openDialog.ShowDialog() == true)
            {
                using StreamReader stream = new(openDialog.FileName);

                string? line = stream.ReadLine();
                if (line is null)
                {
                    MessageBox.Show("Пустой файл!");
                    return;
                }

                int rowsCount = TotalRows(openDialog.FileName);
                int columnsCount = TotalColumns(line);
                int[,] result = new int[rowsCount, columnsCount];

                for (int row = 0; row < rowsCount; row++)
                {
                    if (line == null)
                        break;

                    string[] item = line.Split(' ');

                    for (int column = 0; column < columnsCount; column++)
                    {
                        if (int.TryParse(item[column], out int value))
                        {
                            result[row, column] = value;
                        }
                        else
                        {
                            result[row, column] = int.MinValue;
                        }
                    }

                    line = stream.ReadLine();
                }

                // Так надо
                IMatrix = result;
            }
        }

        private static int TotalRows(string path)
        {
            int i = 0;
            using (StreamReader stream = new(path))
                while (stream.ReadLine() != null)   
                    i++;
            return i;
        }

        private static int TotalColumns(string lineSample) => lineSample != null ? lineSample.Split(' ').Length : 0;

    }
    static class Convert
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr, string header = "Column ")
        {
            DataTable res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
                res.Columns.Add(header + (i + 1), typeof(T));

            DataRow row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
                row[i] = arr[i];

            res.Rows.Add(row);

            return res;
        }
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matrix, string header = "Column ")
        {
            DataTable res = new();
            for (int i = 0; i < matrix.GetLength(1); i++)
                res.Columns.Add(header + (i + 1), typeof(T));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataRow row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                    row[j] = matrix[i, j];
                res.Rows.Add(row);
            }
            return res;
        }


    }
}
