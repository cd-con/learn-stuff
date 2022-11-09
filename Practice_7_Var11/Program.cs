Console.Write("Введите числа в массив череез запятую >>");
string input = Console.ReadLine();
int[] arr = input.Split(",").ToList().Select(num => int.Parse(num)).ToArray();

float result = 0;
int resCounter = 0;
foreach (int item in arr)
{
    if (item < 0)
    {
        resCounter++;
        result += item;
    }
}

result /= resCounter;
Console.WriteLine(result);
