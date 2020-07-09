using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number of simulations: ");

            ulong numSimul = 0;
            try
            {
                numSimul = ulong.Parse(Console.ReadLine());
                // 0 ~ 18,446,744,073,709,551,615
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} 오류가 발생했습니다.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            ulong countInCircle = 0;
            double Pi = 0;
            for (ulong rpt = 1; rpt <= numSimul; rpt++)
            {
                double x = GenerateRandomDouble(-1.0, 1.0);
                double y = GenerateRandomDouble(-1.0, 1.0);

                if (x * x + y * y <= 1.0)
                {
                    countInCircle++;
                    Pi = 4.0 * (double)countInCircle / rpt;
                }
            }
            Console.Write($"{numSimul} simulation processed. Calculated Pi value is {Pi}\r");
            Console.WriteLine();
            Console.ReadKey();
        }

        private static Random rnd = new Random();

        private static double GenerateRandomDouble(double min, double max)
        {
            double returnVal = min + rnd.NextDouble() * (max - min);
            return returnVal;
        }
    }
}
