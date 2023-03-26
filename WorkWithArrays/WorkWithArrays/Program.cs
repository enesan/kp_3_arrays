using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace WorkWithArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ArrayASize, StartOfRange, EndOfRange;
            int[] ArrayA;
            bool flag = true;
            Random rnd = new Random();

            Console.WriteLine("Введите размер массив, начало диапазона чисел, конец диапазона чисел.");
            int[] n = Console.ReadLine().Split(' ').Select(e => Convert.ToInt32(e)).ToArray();
            ArrayASize = n[0];
            StartOfRange = n[1];
            EndOfRange = n[2];
            ArrayA = new int[ArrayASize];

            for (int i = 0; i < ArrayASize; i++)
            {
                ArrayA[i] = rnd.Next(StartOfRange, EndOfRange);
            }
            PrintArray(ArrayA);

            //1
            Console.WriteLine("Выберите какую часть массива перемешать:\n0 - перемешать весь массив\n1 - перемешать первую половину массива\n2 - перемешать вторую половину массива");
            while (flag)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        flag = false;
                        ShuffleTheArray(ArrayA, 0, ArrayASize);
                        break;
                    case "1":
                        flag = false;
                        ShuffleTheArray(ArrayA, 0, Convert.ToInt32(Math.Ceiling((double)ArrayASize / 2)));
                        break;
                    case "2":
                        flag = false;
                        ShuffleTheArray(ArrayA, Convert.ToInt32(Math.Ceiling((double)ArrayASize / 2)), ArrayASize);
                        break;
                    default:
                        Console.WriteLine("Введите корректное число.");
                        break;
                }
            }
            Console.WriteLine("Перемешанный массив");
            PrintArray(ArrayA);

            //2
            MonotoneIntervals(ArrayA);

            //3
            CheckingAPattern(ArrayA);

            //4
            MaximumNumberOfIdenticalElements(ArrayA);

            //5
            NumberOfPrimeNumbers(ArrayA, StartOfRange, EndOfRange);
        }

        private static void PrintArray(int[] Arr)
        {
            string ElementNumbers = "", Elements = "";
            for (int i = 0; i < Arr.Length; i++)
            {
                ElementNumbers += Convert.ToString(i + 1) + "\t";
                Elements += Convert.ToString(Arr[i]) + "\t";
            }
            Console.WriteLine(ElementNumbers + "\n" + Elements);
        }

        private static void ShuffleTheArray(int[] Arr, int StartIndex, int EndIndex)
        {
            Random rnd = new Random();
            int temp;
            for (int i = StartIndex; i < EndIndex; i++)
            {
                temp = rnd.Next(StartIndex, EndIndex);
                (Arr[i], Arr[temp]) = (Arr[temp], Arr[i]);
            }
        }

        private static void MonotoneIntervals(int[] Arr)
        {
            string IntervalsOfIncrease = "";
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                if (Arr[i] < Arr[i + 1])
                    IntervalsOfIncrease += Arr[i] + " ";
                if (Arr[i] < Arr[i + 1] && i == Arr.Length - 2)
                    IntervalsOfIncrease += Arr[i + 1] + " ";
                if (Arr[i] > Arr[i + 1] && !IntervalsOfIncrease.EndsWith("; ") && !(IntervalsOfIncrease == ""))
                    IntervalsOfIncrease += Arr[i] + "; ";
            }
            IntervalsOfIncrease += " - промежутки позрастания.\n";

            string DecayIntervals = "";
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                if (Arr[i] > Arr[i + 1])
                    DecayIntervals += Arr[i] + " ";
                if (Arr[i] > Arr[i + 1] && i == Arr.Length - 2)
                    DecayIntervals += Arr[i + 1] + " ";
                if (Arr[i] < Arr[i + 1] && !DecayIntervals.EndsWith("; ") && !(DecayIntervals == ""))
                    DecayIntervals += Arr[i] + "; ";
            }
            DecayIntervals += " - промежутки убывания.";
            Console.WriteLine(IntervalsOfIncrease + DecayIntervals);
        }

        private static void CheckingAPattern(int[] Arr)
        {
            int AnElementThatBreaksThePattern = 0;
            bool PatternIsBroken = false;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[0] > 0 && ((i % 2 == 0 && !(Arr[i] > 0)) || (i % 2 == 1 && !(Arr[i] < 0))))
                {
                    AnElementThatBreaksThePattern = i;
                    PatternIsBroken = true;
                    break;
                }
                else if (Arr[0] < 0 && ((i % 2 == 0 && !(Arr[i] < 0)) || (i % 2 == 1 && !(Arr[i] > 0))))
                {
                    AnElementThatBreaksThePattern = i;
                    PatternIsBroken = true;
                    break;
                }
                else if (Arr[0] == 0) //"0 - является и не является одновременно и отрицательным и положительным "
                {
                    PatternIsBroken = true;
                    break;
                }
            }

            if (PatternIsBroken)
                Console.WriteLine((AnElementThatBreaksThePattern + 1) + " - элемент в массиве сломавший последовательность");
            else
                Console.WriteLine("Последовательность соблюдается");
        }

        private static void MaximumNumberOfIdenticalElements(int[] Arr)
        {
            Dictionary<int, int> UniqueIntegers = new Dictionary<int, int> { };
            for (int i = 0; i < Arr.Length; i++)
                UniqueIntegers[Arr[i]] = 0;

            for (int i = 0; i < Arr.Length; i++)
                UniqueIntegers[Arr[i]] += 1;

            int TheMaximumNumberOfIdenticalArrayElements = 0;
            for (int i = 0; i < Arr.Length; i++)
                if (UniqueIntegers[Arr[i]] > TheMaximumNumberOfIdenticalArrayElements)
                    TheMaximumNumberOfIdenticalArrayElements = UniqueIntegers[Arr[i]];

            Console.WriteLine(TheMaximumNumberOfIdenticalArrayElements + " - максимальное количество одинаковых элементов массива");
        }

        private static int[] SieveOfEratosthenes(int size)
        {
            size--;
            int[] Arr = new int[size];

            for (int a = 0, b = 2; a < size; a++, b++)
            {
                Arr[a] = b;
            }

            int LastPosition = 0;
            double SqrtSize = Math.Sqrt(size);
            for (int p = 0; p <= SqrtSize;)
            {

                for (int a = LastPosition; a < size; a++)
                {
                    if (Arr[a] != 0)
                    {
                        p = Arr[a];
                        LastPosition = a + 1;
                        break;
                    }
                }

                for (int b = 2 * p; b <= size + 1; b += p)
                {
                    Arr[b - 2] = 0;
                }
            }

            int CleanArrSize = 0;
            for (int a = 0; a < size; a++)
            {
                if (Arr[a] != 0)
                {
                    CleanArrSize++;
                }
            }

            int[] CleanArr = new int[CleanArrSize];
            int CleanArrPosition = 0;
            for (int a = 0; a < size; a++)
            {
                if (Arr[a] != 0)
                {
                    CleanArr[CleanArrPosition] = Arr[a];
                    CleanArrPosition++;
                }
            }
            return CleanArr;
        }

        private static void NumberOfPrimeNumbers(int[] Arr, int StartOfRange, int EndOfRange)
        {
            int[] ArrayWithPrimeNumbers;
            int PrimeNumbersCounter = 0;
            ArrayWithPrimeNumbers = SieveOfEratosthenes(EndOfRange);
            HashSet<int> AnArrayOfUniqueValues = new HashSet<int>(Arr);

            for (int j = 0; j < ArrayWithPrimeNumbers.Length; j++)
                if (AnArrayOfUniqueValues.Contains(ArrayWithPrimeNumbers[j]))
                    PrimeNumbersCounter++;
            Console.WriteLine(PrimeNumbersCounter + " - количество простых чисел");
        }
    }
}