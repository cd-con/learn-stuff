// Вводим путь
Console.Write("Введите путь до файла: ");
string path = Console.ReadLine();

// Решение
using (StreamReader sr = new(path))
{
    string readLine;
    int bCount = 0;
    int gCount = 0;
    while ((readLine = sr.ReadLine()) != null)
	{
        bCount += readLine.Count(c => c.ToString().ToLower() == "б");
        gCount += readLine.Count(c => c.ToString().ToLower() == "г");
	}
    Console.WriteLine($"В данном тексте было найдено {bCount} букв 'Б' и {gCount} букв 'Г'");
}
