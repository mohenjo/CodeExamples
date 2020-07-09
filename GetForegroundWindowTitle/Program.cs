using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices; // Windows API function 호출

namespace ActiveWindowMonitor
{
    class Program
    {
        // 전면 윈도우 타이틀이 저장될 변수
        private static string CurrentActiveTitle = default; 

        static void Main(string[] args)
        {
            while (true)
            {
                GetActiveWindow();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Forground 윈도우의 핸들을 얻음
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow(); // Foreground 윈도우의 핸들 반환
        
        /// <summary>
        /// 윈도우 타이틀의 문자열 길이를 얻음. 
        /// 윈도우 타이틀이 비어 있거나, 윈도우 핸들이 무효할 경우 0을 반환
        /// </summary>
        /// <param name="hWnd">윈도우 핸들</param>
        /// <param name="text">윈도우 타이틀 텍스트가 저장될 버퍼(LPTSTR 타입)</param>
        /// <param name="count">버퍼에 저장될 char의 최대 길이</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private static void GetActiveWindow()
        {
            const int nChars = 256;
            IntPtr handle; // 윈도우 핸들
            StringBuilder buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();
            // 윈도우 타이틀 텍스트의 길이가 0 이상인 경우
            if (GetWindowText(handle, buff, nChars) > 0)
            {
                string currentTitle = buff.ToString();
                // 현재 전면 윈도우 타이틀과 저장된 전면 윈도우 타이틀이 다른 경우 (= 전면 윈도우가 바뀔 경우)
                if (CurrentActiveTitle != currentTitle)
                {
                    Console.WriteLine(handle);
                    Console.WriteLine(currentTitle);
                    CurrentActiveTitle = currentTitle;

                }
            }
        }
    }
}
