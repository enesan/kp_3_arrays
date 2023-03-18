using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int ind = 0;
            int[] a = { 2, 0,-9, 7, 8, -6,-3 };
            int n = a.Length;

            for (int i = 0; i < n - 1;i++ )
            {
                if ((a[i] >= 0 && a[i+1] >= 0) || (a[i] <= 0 && a[i + 1] <= 0))
                {
                    ind = i + 1;
                    break;
                }
            }
            Console.WriteLine(ind);


            Console.ReadLine();


        }
    }
}
