using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace BenchmarkingWithStopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            UseDateTimeNow();
            UseStopwatch();
            Console.ReadKey();
        }

        // DateTime.Now 프로퍼티를 사용한 실행시간 측정
        static void UseDateTimeNow()
        {
            int[] opDurations = Enumerable.Range(1, 100).ToArray();
            double difference =0;
            foreach (var opDuration in opDurations)
            {
                DateTime startTime = DateTime.Now;
                Thread.Sleep(opDuration); // test code to be here
                DateTime endTime = DateTime.Now;
                var calDuration = (endTime - startTime).TotalMilliseconds;
                difference += Math.Abs(calDuration - opDuration);
            }
            Console.WriteLine("DateTime class: 1ms - 100ms (100개)의 테스트 케이스에 대해");
            Console.WriteLine($"- 총 오차 {difference}ms, 평균 오차 {difference/opDurations.Length}ms.");
        }

        // Stopwatch 클래스를 이용한 실행시간 측정
        static void UseStopwatch()
        {
            int[] opDurations = Enumerable.Range(1, 100).ToArray();
            double difference = 0;
            foreach (var opDuration in opDurations)
            {
                Stopwatch sw = Stopwatch.StartNew();
                Thread.Sleep(opDuration);  // test code to be here
                var calDuration = sw.ElapsedMilliseconds;
                difference += Math.Abs(calDuration - opDuration);
            }
            Console.WriteLine("Stopwatch class: 1ms - 100ms (100개)의 테스트 케이스에 대해");
            Console.WriteLine($"- 총 오차 {difference}ms, 평균 오차 {difference / opDurations.Length}ms.");
        }
    }
}
