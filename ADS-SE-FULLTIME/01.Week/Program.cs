using System;

namespace Week_1
{
    class Program
    {
        static Random rand = new Random();

        static void GenerateRandom(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-100, 100);
            }
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static double Average(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum / arr.Length;
        }

        static int Max(int[] arr)
        {
            int max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        static int NearestAverage(double average, int[] arr)
        {
            int nearest = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i] - average) < Math.Abs(nearest - average))
                {
                    nearest = arr[i];
                }
            }

            return nearest;
        }

        static void EratostenPrimes(int n)
        {
            bool[] primes = new bool[n + 1];

            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }


            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == true)
                {
                    for (int j = i + i; j < primes.Length; j += i)
                    {
                        primes[j] = false;
                    }
                }

            }

            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    Console.WriteLine(i);
                }
            }

        }

        static void RandomMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }

        }


        static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            /*
            int[] arr = new int[10];
            GenerateRandom(arr);
            PrintArray(arr);
            Console.WriteLine("Max element is: " + Max(arr));
            double average = Average(arr);
            Console.WriteLine("Average is: " + average);
            Console.WriteLine("Nearest to average is: " + NearestAverage(average, arr));
            */

            //EratostenPrimes(100);




            int[,] arr = new int[5, 5];

            RandomMatrix(arr);

            PrintMatrix(arr);

        }
    }
}
