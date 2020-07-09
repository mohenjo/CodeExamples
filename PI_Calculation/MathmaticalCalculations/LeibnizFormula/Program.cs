using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibnizFormula
{
    class Program
    {
        static void Main(string[] args)
        {
            long numLengthOfSeries = 100000000;

            double sum = 0.0;

            for (long rpt = 1; rpt <= numLengthOfSeries; rpt++)
            {
                int sign = rpt % 2 == 0 ? -1 : 1;
                sum += sign * 1.0 / (rpt * 2 - 1);
            }
            double Pi = 4 * sum;

            Console.WriteLine($"Pi value by Leibniz formula is {Pi}");

            Console.ReadKey();
        }
    }
}
