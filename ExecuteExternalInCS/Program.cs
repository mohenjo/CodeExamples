using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteExternalInCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = string.Empty;
            string arg = string.Empty;
            string[] inputCommands = new string[]{ };
            string result = string.Empty;
            
            
            // 사용 예
            fileName = "cmd.exe";
            arg = "/c ipconfig";
            inputCommands = new string[]{ };
            result = H_RunExternal.Exec(fileName, arg, inputCommands);
            Console.WriteLine(result);

            // 사용 예
            fileName = "netsh";
            arg = "interface ipv4 show global";
            inputCommands = new string[] { };
            result = H_RunExternal.Exec(fileName, arg, inputCommands);
            Console.WriteLine(result);

            // 사용 예 - 관리자 권한
            fileName = "regedit";
            arg = "";
            inputCommands = new string[] { };
            result = H_RunExternal.Exec(fileName, arg, inputCommands);
            Console.WriteLine(result);

            // 사용 예 - 관리자 권한 
            // MTU 값 변경 테스트이므로 함부로 실행시키지 마세요
            //fileName = "netsh";
            //arg = "interface ipv4 set subinterface \"4\" mtu=800 store=active";
            //inputCommands = new string[] { };

            //result = H_RunExternal.Exec(fileName, arg, inputCommands);
            //Console.WriteLine(result);

            Console.ReadKey();


        }
    }
}
