double result = 0;
for (double n = 2; n <= 100; n++)
{
    result += 1 / ((n - 1) * (n + 1));
}

Console.WriteLine("Результат вычисления: " + result + " - Проверка: " + 3d/4d + " - Погрешность: " + Math.Abs(3d / 4d - result) + " - Входит ли число в предел погрешности? " + (Math.Abs(3d/4d - result) < 0.1d));
