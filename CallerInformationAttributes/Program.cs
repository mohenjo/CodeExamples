using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CallerInformationAttributes
{
    class Program
    {
        static void Main()
        {
            DoHere();
        }

        static void DoHere()
        {
            // System.Diagnostics.StackTrace 사용
            GetCallerInformationLog1("호출자 정보 출력 방법1");
            Console.WriteLine();
            // Caller Information Attributes 사용
            GetCallerInformationLog2("호출자 정보 출력 방법2");
            Console.ReadKey();
        }

        // System.Diagnostics.StackTrace 사용
        // 느리고, 예외 발생시의 처리에 비효율적이라고 알려져 있음 
        static void GetCallerInformationLog1(string message)
        {
            Console.WriteLine($"메세지: {message}");
            StackTrace st = new StackTrace(); // 현재 스택 추적에 있는 모든 스택 프레임의 복사본
            var frame = st.GetFrame(1); // 0 - 자신, 1 - 호출자, 2 - 바로 상위 호출자, 3, 그 상위 ...
            // GetFrames() 메소드를 호출하면 상기 프레임의 목록을 얻을 수 있음
            Console.WriteLine($"호출자명: {frame.GetMethod().Name}");
        }

        // Caller Information Attributes (.NET framework 4.0 이상부터 제공)
        // using System.Runtime.CompilerServices 참조 필요
        // 인자로서 사용됨
        static void GetCallerInformationLog2(string message,
                                             [CallerMemberName] string memberName = "",
                                             [CallerFilePath] string sourceFilePath = "",
                                             [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine($"메세지: {message}");
            Console.WriteLine($"소스파일경로: {sourceFilePath}");
            Console.WriteLine($"호출자명: {memberName}");
            Console.WriteLine($"호출라인번호: {sourceLineNumber}");
        }
    }
}
