
internal class Program
{
    private static void Main()
    {
        // Для того, чтобы запустить одно из заданий, раскомментируй строчку (строчки) ниже

        // Exam.Task1();

        // Exam.Task2();

        // Exam.Task3();

        // Exam.Task4();

        // Для запуска этого задания, удали большой комментарий
        
        /*
        Trigale trigale = new(10, 8.8, 16);
        Console.WriteLine(trigale.GetPerimeter());
        Console.WriteLine(trigale.GetArea());
        */
    }


}

public class Exam
{
    static readonly Random random = new();
    public static void Task1()
    {
        if (int.TryParse(Console.ReadLine(), out int input))
            Console.WriteLine(input % 2 == 0);
    }

    public static void Task2()
    {
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            int result = 0;
            for (int q = 0; q < input; q++)
                result += (q % 3 == 0 || q % 5 == 0) ? q : 0;
            Console.WriteLine(result);
        }
    }

    public static void Task3()
    {
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            int[] arr = new int[input];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = random.Next(-100, 100);

            Console.WriteLine(string.Join(' ', arr));

            int result = 0;
            for (int q = 0; q < arr.Length; q++)
                result += arr[q] >= 0 ? arr[q] : 0;
            Console.WriteLine(result);
        }
    }

    public static void Task4()
    {
        if (int.TryParse(Console.ReadLine(), out int x) && int.TryParse(Console.ReadLine(), out int y))
        {
            int[,] matrix = new int[x, y];

            for (int _x = 0; _x < matrix.GetLength(0); _x++)
            {
                for (int _y = 0; _y < matrix.GetLength(1); _y++)
                    matrix[_x, _y] = random.Next(-100, 100);
            }

            // Вывод матрицы
            for (int _x = 0; _x < matrix.GetLength(0); _x++)
            {
                for (int _y = 0; _y < matrix.GetLength(1); _y++)
                    Console.Write($"{matrix[_x, _y]} ");
                Console.WriteLine();
            }

            int result = 0;
            for (int _x = 0; _x < matrix.GetLength(0); _x++)
            {
                for (int _y = 0; _y < matrix.GetLength(1); _y++)
                    result += ((_x + _y) % 2 == 0) ? matrix[_x, _y] : 0;
            }
            Console.WriteLine(result);
        }
    }
}

public class Trigale
{
    public double A { get; private set; }
    public double B { get; private set; }
    public double C { get; private set; }

    /// <summary>
    /// Конструктор класса треугольника. Позволяет узнать периметр и площадь по трём сторонам
    /// </summary>
    /// <param name="sideA">Сторона А</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    public Trigale(double sideA, double sideB, double sideC)
    {
        A = sideA;
        B = sideB;
        C = sideC;
    }


    /// <summary>
    /// Возвращает периметр треугольника.
    /// </summary>
    /// <returns>double периметр</returns>
    public double GetPerimeter() => A + B + C;

    /// <summary>
    /// Возвращает площадь треугольника
    /// </summary>
    /// <returns>double площадь</returns>
    public double GetArea()
    {
        double halfPerim = GetPerimeter() / 2d;
        return Math.Sqrt(halfPerim * (halfPerim - A) * (halfPerim - B) * (halfPerim - C));
    }

}

