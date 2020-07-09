using System;
using System.IO;

namespace TempPathGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            // 시스템이 제공하는 임시 폴더
            var tempPath = Path.GetTempPath();
            Console.WriteLine("Temporary path: {0}", tempPath);
            // 시스템이 제공하는 임시 파일명 (중복없음)
            var tempFileName = Path.GetTempFileName();
            Console.WriteLine("Temporary filename: {0}", tempFileName);
        }
    }
}
