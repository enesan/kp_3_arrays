// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

int k, l, n;
Console.Write("Введите l : ");
l = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите K : ");
k = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите N : ");
n = Convert.ToInt32(Console.ReadLine());

int[] a = new int[n];
Random r = new Random();
for (int i = 0; i < n; i++)
{
    a[i]= r.Next(l,k);
    Console.Write(a[i]+" " );
}

// %1
Console.WriteLine();
Console.WriteLine("введите: «0» - перемешать весь массив или «1» - перемешать первую половину массива " +
    "или «2» - перемешать вторую половину массива");
int t = Convert.ToInt32(Console.ReadLine());
if (t == 0)
{
    for (int i = n-1; i >=1; i--)
    {
        int j = r.Next(0,i+1);
        int pos = a[j];
        a[j] = a[i];
        a[i] = pos;
    }
    for (int i = 0; i < n; i++) Console.Write(a[i] + " ");
    
}
else if  (t == 1)
{
    for (int i =0; i < n/2; i++)
    {
        int j =r.Next(0,n/2);
        int pos = a[j];
        a[j] = a[i];
        a[i] = pos;
    }
    for (int i = 0; i < n; i++) Console.Write(a[i] + " ");
}
else if (t == 2)
{
    for (int i = n-1; i > (n / 2); i--)
    {
        int j = r.Next( n / 2,n-1);
        int pos = a[j];
        a[j] = a[i];
        a[i] = pos;
    }
    for (int i = 0; i < n; i++) Console.Write(a[i] + " ");

}
Console.WriteLine();

//%2
int s = 0, d =0 ,c =0;
for (int i = 0; i < n-1; i++)
{
    if (a[i] < a[i + 1])
    {
        s++;
        if (d > 0)
        {
            c++;
            d = 0;
        }
    }
    else if (a[i] > a[i + 1])
    {
        d++;
        if (s > 0)
        {
            c++;
            s= 0;
        }
    }
    else
    {
        if (d > 0 || s > 0)
        {
            c++;
            s = 0;
            d= 0;
        }
    }
}
if (s != 0 || d != 0) { c++; }

Console.WriteLine("Количество промежутков монотонности = " + c);

Console.WriteLine();

//%3
for (int i = 0; i < n - 1; i++)
{
    if (a[i] > 0 && a[i+1]>0)
    {
            Console.WriteLine($"Чередование знаков прерывает элемент с индексом {i + 1}");
            break;   
    }
    else if (a[i] < 0 && a[i+1]<0)
    {
            Console.WriteLine($"Чередование знаков прерывает элемент с индексом {i + 1}");
            break;
    }
    if (i == n - 2) Console.WriteLine($"В массиве чередуются положительные и отрицательные числа");
}
Console.WriteLine();

//%4

int sk= 1, mx = 0;
for (int i = 0; i < n - 1; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        if (a[i] == a[j]) sk++; 
    }
    if (sk > mx) mx = sk ; 
    sk = 1;
}
Console.WriteLine($"Максимальное количество одинаковых элементов = {mx}");