int numSum = 0;
int numCount = 0;
string userInput = Console.ReadLine();

foreach (char item in userInput)
{
	if (char.IsDigit(item))
	{
		numCount++;
		numSum += int.Parse(item.ToString());
		userInput = userInput.Replace(item.ToString(), item + $"({10 - int.Parse(item.ToString())})");
	}
}
Console.WriteLine($"В введёной строке найдено: {numCount} чисел, общей суммой {numSum}");
Console.WriteLine($"Итоговая строка: {userInput}");

