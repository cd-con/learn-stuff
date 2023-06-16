Console.Write("Введите размер массива: ");
int.TryParse(Console.ReadLine(), out int size);

int[] array = new int[size];
Random random = new Random();

for (int x = 0; x < size; x++)
{
    array[x] = random.Next(999);
    Console.Write(array[x] + " ");
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

// Решение 3. Бонус! Гномья сортировка
/*
int step = 1;
while (step < array.Length)
{
    step += step == 0 ? 1 : 0;
    if (array[step - 1] > array[step])
    {
        (array[step - 1], array[step]) = (array[step], array[step - 1]);
        step--;
    }
    else
    {
        step++;
    }
}
for (int x = 0; x < size; x++)
{
    Console.Write(array[x] + " ");
}
int numCount = 0;
int numCountMax = 0;
int numCountMaxNum = 0;
for (int i = 1; i < array.Length; i++)
{
    if (array[i - 1] == array[i])
    {
        numCount++;
    }
    if(numCount > numCountMax)
    {
        numCountMax = numCount;
        numCountMaxNum = array[i-1];
    }
}
Console.WriteLine($"Мода {numCountMaxNum} ({numCountMax})");
*/