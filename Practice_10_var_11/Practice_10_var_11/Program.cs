Console.Write("Введите размер массива: ");
int.TryParse(Console.ReadLine(), out int size);

int[] array = new int[size];
Random random = new Random();

for (int x = 0; x < size; x++)
{
    array[x] = random.Next(999);
}


foreach (var item in array.GroupBy(val => val).OrderByDescending(val_x => val_x.Count()))
{
    Console.WriteLine(item.Key);
}

// Решение 1. LINQ
// Группируем все числа, потом считаем их. Сортируем полученные значения по убыванию и получаем значение первого элемента.
Console.WriteLine($"Мода {array.GroupBy(val => val).OrderByDescending(val_x => val_x.Count()).First().Key}");

// Решение 2. Словарь

//        Число;  Его количество появлений (раз)
//         V      V
Dictionary<int, int> resDict = new Dictionary<int, int>();

foreach (int val in array)
{
    if (resDict.ContainsKey(val))
    {
        resDict[val]++;
    }
    else
    {
        resDict.Add(val, 1);
    }
}

var result = resDict.OrderByDescending(item => item.Value).First();
Console.WriteLine($"Мода {result.Key} ({result.Value})");