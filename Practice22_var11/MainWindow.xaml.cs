using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Numerics;
using System.Windows.Media;
using System.IO;
using Microsoft.Win32;
using System.Data.Common;
using System.Windows.Shapes;

namespace Practice21_var11
{

    public partial class MainWindow : Window
    {
        // Сделаем нечестно - будем использовать отдельную матрицу
        private int[,] matrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InputHandler(object sender, TextChangedEventArgs args)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox == null)
            {
                throw new ArgumentNullException();
            }

            if (textBox.Text.Length == 0)
            {
                textBox.Text = "Введите значение";
                textBox.SelectAll();
            }
        }

        public bool inRange(int num, int[] range)
        {
            if (range == null)
                return true;
            return num >= range[0] && num <= range[1];
        }


        // Заполнение одномерной матрицей
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Val.Text, out int size))
            {
                GenerateArray(out matrix, 1, size);
                Update();
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
            {
                GenerateArray(out matrix, rows, columns);
                Update();
            }
            else
            {
                MessageBox.Show("Невалидный ввод");
            }
        }


        private void Update()
        {
            Matrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }


        public void GenerateArray(out int[,] array, int rows = 1, int columns = 1, int range_top = 10, int range_bottom = -10)
        {
            array = new int[rows, columns];
            Random random = new();

            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    array[row, column] = random.Next(range_bottom, range_top);
                }
            }
        }

        // Рассчёт первого задания
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (matrix == null)
            {
                MessageBox.Show("Пустой массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (matrix.GetLength(0) > 1)
            {
                MessageBox.Show("Это не одномерный массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    result += matrix[row, column] > 3 ? matrix[row, column] : 0;
                }
            }
            MessageBox.Show($"Результат 1 задачи: {Math.Sin(result)}");
        }

        // Решение второй задачи
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (matrix == null)
            {
                MessageBox.Show("Пустой массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string output = string.Empty;
            for (int column = 0; column < matrix.GetLength(1); column += 2)
            {
                int result = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    result += matrix[row, column];
                }
                output += $"Сумма элементов {column} столбца равна {result}.\n";
            }
            MessageBox.Show($"Результат 2 задачи:\n{output}");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            matrix = new int[0, 0];
            Update();
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
                matrix[row, column] = value;
                //Update();
            }
            else
            {
                MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение
            
            if (matrix == null)
            {
                MessageBox.Show("Пустой массив!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            SaveFileDialog dlg = new();

            // Тут
            dlg.DefaultExt = ".matrix";
            dlg.Filter = "Матрица (*.matrix)|*.matrix|Все файлы|*.*";

            if (dlg.ShowDialog() == true)
            {
                using (StreamWriter stream = new StreamWriter(dlg.FileName))
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        stream.WriteLine(string.Join(' ', Enumerable.Range(0, matrix.GetLength(1)).Select(x => matrix[row, x]).ToArray()));
                    }
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Открыть файл

            OpenFileDialog dlg = new();

            // Тут
            dlg.DefaultExt = ".matrix";
            dlg.Filter = "Матрица (*.matrix)|*.matrix|Все файлы|*.*";

            if (dlg.ShowDialog() == true)
            {
                using (StreamReader stream = new StreamReader(dlg.FileName))
                {
                    string? line = stream.ReadLine();
                    int rowsCount = TotalRows(dlg.FileName);
                    int columnsCount = TotalColumns(line);
                    matrix = new int[columnsCount, rowsCount];                                       

                    for (int row = 0; row < rowsCount; row++)
                    {
                        if (line == null)
                        {
                            break;
                        }

                        var item = line.Split(' ');
                        // Тут мне стало лень LINQ писать
                        for (int column = 0; column < columnsCount; column++)
                        {
                            // Доверимся пользователю и не будем проверять значения из файла
                            matrix[row, column] = int.Parse(item[column]);
                        }
                        line = stream.ReadLine();
                    }                        
                }
                Update();
            }
        }

        int TotalRows(string path)
        {
            int i = 0;
            using (StreamReader stream = new StreamReader(path))
                while (stream.ReadLine() != null)   
                    i++;
            return i;
        }

        int TotalColumns(string lineSample)
        {
            if (lineSample != null)
                return lineSample.Split(' ').Length;
            return 0;
        }
    }
    static class VisualArray
    {
        //Метод для одномерного массива
        public static DataTable ToDataTable<T>(this T[] arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Length; i++)
            {
                res.Columns.Add("Column " + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }
        //Метод для двухмерного массива
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                res.Columns.Add("Column " + (i + 1), typeof(T));
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }


    }
}
