// Задание 1
bool IsPower5(int K)
{
    int power = 1;

    while (K >= Math.Pow(5, power)){
        if (Math.Pow(5, power) == K)
        {
            return true;
        }
        power++;
    }
    return false;
};
void Swap<T>(ref T X, ref T Y) => (X,Y) = (Y,X);

// Создаём набор чисел
Random rnd = new();
int[] arr = new int[10];

Console.WriteLine("Тестовый массив:");
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rnd.Next(101);
    Console.Write(arr[i] + " ");
}
Console.WriteLine();

foreach (int item in arr)
{       
    Console.WriteLine($"Число {item} {(IsPower5(item) ? "является" : "не является")} степенью числа 5");
}

// Задание 2

Console.Write("Введите число А: ");
int.TryParse(Console.ReadLine(), out int A);
Console.Write("Введите число B: ");
int.TryParse(Console.ReadLine(), out int B);
Console.Write("Введите число C: ");
int.TryParse(Console.ReadLine(), out int C);
Console.Write("Введите число D: ");
int.TryParse(Console.ReadLine(), out int D);


Swap(ref A, ref B);
Swap(ref C, ref D);
Swap(ref B, ref C);
Console.Write($"A={A}; B={B}; C={C}; D={D}");