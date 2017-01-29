using System;

namespace ParallelProgramingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //przygotowanie
            var size = 10000;
            var r = new Random();
            double[] tab = new double[size];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = r.Next();
            }

            //obliczenie sekwencyjne
            int repeatNumber = 100;
            double[] result = new double[tab.Length];
            int start = System.Environment.TickCount;

            for (int repeat = 0; repeat < repeatNumber; repeat++)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    result[i] = Count(tab[i]);
                }
            }
            int stop = System.Environment.TickCount;
            Console.WriteLine("Obliczenia sekwenkcyjne trwały {0} ms.", stop - start);

            /*          
            //prezentacja wyników
            Console.WriteLine("Wynik: ");
            for (var i = 0L; i < tab.Length; i++)
            {
                Console.WriteLine("{0}. {1} ?= {2}", i, tab[i], result[i]);
            }
            */
            Console.ReadKey();
        }

        private static double Count(double argument)
        {
            for (int i = 0; i < 10; i++)
            {
                argument = Math.Asin(Math.Sin(argument));
            }
            return argument;
        }
    }
}
