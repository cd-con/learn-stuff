// Практическая #1 вариант #11

// Возвращает массив с числами, полученными из ввода пользователя
double[] getUserInput()
{
    Console.Write("Введите числа через точку с запятой: ");
    string[] rawUserInput = Console.ReadLine().Split(";"); // Получаем "сырой" ввод пользователя в виде массива строк

    return rawUserInput.Select(s => double.Parse(s)).ToArray(); ; // Возвращаем
}

// Сортировка пузыриком
double[] bubbleSortInverted(double[] sortArray)
{
    Array.Sort(sortArray);

    return sortArray.Reverse().ToArray(); // Возвращаем
}


// Вывод
Console.Write(string.Join(" ", bubbleSortInverted(getUserInput())));
