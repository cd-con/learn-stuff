using System.Windows.Shapes;
using System.Windows;
using Point = System.Drawing.Point;

namespace Practice_DonJuan_Library
{
    /// <summary>
    /// �����, ����������� �������� ��������� ����� � 25 � 26 ������������
    /// </summary>
    public abstract class GenericFigure
    {
        public Shape[]? shapes;

        /// <summary>
        /// ������� ������ ������ �� ��������� �����.
        /// </summary>
        /// <returns></returns>
        public Shape GetShape()
        {
            return shapes[0];
        }

        /// <summary>
        /// ����������� ������ �� �������� ����������. ����������� - ������� ���������� � �������� ������.
        /// </summary>
        /// <param name="targetPos">���������� ��������</param>
        public abstract void MoveXY(Point targetPos);

        /// <summary>
        /// ����������� ������ �� �������� ����������. ������� ���������� abstract void MoveXY(Point targetPos)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void MoveXY(int X, int Y)
        {
            MoveXY(new Point(X, Y));
        }

        /// <summary>
        /// ������ ��� ������
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
        /// �������� ��� ������
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
