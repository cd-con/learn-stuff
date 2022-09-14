// Конвертация массива из строк в лист чисел
List<int> convertStrArrayToIntList(string[] list)
{
    List<int> result = new List<int>();
    foreach (string obj in list)
    {
        _ = int.TryParse(obj, out int x);
        result.Add(x);
    }
    return result;
}

// Решение
List<int> getSumOfTwoNumsWhichEqualsConst()
{
    List<int> a = convertStrArrayToIntList(Console.ReadLine().Split(","));
    HashSet<int> hash = new HashSet<int>();
    int k = int.Parse(Console.ReadLine());

    foreach (int num in a)
    {
        if (hash.Contains(num))
        {
            return new List<int>() { num, k - num };
        }
        hash.Add(k - num);
    }
    return new List<int> { 0 };
}

// Вывод результата
foreach (int num in getSumOfTwoNumsWhichEqualsConst())
{
    Console.WriteLine(num);
}