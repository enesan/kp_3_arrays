using System;

int N = Convert.ToInt32(Console.ReadLine());
int L = Convert.ToInt32(Console.ReadLine());
int K = Convert.ToInt32(Console.ReadLine());
int[] A = new int[N];
int choise_1;
// создание массива
for (int i = 0; i < N; i++)
{
    Random rnd = new Random();
    A[i] = rnd.Next(L, K + 1);
    Console.Write($"{A[i]} ");
}
Console.WriteLine();
// преобразование массива
do
{
    choise_1 = Convert.ToInt32(Console.ReadLine());
} while (choise_1 > 2 || choise_1 < 0);
if (choise_1 == 0)
{
    for (int i = A.Length - 1; i >= 1; i--)
    {
        Random rnd = new Random();
        int j = rnd.Next(i + 1);
        int temp = A[j];
        A[j] = A[i];
        A[i] = temp;
    }
}
else if (choise_1 == 1)
{
    for (int i = (A.Length / 2) - 1; i >= 1; i--)
    {
        Random rnd = new Random();
        int j = rnd.Next(i + 1);
        int temp = A[j];
        A[j] = A[i];
        A[i] = temp;
    }
}
else if (choise_1 == 2)
{
    for (int i = A.Length - 1; i >= A.Length / 2; i--)
    {
        Random rnd = new Random();
        int j = rnd.Next(A.Length / 2, i + 1);
        int temp = A[j];
        A[j] = A[i];
        A[i] = temp;
    }
}
foreach (int i in A)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
// определение кол-ва промежутков монотонности
int counter_more = 0, counter_less = 0, end_counter = 0;
for (int i = 0; i < A.Length - 1; i++)
{
    if (A[i] < A[i + 1])
    {
        counter_more++;
        if (counter_less > 0)
        {
            end_counter++;
            counter_less = 0;
        }

    }
    else if (A[i] > A[i + 1])
    {
        counter_less++;
        if (counter_more > 0)
        {
            end_counter++;
            counter_more = 0;
        }
    }
    else
    {
        if (counter_less > 0 || counter_more > 0)
        {
            end_counter++;
            counter_more = 0;
            counter_less = 0;
        }
    }

}
if (counter_more != 0 || counter_less != 0) { end_counter++; }
Console.WriteLine($"Количество промежутков монотонности = {end_counter}.");
// чередование знаков
for (int i = 0; i < A.Length - 1; i++)
{
    if (A[i] > 0)
    {
        if (A[i + 1] > 0)
        {
            Console.WriteLine($"Чередование знаков прерывает элемент с индексом {i + 1}");
            break;
        }
    }
    else if (A[i] < 0)
    {
        if (A[i + 1] < 0)
        {
            Console.WriteLine($"Чередование знаков прерывает элемент с индексом {i + 1}");
            break;
        }
    }
    else { Console.WriteLine($"Чередование знаков прерывает элемент с индексом {i}"); break; }
    if (i == A.Length - 2) { Console.WriteLine($"В массиве чередуются положительные и отрицательные числа."); }
}
// максимальное кол-во одинаковых чисел
int schetchik = 1, end_schetchik = 0;
for (int i = 0; i < A.Length - 1; i++)
{
    for (int j = i + 1; j < A.Length; j++)
    {
        if (A[i] == A[j]) { schetchik++; }
    }
    if (schetchik > end_schetchik) { end_schetchik = schetchik; }
    schetchik = 1;
}
Console.WriteLine($"Максимальное количество одинаковых элементов = {end_schetchik}.");
// поиск простых чисел
int prostoy_schetchik = 0, end_prostoy_schetchik = 0; 
for (int i = 0; i < A.Length; i++)
{
    if (A[i] > 1)
    {
        for (int j = 2; j < Math.Sqrt(A[i]); j++)
        {
            if (A[i] % j == 0) 
            {
                prostoy_schetchik++;
            }
        }
        if (prostoy_schetchik == 0)
        {
            end_prostoy_schetchik++;
        }
        prostoy_schetchik = 0;
    }    
}
Console.WriteLine($"Количество простых чисел = {end_prostoy_schetchik}.");