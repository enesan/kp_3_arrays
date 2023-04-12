using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_4_dop
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            int c = 0, c_mx = 0;
            for (int i = 0; i < n; i++)
            {
                c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (a[j] == i)
                    {
                        c++;
                       
                    } 
                    
                }
                if (c_mx < c)
                            c_mx = c;
            }
            Console.WriteLine(c_mx);



            Console.ReadKey();
        }
    }
}
