using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Practice_DonJuan_Library;
namespace Practice_DonJuan
{
    /// <summary>
    /// Универсальная (почти) логика взаимодействия для практических 25 и 26
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isHidden = false;
        private CanvasWindow window;
        public MainWindow()
        {
            InitializeComponent();
            window = new CanvasWindow(MainCanvas);
            
        }

        private void AboutPractice_Click(object o, RoutedEventArgs e)
        {
            MessageBox.Show("Практическую выполнил Сазонов Иван, ИСП-21", "О программе");
        }

        private void HideFigure_Click(object sender, RoutedEventArgs e)
        {
            isHidden = !isHidden;

            HideFigure.IsEnabled = !isHidden;
            ShowFigure.IsEnabled = isHidden;
            
            if (isHidden)
                window.Hide();
            else
                window.Show();
        }

        private void ApplyOffset_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(OffsetX.Text, out int X) && int.TryParse(OffsetY.Text, out int Y))
                window.MoveXY(X, Y);
            else
                MessageBox.Show("Невозможно сместить фигуру по заданным координатам", "Ошибка!");
        }

        private void ChangeTextHandler(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = "0";
        }
    }

    /// <summary>
    /// Окно. Используем немного иное имя, дабы избежать ошибок с System.Windows.Window
    /// </summary>
    public class CanvasWindow : GenericFigure
    {
        private Canvas _canvasRef;
        private int _sizeMul;
        private bool isOutOfBounds = false;
        public CanvasWindow(Canvas canvasReference, int sizeMul = 1, double initialOffsetX = 100, double initialOffsetY = 100)
        {
            _canvasRef = canvasReference;
            _sizeMul = sizeMul;
            shapes = new Shape[3];
            // Рамка окна
            shapes[0] = new Rectangle() { Height = 100 * sizeMul, Width = 100 * sizeMul, Stroke = Brushes.Black, StrokeThickness = 4, Fill = Brushes.Yellow };
            shapes[0].Margin = new Thickness(initialOffsetX, initialOffsetY, 0, 0); // Сделано через Margin во избежание конфликтов при проверке координат в функции MoveXY

            // Вертикальная перекладина
            shapes[1] = new Line() { X1 = initialOffsetX, Y1 = initialOffsetY + 50 * sizeMul, X2 = initialOffsetX + 100 * sizeMul, Y2 = initialOffsetY + 50 * sizeMul, Stroke = Brushes.Black, StrokeThickness = 2 };
            // Горизонтальная перекладина
            shapes[2] = new Line() { X1 = initialOffsetX + 50 * sizeMul, Y1 = initialOffsetY, X2 = initialOffsetX + 50 * sizeMul, Y2 = initialOffsetY + 100 * sizeMul, Stroke = Brushes.Black, StrokeThickness = 2 };

            foreach (Shape shape in shapes)
            {
                _canvasRef.Children.Add(shape);
            }
        }
        public override void MoveXY(System.Drawing.Point targetPos)
        {
            if (shapes[0].Margin.Top + targetPos.X + 100 * _sizeMul > _canvasRef.ActualHeight || shapes[0].Margin.Left + targetPos.Y + 100 * _sizeMul > _canvasRef.ActualWidth || shapes[0].Margin.Top + targetPos.X < 0 || shapes[0].Margin.Left + targetPos.Y < 0)
            {
                if (!isOutOfBounds)
                {
                    if (MessageBox.Show("Указанные координаты переместят фигуру за пределы поля отрисовки.\nПродолжить?", "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel)
                        return;
                    isOutOfBounds = true;
                }
            }
            else
                isOutOfBounds = false;

            foreach (Shape shape in shapes)
                  shape.Margin = new Thickness(shape.Margin.Left + targetPos.Y, shape.Margin.Top + targetPos.X, 0, 0);
        }
    }
}
