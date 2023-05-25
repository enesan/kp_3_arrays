using System;

namespace CSLight
{
   internal class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Введите длину массива:");
         int n = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("Введите диапазон значений:");
         int l = Convert.ToInt32(Console.ReadLine());
         int k = Convert.ToInt32(Console.ReadLine());

         int[] a = new int[n];
         Random rnd = new Random();
         for (int i = 0; i < n; i++) { a[i] = rnd.Next(l, k); Console.Write($"{a[i]} "); }
         Console.WriteLine("\n");

         //перемешивание
         Console.WriteLine("Введите 0 чтобы перемешать весь массив, 1 - первую половину, 2 - вторую половину:");
         int choise = Convert.ToInt32(Console.ReadLine());
         if (choise == 0)
         {
            for (int i = n - 1; i >= 0; i--)
            {
               int j = rnd.Next(i + 1);
               (a[i], a[j]) = (a[j], a[i]);
            }
         }
         else if (choise == 1)
         {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
               int j = rnd.Next(n / 2);
               (a[i], a[j]) = (a[j], a[i]);
            }
         }
         else if (choise == 2)
         {
            for (int i = n - 1; i >= n / 2; i--)
            {
               int j = rnd.Next(n / 2, i + 1);
               (a[i], a[j]) = (a[j], a[i]);
            }
         }
         for (int i = 0; i < n; i++) { Console.Write($"{a[i]} "); }
         Console.WriteLine("\n");

         //интервалы монотонности
         Console.WriteLine("Интервалы монотонности");
         for (int i = 1; i < n; i++)
         {
            if (a[i - 1] < a[i])
            {
               while (a[i - 1] < a[i]) { Console.Write(a[i - 1] + " "); i++; if (i == n) break; }
               Console.Write(a[i - 1] + "\n");
               i--;
            }
            else if (a[i - 1] > a[i])
            {
               while (a[i - 1] > a[i]) { Console.Write(a[i - 1] + " "); i++; if (i == n) break; }
               Console.Write(a[i - 1] + "\n");
               i--;
            }
         }
         Console.WriteLine();

         //проверка на чередование
         bool flag = true;
         for (int i = 0; i < n - 1; i++)
         {
            if ((a[i + 1] > 0 & a[i] > 0) || (a[i + 1] < 0 & a[i] < 0) || (a[i]) == 0)
            {
               flag = false;
               if (a[i] == 0) { Console.WriteLine($"Чередование прерывает элемент с индексом {i}"); }
               else { Console.WriteLine($"Чередование прерывает элемент с индексом {i + 1}"); }
               break;
            }
         }
         if (flag) { Console.WriteLine("Знаки чередуются"); }
         Console.WriteLine();

         //максимальное количество повторяющихся элементов
         int count, maxcount = 0;
         for (int i = 0; i < n; i++)
         {
            count = 1;
            for (int j = i + 1; j < n; j++)
            {
               if (a[i] == a[j]) { count++; }
            }
            if (count > maxcount) { maxcount = count; }
         }
         Console.WriteLine($"Максимальное количество повторяющихся элементов {maxcount} \n");

         //решето эратосфена
         List<int> nums = new List<int>();
         int count_simple = 0;
         for (int i = 2; i < k; i++) { nums.Add(i); }
         for (int i = 0; i < nums.Count; i++)
         {
            for (int j = 2; j < k; j++)
            {
               nums.Remove(nums[i] * j);
            }
         }
         for (int i = 0; i < n; i++)
         {
            if (nums.Contains(a[i])) { count_simple++; }
         }
         Console.WriteLine($"Количество простых чисел {count_simple}");
         Console.ReadLine();



      }
   }
}


