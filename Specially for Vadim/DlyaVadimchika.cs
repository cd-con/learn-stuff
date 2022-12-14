namespace Practice_10_var_11
{
    internal class DlyaVadimchika
    {

        public static void Run()
        {
            Console.Write("Введите кол-во столбцов матрицы: ");
            int.TryParse(Console.ReadLine(), out int matrixSizeX);

            Console.Write("Введите кол-во строк матрицы: ");
            int.TryParse(Console.ReadLine(), out int matrixSizeY);


            int[,] matrix = new int[matrixSizeX, matrixSizeY];


            for (int x = 0; x < matrixSizeX; x++)
            {
                for (int y = 0; y < matrixSizeY; y++)
                {
                    Console.Write($"[{x},{y}] = ");
                    int.TryParse(Console.ReadLine(), out int value);
                    matrix[x, y] = value;
                }
            }

            int minMultValue = int.MaxValue;
            int minMultValueColumnID = 0;
            for (int y = 0; y < matrixSizeY; y++)
            {
                int columnMultValue = 1;
                for (int x = 0; x < matrixSizeX; x++)
                {
                   columnMultValue *= matrix[x, y];
                }
                if (minMultValue > columnMultValue)
                {
                    minMultValue = columnMultValue;
                    minMultValueColumnID = y;
                 }
             }
            Console.WriteLine($"Столбец {minMultValueColumnID} имеет наименьший результат ({minMultValue})");
        }
    }
}
