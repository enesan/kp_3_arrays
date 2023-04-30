using System;

Console.WriteLine("Введите n");
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите l");
int l = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите k");
int k = Convert.ToInt32(Console.ReadLine());
Random rand = new Random();
int[] a = new int[n];
for (int i = 0; i < n; i++)
{
    a[i] = rand.Next(l, k + 1);
    Console.Write(a[i]);
    Console.Write(" ");
}
Console.WriteLine("Как ты хочешь перемешать массив?");
Console.WriteLine("«0» - перемешать весь массив");
Console.WriteLine("«1» - перемешать первую половину массива");
Console.WriteLine("«2» - перемешать вторую половину массива");
int z = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("~~~Перемешиваю~~~");
Console.WriteLine("Результат: ");
if (z == 0)
{
    for (int i = a.Length - 1; i >= 0; i--)
    {
        int j = rand.Next(i);
        int t = a[i];
        a[i] = a[j];
        a[j] = t;
    }
    for (int i = 0; i < n; i++)
    {
        Console.Write(a[i]);
        Console.Write(" ");
    }
}
if (z == 1)
{
    for (int i = 0; i < n / 2; i++)
    {
        int j = rand.Next(i);
        int t = a[i];
        a[i] = a[j];
        a[j] = t;
    }
    for (int i = 0; i < n; i++)
    {
        Console.Write(a[i]);
        Console.Write(" ");
    }
}
if (z == 2)
{
    for (int i = n - 1; i > n / 2; i--)
    {
        int j = rand.Next(n / 2, i);
        int t = a[i];
        a[i] = a[j];
        a[j] = t;
    }
    for (int i = 0; i < n; i++)
    {
        Console.Write(a[i]);
        Console.Write(" ");
    }
}

//задание 2
Console.WriteLine();
Console.WriteLine("Элементы массива расположены по убыванию:");

bool in_seq = false;
for (int i = 0; i < n - 1; i++)
{
    if (a[i] > a[i + 1])
    {
        Console.Write(a[i]);
        Console.Write(" ");
        in_seq = true;
    }
    else if (in_seq)
    {
        Console.Write(a[i]);
        Console.Write(" | ");
        in_seq = false;
    }
}
if (in_seq)
{
    Console.Write(a[n - 1]);
    Console.Write(" | ");
}
Console.WriteLine();
Console.WriteLine("Элементы массива расположены по возрастанию:");
in_seq = false;
for (int i = 0; i < n - 1; i++)
{
    //Console.WriteLine("зашел");
    if (a[i] < a[i + 1])
    {
        Console.Write(a[i]);
        Console.Write(" ");
        in_seq = true;
    }
    else if (in_seq)
    {
        Console.Write(a[i]);
        Console.Write(" | ");
        in_seq = false;
    }
}
if (in_seq)
{
    Console.Write(a[n-1]);
    Console.Write(" | ");
}
Console.WriteLine();

//задание 3
bool last_is_pos = false;
bool now_is_pos = false;
int index_wrong = 0;
for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        last_is_pos = (a[i] >= 0);
        continue;
    }
    now_is_pos = (a[i] >= 0);
    if(now_is_pos == last_is_pos)
    {
        index_wrong = i;
        break;
    }
    last_is_pos = now_is_pos;
}
if (index_wrong == 0)
{
    Console.WriteLine("Числа в массиве чередуются");
}
else
{
    Console.Write("Числа в массиве не чередуются, индекс нарушения: ");
    Console.WriteLine(index_wrong);
}

//задание 4

Dictionary<int, int> counter = new Dictionary<int, int>();
for (int i = 0; i < n; i++)
{
    if (!counter.ContainsKey(a[i]))
    {
        counter[a[i]] = 0;
    }
    counter[a[i]]++;
}
int max = 0;
int maxValue = 0;
for (int i = 0; i < n; i++)
{
    if (maxValue < counter[a[i]])
    {
        maxValue = counter[a[i]];
        max = a[i];
    }
}

Console.Write("Самое частое: ");
Console.Write(max);
Console.Write(" встречается ");
Console.Write(maxValue);
Console.WriteLine(" раз");


//задание 5

bool[] resheto = new bool[k+1];
for(int i = 0; i < k+1; i++)
{
    resheto[i] = true;
}

for (int i = 2; i < k+1; i++)
{
    if (resheto[i] == false)
    {
        continue;
    }
    for (int j = i*2 ; j < k+1; j+=i)
    {
        resheto[j] = false;
    }
}

int simple = 0;
for (int i = 0; i < n; i++)
{
    if(a[i] < 0)
    {
        continue;
    }
    else if (resheto[a[i]])
    {
        simple++;
    }
}

Console.Write("Простых чисел: ");
Console.WriteLine(simple);

Console.ReadLine();
