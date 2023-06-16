using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Practice23_24_ULTIMATE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Color PenColor = new();
        double strokeSize = 1;
        public SolidColorBrush StrokeBrush = new();
        public SolidColorBrush FillBrush = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void ColorPicker_HEX_TextChanged(object sender, TextChangedEventArgs e)
        {

            Match regexMatch = Regex.Match(ColorPicker_HEX.Text, @"([0-9A-Fa-f]{6})");

            if (regexMatch.Success)
            {
                byte[] hexColors = StringToByteArray(regexMatch.Value);

                PenColor.R = hexColors[0];
                R.Value = Convert.ToInt32(PenColor.R);

                PenColor.G = hexColors[1];
                G.Value = Convert.ToInt32(PenColor.G);

                PenColor.B = hexColors[2];
                B.Value = Convert.ToInt32(PenColor.B);

                PenColor.A = 0xFF;
                Preview.Fill = new SolidColorBrush(PenColor);

                if (TargetFill.IsChecked == true)
                {
                    FillBrush.Color = PenColor;
                }
                else
                {
                    StrokeBrush.Color = PenColor;
                }
            }
        }

        private void Slider_ValueChanged(object sender, object _)
        {
            Slider slider = sender as Slider;
            switch (slider.Name)
            {
                case "R":
                    PenColor.R = Convert.ToByte(R.Value); break;
                case "G":
                    PenColor.G = Convert.ToByte(G.Value); break;
                case "B":
                    PenColor.B = Convert.ToByte(B.Value); break;
                default:
                    throw new NotImplementedException();
            }
            ColorPicker_HEX.Text = $"#{ByteArrayToString(new byte[] { PenColor.R, PenColor.G, PenColor.B })}";
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Скопируй эти значения в свой код
            // Фигура G
            Polygon G = new();
            G.Fill = FillBrush; G.Stroke = StrokeBrush; G.StrokeThickness = strokeSize;

            G.Points.Add(new Point(134, 244));
            G.Points.Add(new Point(136, 135));
            G.Points.Add(new Point(207, 132));
            G.Points.Add(new Point(207, 155));
            G.Points.Add(new Point(151, 156));
            G.Points.Add(new Point(151, 247));


            // Фигура A
            Polygon A = new();
            A.Fill = FillBrush; A.Stroke = StrokeBrush; A.StrokeThickness = strokeSize;

            A.Points.Add(new Point(223, 249));
            A.Points.Add(new Point(265, 141));
            A.Points.Add(new Point(295, 256));
            A.Points.Add(new Point(281, 256));
            A.Points.Add(new Point(268, 230));
            A.Points.Add(new Point(249, 230));
            A.Points.Add(new Point(242, 250));


            // Фигура A_smol
            Polygon A_smol = new();
            A_smol.Fill = Brushes.White; A_smol.Stroke = StrokeBrush; A_smol.StrokeThickness = strokeSize;

            A_smol.Points.Add(new Point(249, 217));
            A_smol.Points.Add(new Point(256, 205));
            A_smol.Points.Add(new Point(261, 215));


            // Фигура Z
            Polygon Z = new();
            Z.Fill = FillBrush; Z.Stroke = StrokeBrush; Z.StrokeThickness = strokeSize;

            Z.Points.Add(new Point(317, 166));
            Z.Points.Add(new Point(317.35, 153.91));
            Z.Points.Add(new Point(321.1, 145.98));
            Z.Points.Add(new Point(330.08, 144.89));
            Z.Points.Add(new Point(341.66, 149.17));
            Z.Points.Add(new Point(352.5, 156.64));
            Z.Points.Add(new Point(359.61, 165.56));
            Z.Points.Add(new Point(360.28, 174.48));
            Z.Points.Add(new Point(354.24, 182.72));
            Z.Points.Add(new Point(347.48, 191.51));
            Z.Points.Add(new Point(346.45, 201.91));
            Z.Points.Add(new Point(352.43, 210.97));
            Z.Points.Add(new Point(360.52, 218.31));
            Z.Points.Add(new Point(363.64, 226.59));
            Z.Points.Add(new Point(359.78, 236.45));
            Z.Points.Add(new Point(352.61, 246.23));
            Z.Points.Add(new Point(344.6, 253.88));
            Z.Points.Add(new Point(334.53, 256.79));
            Z.Points.Add(new Point(321.94, 253.19));
            Z.Points.Add(new Point(313.92, 246.72));
            Z.Points.Add(new Point(318.73, 242.17));
            Z.Points.Add(new Point(330.99, 237.3));
            Z.Points.Add(new Point(339.9, 229.22));
            Z.Points.Add(new Point(338.8, 221.54));
            Z.Points.Add(new Point(328.92, 215.57));
            Z.Points.Add(new Point(320.69, 208.77));
            Z.Points.Add(new Point(322.53, 199.27));
            Z.Points.Add(new Point(330.65, 189.34));
            Z.Points.Add(new Point(338.16, 180.88));
            Z.Points.Add(new Point(338.62, 174.39));
            Z.Points.Add(new Point(330.15, 169.72));
            Z.Points.Add(new Point(317, 166));

            mainCanvas.Children.Add(G);
            mainCanvas.Children.Add(A);
            mainCanvas.Children.Add(A_smol);
            mainCanvas.Children.Add(Z);
        }

        private void StrokeSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            strokeSize = StrokeSizeSlider.Value / 64;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainCanvas.Children.Clear();
        }

        void Test()
        {
            Polygon polygon = new Polygon();

            polygon.Hide();

            polygon.Show();

            polygon.MoveLocal(5, 5);
        }
    }

    public static class GenericObject
    {
        /// <summary>
        /// Нахождение суммы двух точек
        /// </summary>
        /// <param name="point"></param>
        /// <param name="newPoint"></param>
        /// <returns></returns>
        private static Point Sum(this Point point, Point newPoint) => new Point(point.X + newPoint.X, point.Y + newPoint.Y);

        /// <summary>
        /// Ищет родительский элемент заданного типа от дочернего элемента
        /// </summary>
        /// <typeparam name="T">Тип родительского элемента</typeparam>
        /// <param name="child">Объект дочернего элемента, от которого ведётся поиск</param>
        /// <returns></returns>
        private static T FindParent<T>(this DependencyObject child)  where T:DependencyObject
        {
            T parent = VisualTreeHelper.GetParent(child) as T;
            if (parent != null)
                return parent as T;
            return FindParent<T>(parent);
        }

        public static void MoveLocal<T>(this T objectReference, double x, double y) where T:Shape
        {
            if (objectReference != null)
            {
                if (objectReference.GetType() == typeof(Polygon))
                {
                    var obj = objectReference as Polygon;
                    for (int pointID = 0; pointID < obj.Points.Count; pointID++)
                        obj.Points[pointID] = obj.Points[pointID].Sum(new Point(x, y));
                }
                else if (objectReference.GetType() == typeof(Ellipse))
                {
                    var obj = objectReference as Ellipse;

                    Canvas.SetLeft(obj, Canvas.GetLeft(obj) + x);
                    Canvas.SetTop(obj, Canvas.GetTop(obj) + y);

                }
                else if (objectReference.GetType() == typeof(Rectangle))
                {
                    var obj = objectReference as Rectangle;

                    Canvas.SetLeft(obj, Canvas.GetLeft(obj) + x);
                    Canvas.SetTop(obj, Canvas.GetTop(obj) + y);
                }
                else
                {
                    throw new ArgumentException("Unsupported argument type");
                }

            }
            else
            {
                throw new ArgumentException("Unsupported argument type");
            }
        }

        public static void Show<T>(this T objectReference) where T : Shape
        {
            if (objectReference != null)
            {
                var obj = objectReference as Shape;
                obj.Opacity = 1;
            }
            else
            {
                throw new ArgumentException("Unsupported argument type");
            }

        }

        public static void Hide<T>(this T objectReference) where T : Shape
        {
            if (objectReference != null)
            {
                var obj = objectReference as Shape;
                obj.Opacity = 0;
            }
            else
            {
                throw new ArgumentException("Unsupported argument type");
            }
        }
    }
   
}
