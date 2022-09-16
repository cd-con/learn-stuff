// Практическая #1 вариант #11

// Возвращает массив с числами, полученными из ввода пользователя
double[] getUserInput()
{
    Console.Write("Введите числа через точку с запятой:");
    string[] rawUserInput = Console.ReadLine().Split(";"); // Получаем "сырой" ввод пользователя в виде массива строк
    double[] userInput = new double[rawUserInput.Length]; // Создаём массив чисел, равный по длине массиву ввода
                                                          // Для выполнения условия задачи можно ограничить 3 элементами
    // Конвертируем массив строк в массив чисел
    for (int i = 0; i < rawUserInput.Length; i++)
    {
        userInput[i] = double.Parse(rawUserInput[i]);
    }

    return userInput; // Возвращаем
}

// Сортировка пузыриком
double[] bubbleSortInverted(double[] sortArray)
{
    for (int iter = 0; iter < sortArray.Length; iter++) // Проходим по массиву
    {
        for (int i = sortArray.Length - 1; i > 0; i--) // Оперируем с последним числом, двигаем его пока оно не будет меньше следущего
        {
            if (sortArray[i] > sortArray[i - 1])
            {
                // Метод 3 кружек :)
                double tempNum = sortArray[i - 1];
                sortArray[i - 1] = sortArray[i];
                sortArray[i] = tempNum;
            }
        }
    }
    return sortArray; // Возвращаем
}

// Вывод
foreach (double item in bubbleSortInverted(getUserInput()))
{
    Console.Write(item.ToString() + " ");
}
