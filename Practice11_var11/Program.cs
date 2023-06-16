string userInput = Console.ReadLine();
char[] nums = new char[10];

// массив цыферок от 0 до 10
for (int i = 0; i < 10; i++)
{
    nums[i] = i.ToString()[0];
}

int numCounter = 0;
int numSumCounter = 0;
foreach (char c in userInput)
{
    if (nums.Contains(c))
    {
        numCounter++;
        numSumCounter += int.Parse(c.ToString());
        userInput = userInput.Replace(c.ToString(),c + $"({10- int.Parse(c.ToString())})");
    }
}
Console.WriteLine($"Всего чисел: {numCounter}; Сумма: {numSumCounter}");
Console.WriteLine(userInput);
