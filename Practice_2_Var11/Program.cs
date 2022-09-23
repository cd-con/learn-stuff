string inputValue = "0";

for (; ; )
{
    ConsoleKey key = Console.ReadKey().Key;
    Console.Clear();

    if (key == ConsoleKey.Escape)
    {
        break;
    }

    inputValue = key == ConsoleKey.Backspace ? inputValue.Length > 1 ? inputValue.Remove(inputValue.Length - 1) : inputValue : int.Parse(inputValue.First().ToString()) > 0 ? inputValue + string.Join("", key.ToString().Where(val => char.IsDigit(val))) : string.Join("", key.ToString().Where(val => char.IsDigit(val)));

    Console.Write($"У меня в кармане {inputValue} ");

    int result;
    int.TryParse(inputValue, out result);

    result = result < 31 ? result % 20 : result % 10;

    switch (result)
    {
        case 1:
            Console.Write("рубль");
            break;

        case 2:
        case 3:
        case 4:
            Console.Write("рубля");
            break;

        default:
            Console.Write("рублей");
            break;
    }
}