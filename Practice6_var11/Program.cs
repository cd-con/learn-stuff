for (int num = 300; num <= 600; num++)
{
	int sum = 0;
	for (int dividerNum = 1; dividerNum < num; dividerNum++)
	{
		if (num % dividerNum == 0)
		{
            sum += dividerNum;
        }			
	}

	if (sum % 10 == 0)
	{
		Console.WriteLine($"Число {num} имеет сумму делителей, кратную 10 ({sum})");
	}
}