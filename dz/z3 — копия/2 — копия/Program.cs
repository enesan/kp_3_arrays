using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Random r = new Random();
            //int l; int k; int n;
            //n = Convert.ToInt32(Console.ReadLine()); l = Convert.ToInt32(Console.ReadLine()); k = Convert.ToInt32(Console.ReadLine());
            //int[] a = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    a[i] = r.Next(l, k);
            //    Console.Write($" {a[i]} ");

            //}
            //Console.WriteLine();


            string up = "-"; string down = "";
            
            int[] a = { 1, 4, 4, 1, 3, 7, 1, 0, 1 };int n = a.Length;
            if (a[0] < a[1]) { up = up + a[0]; }
            for (int i = 1; i < n; i++)
            {
                
                if (a[i - 1] < a[i])
                {

                    Console.WriteLine(up);
                    up = $"{up}" + $"{a[i-1]}";
                }
                else { up = $"{up}" + ",";Console.WriteLine("!"); }
            }

            Console.WriteLine(up);
            //foreach (int i in a)
            //{
            //    Console.Write(" " + i + " ");
            //}
            Console.ReadLine();
        }
    }
}
