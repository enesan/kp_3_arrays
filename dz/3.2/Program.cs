using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2
{
    internal class Program
    {
        static void Main(string[] args)

            //№ 2



        {
            string up = ""; string down = "";

            Random r = new Random();
            int l; int k; int n;
            n = Convert.ToInt32(Console.ReadLine()); l = Convert.ToInt32(Console.ReadLine()); k = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(l, k);
                Console.Write($" {a[i]} ");

            }
            Console.WriteLine();

            int p = Convert.ToInt32(Console.ReadLine());
            switch (p)
            {
                case 0:
                    for (int i = n - 1; i >= 0; i--)
                    {
                        int j = r.Next(n - 1);
                        int tmp = a[i];
                        a[i] = a[j]; a[j] = tmp;
                    }
                    break;
                case 1:
                    for (int i = n / 2; i >= 0; i--)
                    {
                        int j = r.Next( 0, n / 2);
                        int tmp = a[i];
                        a[i] = a[j]; a[j] = tmp;
                    }
                    break;
                case 2:
                    for (int i = n - 1; i >= n / 2; i--)
                    {
                        int j = r.Next( n / 2,n - 1);
                        int tmp = a[i];
                        a[i] = a[j]; a[j] = tmp;
                    }
                    break;

            }

            foreach (int i in a)
            {
                Console.Write(" " + i + " ");
            }Console.WriteLine();


            for (int i = 0; i < n - 2; i++)
            {

                if (a[i + 1] > a[i])
                {
                    //Console.WriteLine(up);
                    up = $"{up}" + $" {a[i]} " ;
                    if (a[i + 2] <= a[i + 1])
                    {
                        up = $"{up}" + $" {a[i + 1]} ";
                    }

                }
                else 
                {
                    up = $"{up}" + "_"; 
                }
                if (a[i + 1] < a[i])
                {

                    //Console.WriteLine(down);
                    down = $"{down}" + $" {a[i]} ";
                    if (a[i + 2] >= a[i + 1])
                    {
                        down = $"{down}" + $" {a[i + 1]} ";
                    }

                }
                else
                {
                    down = $"{down}" + "_"; 
                }
            }


            if (a[a.Length-1] > a[a.Length - 2])
            {
                up = $"{up} " + a[a.Length - 2] + " " + a[a.Length - 1];
            }
            if (a[a.Length - 1] < a[a.Length - 2])
                {
                   down = $"{down} " + a[a.Length - 2] + " " + a[a.Length - 1];
                }


            Console.WriteLine($"up: {up}");
            Console.WriteLine($"down: {down}");

            
            Console.ReadLine();
        }
    }
}

            
   

