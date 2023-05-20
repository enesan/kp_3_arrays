
int n = Convert.ToInt32(Console.ReadLine());
int l = Convert.ToInt32(Console.ReadLine());
int k = Convert.ToInt32(Console.ReadLine());

Random rnd = new Random();
int[] array = new int[n];

for (int i = 0; i < array.Length; i++)
    array[i] = rnd.Next(l, k);

foreach (int i in array)
{
    Console.WriteLine(i);
}

//1
string input = new(Console.ReadLine());

switch (input)
{
    case "0":
        for (int i = array.Length - 1; i >= 1; i--)
        {
            int j = rnd.Next(i + 1);
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
        break;
    case "1":
        for (int i = 0; i < (n / 2); i++)
        {
            int j = rnd.Next(n / 2);
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
        break;
    case "2":
        for (int i = (n - 1); i < (n / 2); i--)
        {
            int j = rnd.Next(n / 2, n - 1);
            var temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
        break;
    default:
        Console.WriteLine("Неверный выбор");
        return;
}
foreach (int i in array)
{
    Console.WriteLine(i);
}

//2
int start = 0;
for (int i = 1; i < n; i++)
{
    if ((array[i] > array[i - 1] && i < n - 1 && array[i] > array[i + 1]) ||
        (array[i] < array[i - 1] && i < n - 1 && array[i] < array[i + 1]) ||
        (array[i] > array[i - 1] && i == n - 1))
    {
        for (int j = start; j <= i; j++)
        {
            Console.Write(array[j] + " ");
        }
        start = i;
    }
}

//3
bool flag = true;
for (int i = 1; i < n; i++)
{
    if (Math.Sign(array[i]) == Math.Sign(array[i - 1]))
    {
        Console.WriteLine($"Элемент с индексом {i} нарушает закономерность.");
        flag = false;
        break;
    }
}
if (flag)
{
    Console.WriteLine("Положительные и отрицательные элементы чередуются.");
}

//4
int count = 0;
int maxcount = 0;
for (int i = 0; i < array.Length - 1; i++)
{
    for (int j = i; j < array.Length; j++)
    {
        if (array[i] == array[j])
        {
            count++;
        }
    }
    if (maxcount < count)
    {
        maxcount = count;
    }
    count = 0;
}
Console.WriteLine($"Максимальное количество одинаковых элементов в массиве: {maxcount}");