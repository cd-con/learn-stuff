using Practice_DonJuan_Library;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Practice_DonJuan_26
{
    /// <summary>
    /// Универсальная (почти) логика взаимодействия для практических 25 и 26
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isLineHidden = false;
        private bool isRectHidden = false;

        private MyLine line;
        private MyRectangle rect;

        public MainWindow()
        {
            InitializeComponent();
            line = new(new(25, 25), new(75, 75), canvasRef: MainCanvas);
            rect = new(new(100, 100), 50, 50, canvasRef: MainCanvas);
            MainCanvas.Children.Add(line.lineVisualisation);
            MainCanvas.Children.Add(rect.rectangleVisualisation);
        }

        private void AboutPractice_Click(object o, RoutedEventArgs e)
        {
            MessageBox.Show("Практическую выполнил Сазонов Иван, ИСП-21", "О программе");
        }

        private void HideFigure_Click(object sender, RoutedEventArgs e)
        {
            if (Line.IsChecked.ToSafeBool())
            {
                isLineHidden = !isLineHidden;

                if (isLineHidden)
                    line.Hide();
                else
                    line.Show();
            }
            else
            {
                isRectHidden = !isRectHidden;
                if (isRectHidden)
                    rect.Hide();
                else
                    rect.Show();
            }
            UpdateButtons();
        }

        private void ApplyOffset_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(OffsetX.Text, out int X) && int.TryParse(OffsetY.Text, out int Y))
                if (Line.IsChecked.ToSafeBool())
                {
                    line.MoveXY(new(X,Y));
                }
                else
                {
                    rect.MoveXY(new(X, Y));
                }
            else
                MessageBox.Show("Невозможно сместить фигуру по заданным координатам", "Ошибка!");
        }

        private void ChangeTextHandler(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = "0";
        }

        private void Rect_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (Line.IsChecked.ToSafeBool())
            {
                HideFigure.IsEnabled = !isLineHidden;
                ShowFigure.IsEnabled = isLineHidden;
            }
            else
            {
                HideFigure.IsEnabled = !isRectHidden;
                ShowFigure.IsEnabled = isRectHidden;
            }
        }
    }

    public static class Utility
    {
        public static System.Drawing.Point ToClassicPoint(this MyPoint point)
        {
            return new(point.X, point.Y);
        }

        public static bool ToSafeBool(this bool? a)
        {
            return a != null && a.Value;
        }
    }

    public class MyPoint : GenericFigure
    {
        public int X;
        public int Y;

        public MyPoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override void MoveXY(System.Drawing.Point targetPos)
        {
            X += targetPos.X;
            Y += targetPos.Y;
        }
    }

    public class MyLine : MyPoint
    {
        public MyPoint destination;
        public Line lineVisualisation { get; private set; }

        protected Canvas _canvasRef;

        protected bool isOutOfBounds = false;
        public MyLine(MyPoint from, MyPoint to, bool addToRenderer = true, Canvas canvasRef = null) : base(from.X, from.Y)
        {
            destination = to;

            if (addToRenderer)
            {
                lineVisualisation = new Line() { Stroke = Brushes.Black, X1 = X, Y1 = Y, X2 = to.X, Y2 = to.Y };
                // Костыль!!!
                shapes = new Shape[1];
                shapes[0] = lineVisualisation;
            }
            _canvasRef = canvasRef;
        }
        public override void MoveXY(System.Drawing.Point targetPos)
        {
            
            if (X + destination.X + targetPos.X  > _canvasRef.ActualHeight || Y + destination.Y + targetPos.Y > _canvasRef.ActualWidth || X + targetPos.X < 0 || Y + targetPos.Y < 0)
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

            base.MoveXY(targetPos);
            destination.MoveXY(targetPos);

            if (lineVisualisation != null)
            {
                lineVisualisation.X1 = X;
                lineVisualisation.Y1 = Y;

                lineVisualisation.X2 = destination.X;
                lineVisualisation.Y2 = destination.Y;
            }
        }
    }

    /// <summary>
    /// Отрисовка прямоугольника на основе диагонали
    /// </summary>
    public class MyRectangle : MyLine 
    {
        public Rectangle rectangleVisualisation;
        
        // Я не знаю уже, куда запихать это наследование, ибо оно здесь вообще не нужно и мы делаем из велосипеда вундервафлю
        public MyRectangle(MyPoint offset, int w, int h, Canvas canvasRef): base(offset, new(offset.X + h, offset.Y + w), false, canvasRef)
        {
            rectangleVisualisation = new() { Stroke = Brushes.Black, Width = w, Height = h };
            // Костыль!!!
            shapes = new Shape[1];
            shapes[0] = rectangleVisualisation;
            MoveXY(offset.ToClassicPoint());
        }

        public override void MoveXY(System.Drawing.Point targetPos)
        {
            if (X + destination.X + targetPos.X > _canvasRef.ActualHeight || Y + destination.Y + targetPos.Y > _canvasRef.ActualWidth || X + targetPos.X < 0 || Y + targetPos.Y < 0)
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

            base.MoveXY(targetPos);
            Canvas.SetTop(rectangleVisualisation, X);
            Canvas.SetLeft(rectangleVisualisation, Y);
        }
    }
}
