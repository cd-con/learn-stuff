Console.Write("Введите К >> ");
int.TryParse(Console.ReadLine(), out int k);

int chainElement;
float minDistanceBetween2Nums = k;
int result = 0;

do
{
    int.TryParse(Console.ReadLine(), out chainElement);
    if (chainElement == k)
    {
        Console.WriteLine("Нельзя ввести элемент последовательности, равный K");
        continue;
    }
    float dist = MathF.Abs(k - chainElement);
    result = minDistanceBetween2Nums > dist?chainElement:result;
    minDistanceBetween2Nums = minDistanceBetween2Nums > dist ? dist : minDistanceBetween2Nums;

} while (chainElement != 1000);

Console.WriteLine($"Число {k} ближе всего к числу {result}");