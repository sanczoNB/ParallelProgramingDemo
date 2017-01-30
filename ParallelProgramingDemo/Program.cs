using System;
using System.Threading.Tasks;

namespace ParallelProgramingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //czynność
            Func<object, long> action =
                (arg) =>
                {
                    Console.WriteLine("Początek działania akcji - " + arg);
                    System.Threading.Thread.Sleep(5000); // opóźnienie 0.5s
                    Console.WriteLine("Koniec działania akcji - " + arg.ToString());
                    return DateTime.Now.Ticks;
                };

            var result = action("synchronicznie");
            Console.WriteLine("Synchronicznie: " + result);
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
