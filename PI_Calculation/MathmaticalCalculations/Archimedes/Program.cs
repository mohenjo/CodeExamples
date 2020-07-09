using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archimedes
{
    class Program
    {
        static void Main(string[] args)
        {
            int diameter = 2; // 원의 지름
            int polygon = 6; // 원에 내접하는 6각형 (내접 6각형의 각 변의 길이 = 반지름)
            double side = (double)diameter / 2; // 6각형 한 변의 길이

            int numToDividePolygon = 13;
            double Pi = 0.0;
            Console.WriteLine($"반지름이 {diameter}인 원이 주어졌을 때,");
            Console.WriteLine("내접 정 N 각형의 둘레로부터 계산한 원주율의 값은 다음과 같다:");
            for (int rpt = 0; rpt < numToDividePolygon; rpt++)
            {
                // 내접 n각형을 2n각형으로 바꿀 때, 변의 길이 및 PI 값 계산
                Pi = (side * polygon) / diameter;
                Console.WriteLine($"{polygon, 6}-polygon: PI = {Pi}");
                polygon *= 2;
                side = Math.Sqrt(2 - Math.Sqrt(4 - side * side));
            }
            Console.ReadKey();
        }
    }
}
