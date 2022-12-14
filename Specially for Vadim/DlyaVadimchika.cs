namespace Practice_10_var_11
{
    internal class DlyaVadimchika
    {

        public static void Run()
        {
            // Инициализация массива
            int.TryParse(Console.ReadLine(), out int x);

            int[] arr = new int[x];
            Random rnd = new();

            for (int i = 0; i < x; i++)
            {
                arr[i] = rnd.Next(1000);
            }


            // Решение
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i-1] && arr[i] > arr[i + 1])
                {
                    arr[i] = 0;
                }
            }

            // Вывод
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
