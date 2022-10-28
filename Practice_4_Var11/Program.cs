using Practice_4_Var11;

int.TryParse(Console.ReadLine(), out int x);

int fibChain2 = 0;
int fibChain1 = 1;
int fibChain0 = 1;

while (fibChain0 < x)
{
    Console.WriteLine(fibChain0);
    fibChain0 = fibChain2 + fibChain1;
    (fibChain2, fibChain1) = (fibChain1, fibChain0);

}
Console.WriteLine(fibChain0);
Console.Write($"Число {x}");
Console.Write(fibChain0 == x ? " находится в последовательности Фиббоначи" : " не находится в последовательности Фиббоначи");