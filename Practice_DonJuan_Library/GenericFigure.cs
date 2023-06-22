using System.Windows.Shapes;
using System.Windows;
using Point = System.Drawing.Point;

namespace Practice_DonJuan_Library
{
    /// <summary>
    /// Класс, описывающий основное поведение фигур в 25 и 26 практической
    /// </summary>
    public abstract class GenericFigure
    {
        public Shape[]? shapes;

        /// <summary>
        /// Возврат первой фигуры из хранилища фигур.
        /// </summary>
        /// <returns></returns>
        public Shape GetShape()
        {
            return shapes[0];
        }

        /// <summary>
        /// Перемещение фигуры на заданные координаты. Абстрактный - требует реализации в дочернем классе.
        /// </summary>
        /// <param name="targetPos">Координата смещения</param>
        public abstract void MoveXY(Point targetPos);

        /// <summary>
        /// Перемещение фигуры на заданные координаты. Требует реализации abstract void MoveXY(Point targetPos)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void MoveXY(int X, int Y)
        {
            MoveXY(new Point(X, Y));
        }

        /// <summary>
        /// Скрыть все фигуры
        /// </summary>
        public void Hide()
        {
            if (shapes != null)
            {
                foreach (Shape item in shapes)
                    item.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Показать все фигуры
        /// </summary>
        public void Show()
        {
            if (shapes != null)
            {
                foreach (Shape item in shapes)
                    item.Visibility = Visibility.Visible;
            }
        }
    }
}
