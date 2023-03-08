using System;
using System.Globalization;

int N, L, K;
Random rnd = new Random();
N = Convert.ToInt32(Console.ReadLine());
L = Convert.ToInt32(Console.ReadLine());
K = Convert.ToInt32(Console.ReadLine());
int[] A = new int[N];
int[] B = new int[N];
for (int i = 0; i < N; i++)
{
    A[i]=rnd.Next(L,K);
    Console.Write("{0} ",A[i]);
}
Console.WriteLine("\n");
Console.WriteLine("Введите «0», «1» или «2»: «0» - перемешать весь массив «1» - перемешать первую половину массива «2» - перемешать вторую половину массива");
string deist;
deist = Console.ReadLine();

switch (deist)
{
    case "0":
        {
            for (int i = A.Length - 1; i >= 1; i--)
            {
                int j = rnd.Next(i + 1);
                var temp = A[j];
                A[j] = A[i];
                A[i] = temp;
            }
           
        }
        break;
    case "1":
        {
            for (int i = 0; i < N/ 2; i++)
            {
                int j = rnd.Next( N / 2);
                var temp = A[j];
                A[j] = A[i];
                A[i] = temp;
            }
        }
        break;
        case "2":
        {
            for (int i = N-1; i > (N / 2); i--)
            {
                int j = rnd.Next(N/2, N-1);
                var temp = A[j];
                A[j] = A[i];
                A[i] = temp;
            }
        }
        break;
}
for (int i = 0; i < N; i++)
{
    Console.Write("{0} ", A[i]);
}
Console.WriteLine("");
for (int i = 1; i < N; i++)
{
    if (A[i - 1] < A[i])
    {
        B[0] = A[i - 1];
        int c = 1;
        int d = i;
        while ((A[d - 1] < A[d]) & (d<N-1))
        {
            B[c] = A[d];
            c++;
            d++;
        }
        if (i == N - 1)
        {
            B[c] = A[i];
            c++;
        }
        var subArray = B[0..c];
        for (int j = 0; j < subArray.Length; j++)
        {
            Console.Write("{0} ",subArray[j]);
        }
        Console.WriteLine("");

    }

    if (A[i - 1] > A[i])
    {
        B[0] = A[i - 1];
        int c = 1;
        int d = i;
        while ((A[d - 1] > A[d]) &(d < N-1))
        {
            B[c] = A[d];
            c++;
            d++;
            
        }
        if (i == N - 1)
        {
            B[c] = A[i];
            c++;
        }
        var subArray = B[0..c];
        for (int j = 0; j < subArray.Length; j++)
        {
            Console.Write("{0} ", subArray[j]);
        }
        Console.WriteLine("");
    }
}

bool chet;
B[0] = A[0];
int counter=1;
if (A[0] > 0)
{
    chet = true;
}
else
{
    chet = false;
}
for (int i = 1; i < N; i++)
{
    if (chet)
    {
        if (A[i] < 0)
        {
            B[i] = A[i];
            chet = false;
            counter++;
        }
    }
    else
    {
        if (A[i] > 0)
        {
            B[i] = A[i];
            chet = true;
            counter++;
        }
    }
}

var subArray_2 = B[0..counter];
if (counter != B.Length)
{

    Console.WriteLine("Элемент на котором прервалась последовательность: {0}", subArray_2[^1]);
}
if (counter ==B.Length) 
{ 
    for (int i = 0; i < subArray_2.Length; i++)
    {
        Console.Write("{0} ", subArray_2[i]);
    }
}
counter = 0;
int maxcounter = 0;
for (int i = 0; i < A.Length-1; i++)
{
    for (int j = i; j < A.Length; j++)
    {
        if (A[i] == A[j])
        {
            counter++;
        }
    }
    if (maxcounter < counter)
    {
        maxcounter = counter;
    }
    counter = 0;
}
Console.WriteLine("Ответ на 4ое задание: {0}", maxcounter);
//int sc = 0;
//int sc_2 = 0;
//if (L >= 0)
//{
//    int[] resh = new int[K - L];
//    for (int i = 0; i < resh.Length; i++)
//    {
//        if (resh[i] == 1)
//        {
//            resh[i] = 0;
//        }
//    }
//    while (sc < K-1)
//    {
//        if (resh[sc] != 0)
//        {
//            sc_2 = sc + sc;
//            while (sc_2 <= K)
//            {
//                resh[sc_2] = 0;
//                sc_2=sc_2 + sc;
//            }
//        }
//        sc++;
//    }
//    foreach (int i in A)
//    {
//        for (int k = 0; k < resh.Length; k++)
//        {
//            if (i == resh[k])
//            {
//                Console.Write("{0} ", i);
//            }
//    }
//    }
//    for (int s=0; s < resh.Length; s++)
//    {
//        Console.Write("{0} ", resh[s]);
//    }
//}


//else
//{
//    L = 0;
//    int[] resh = new int[K - L];
//    for (int i = 0; i < resh.Length; i++)
//    {
//        if (resh[i] == 1)
//        {
//            resh[i] = 0;
//        }
//    }
//    while (sc < K-1)
//    {
//        if (resh[sc] != 0)
//        {
//            sc_2 = sc + sc;
//            while (sc_2 <= K)
//            {
//                resh[sc_2] = 0;
//                sc_2 = sc_2 + sc;
//            }
//        }
//        sc++;
//    }
//    foreach (int i in A)
//    {
//        for (int k = 0; k < resh.Length; k++)
//        {
//            if (i == resh[k])
//            {
//                Console.Write("{0} ", i);
//            }
//        }
//    }
//}






