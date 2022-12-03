using System.Text;

Console.Write("Введите кол-во столбцов матрицы: ");
int.TryParse(Console.ReadLine(), out int matrixSizeX);

Console.Write("Введите кол-во строк матрицы: ");
int.TryParse(Console.ReadLine(), out int matrixSizeY);


int[,] matrix = new int[matrixSizeX, matrixSizeY];


for (int x = 0; x < matrixSizeX; x++)
{
    for (int y = 0; y < matrixSizeY; y++)
    {
        Console.Write($"[{x},{y}] = ");
        int.TryParse(Console.ReadLine(), out int value);
        matrix[x, y] = value;
    }
}
// Удали если списываешь
DrawMatrix(matrix);

int maxMultValue = 0;
int maxMultValueColumnID = 0;
for (int y = 0; y < matrixSizeY; y++)
{
    int columnMultValue = 1;
    for (int x = 0; x < matrixSizeX; x++)
    {
        columnMultValue *= matrix[x, y];
    }
    if (maxMultValue <= columnMultValue)
    {
        maxMultValue = columnMultValue;
        maxMultValueColumnID = y;
    }
}
Console.WriteLine($"Столбец {maxMultValueColumnID} имеет наибольший результат ({maxMultValue})");


// Отрисовка матрицы
// Кривое...
void DrawMatrix(int[,] matrix)
{
    int headerNumSize = matrix.GetLength(0).ToString().Length;
    int maxMatrixNumLength = getMaxNumLengthInMatrix(matrix);

    Console.Write(multiplyString("_", maxMatrixNumLength *2 + headerNumSize) + "|");

    for (int x = 0; x < matrix.GetLength(0); x++)
    {
        // Рисуем индекс
        int indexKeyLength = x.ToString().Length;
        Console.Write(multiplyString("_", maxMatrixNumLength + (maxMatrixNumLength - indexKeyLength)/2 ) + x + multiplyString("_", maxMatrixNumLength + (maxMatrixNumLength - indexKeyLength) / 2) + "|");
    }
    Console.WriteLine();
    
    for (int x = 0; x < matrix.GetLength(0); x++)
    {
        Console.Write(multiplyString("_", maxMatrixNumLength) + x + multiplyString("_", maxMatrixNumLength) + "|");
        for (int y = 0; y < matrix.GetLength(1); y++)
        {
            int valueLength = matrix[x, y].ToString().Length;
            Console.Write(multiplyString("_", maxMatrixNumLength + (maxMatrixNumLength - valueLength) / 2 ) + matrix[x,y] + multiplyString("_", maxMatrixNumLength + (maxMatrixNumLength - valueLength) / 2) + "|");
        }
        Console.WriteLine();
    }
}

string multiplyString(string s, int times)
{
    StringBuilder stringBuilder = new();
    for (int iter = 0; iter < times; iter++)
    {
        stringBuilder.Append(s);
    }
    return stringBuilder.ToString();
}

int getMaxNumLengthInMatrix(int[,] arr)
{
    int maxNum = 0;
    foreach (var item in arr)
    {
        maxNum = item > maxNum ? item : maxNum;
    }
    return maxNum.ToString().Length;
}
