using System;
using System.Threading.Tasks;

namespace ParallelProgramingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var suma = 0L;
            var counter = 0L;
            var s = "";

            //iteracje zostaną wykonane tylko dla liczb parzystych
            //pętla zostanie rpzerwana wcześniej, jeżeli wylosowana liczba jest równa 0
            Parallel.For(0, 1000, (i, loopState) =>
            {
                var number = r.Next(7);
                if (number == 0)
                {
                    s += "Stop:";
                    loopState.Stop();
                }
                if (loopState.IsStopped)
                {
                    return;
                }
                if (number % 2 == 0)
                {
                    s += $"{number}; ";
                    Count(number);
                    suma += number;
                    counter++;
                }
                else
                {
                    s += $"[{number}]; ";
                }
            });

            Console.WriteLine("Wylosowane liczby: {0}" +
                              "\nLiczba pasujących liczb: {1}" +
                              "\nSuma: {2}" +
                              "\nŚrednia: {3}"
                              ,s, counter, suma, (suma / (double)counter));

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
