using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensurationByParts
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong numOfParts = 10000000;
            double squareArea = 0.0;

            for (ulong seg = 0; seg < numOfParts; seg++)
            {
                squareArea += ((double)1 / numOfParts)
                    * Math.Sqrt(1.0 - Math.Pow((double)seg / numOfParts, 2.0));
            }

            double area = squareArea * 4; // 반지름이 1 ==> Pi = area
            Console.WriteLine($"Pi = {area}");

            Console.ReadKey();
        }
    }
}
