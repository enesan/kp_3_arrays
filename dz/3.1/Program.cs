using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            ///№ 1


            Random r = new Random();
            int l; int k; int n;
            n = Convert.ToInt32(Console.ReadLine()); l = Convert.ToInt32(Console.ReadLine()); k = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(l, k);
                Console.Write($" {a[i]} ");
                
            }Console.WriteLine();

            int p = Convert.ToInt32(Console.ReadLine());
            switch(p)
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
                    for (int i = n / 2 ; i >= 0; i--)
                    {
                        int j = r.Next(0, n / 2);
                        int tmp = a[i];
                        a[i] = a[j]; a[j] = tmp;
                    }
                    break;
                case 2:
                    for (int i = n - 1; i >= n / 2; i--)
                    {
                        int j = r.Next(n / 2, n -1);
                        int tmp = a[i];
                        a[i] = a[j]; a[j] = tmp;
                    }
                    break;

            }

            foreach (int i in a)
            {
                Console.Write(" " + i + " ");
            }

            Console.ReadLine();
        }
    }
}
