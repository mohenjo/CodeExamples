using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CheckNetworkAvailability
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 로컬 or 인터넷 연결 여부 확인
            bool isConnected2Net = NetworkInterface.GetIsNetworkAvailable();
            Console.WriteLine("로컬/인터넷 연결 여부: " + isConnected2Net.ToString());
            if (!isConnected2Net) { return; }
            Console.WriteLine();

            // 인터넷 연결 여부 확인
            bool isConnected2Internet = H_NetAvailability.IsInternetConnected();
            Console.WriteLine("인터넷 연결 여부: " + isConnected2Internet.ToString());
            if (!isConnected2Internet) { return; }
            Console.WriteLine();

            // 최적의 NIC 얻기
            Console.Write("최적 네트워크 인터페이스: ");
            bool foundBest = H_GetBestNic.GetBestNic(out NetworkInterface bestNic);
            if (!foundBest) { Console.WriteLine("찾을 수 없습니다."); }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"- Id: {bestNic.Id}");
                Console.WriteLine($"- Name: {bestNic.Name}");
                Console.WriteLine($"- Description: {bestNic.Description}");
                Console.WriteLine($"- Type: {bestNic.NetworkInterfaceType}");
                Console.WriteLine($"- Status: {bestNic.OperationalStatus}");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}