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
                    System.Threading.Thread.Sleep(2000); // opóźnienie 2s
                    Console.WriteLine("Koniec działania akcji - " + arg.ToString());
                    return DateTime.Now.Ticks;
                };

            //w osobnym zadaniu
            Task<long> task = new Task<long>(action, "żądanie");
            task.Start();
            Console.WriteLine("Akcja została uruchomiona");
            //właściwość Result czeka ze zwróceniem wartości, aż zadanie zostanie zakończone
            //(synchronizacja)
            long result = task.Result;
            Console.WriteLine("Zadanie: " + result);

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
