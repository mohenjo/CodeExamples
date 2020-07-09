using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckNetworkAvailability
{
    internal class H_GetBestNic
    {
        /// <summary>
        /// 특정 IPv4 주소에 대해 최적의 라우트를 가진 NIC의 인덱스를 반환합니다.
        /// </summary>
        /// <param name="destAddr">32비트의 길이로 표시된 IPv4(4바이트) 주소입니다.</param>
        /// <param name="bestIfIndex">최적 NIC의 인덱스입니다.</param>
        /// <returns></returns>
        [DllImport("iphlpapi.dll", CharSet = CharSet.Auto)]
        private static extern int GetBestInterface(UInt32 destAddr, out UInt32 bestIfIndex);

        /// <summary>
        /// NIC 인덱스에 해당하는 NIC 개체 정보를 가져옵니다.
        /// </summary>
        /// <param name="index">NIC 인덱스</param>
        /// <returns></returns>
        public static NetworkInterface GetNetworkInterfaceByIndex(uint index)
        {
            // IPv4를 지원하는 모든 NIC 검색
            NetworkInterface ipv4interface =
                (from thisInterface in NetworkInterface.GetAllNetworkInterfaces()
                 where thisInterface.Supports(NetworkInterfaceComponent.IPv4)
                 let ipv4Properties = thisInterface.GetIPProperties().GetIPv4Properties()
                 where ipv4Properties != null && ipv4Properties.Index == index
                 select thisInterface).SingleOrDefault();
            if (ipv4interface != null)
            {
                return ipv4interface;
            }

            // IPv6를 지원하는 모든 NIC 검색
            NetworkInterface ipv6interface =
                (from thisInterface in NetworkInterface.GetAllNetworkInterfaces()
                 where thisInterface.Supports(NetworkInterfaceComponent.IPv6)
                 let ipv6Properties = thisInterface.GetIPProperties().GetIPv6Properties()
                 where ipv6Properties != null && ipv6Properties.Index == index
                 select thisInterface).SingleOrDefault();
            return ipv6interface;
        }

        /// <summary>
        /// 현재 인터넷 접속에 대한 최적의 NIC 오브젝트를 검색 결과와 해당 오브젝트를 반환합니다.
        /// </summary>
        /// <param name="bestNic">최적의 NIC 오브젝트</param>
        /// <returns></returns>
        public static bool GetBestNic(out NetworkInterface bestNic)
        {
            string targetUrl = "www.google.com"; // 호스트 URL
            bestNic = null;

            IPHostEntry hostInfo = null;
            try
            {
                hostInfo = Dns.GetHostEntry(targetUrl);
            }
            catch (SocketException ex)
            {
                Debug.WriteLine($"호스트 URL({targetUrl})을 확인할 때 오류가 발생했습니다.");
                Debug.WriteLine(ex.Message);
                return false;
            }

            // 호스트 URL에 대한 IPv4 주소 얻음
            IPAddress ipv4Adress =
                (from thisAddress in hostInfo.AddressList
                 where thisAddress.AddressFamily == AddressFamily.InterNetwork
                 select thisAddress).FirstOrDefault();

            // IPv4 주소 유효성 판단
            if (ipv4Adress == null)
            {
                Debug.WriteLine($"{targetUrl}에 연결된 IPv4 주소를 찾을 수 없습니다.");
                return false;
            }

            // 최적 NIC 검색
            UInt32 ipvAddressAsUInt32 = BitConverter.ToUInt32(ipv4Adress.GetAddressBytes(), 0);
            UInt32 interfaceIndex;
            int result = GetBestInterface(ipvAddressAsUInt32, out interfaceIndex);
            if (result != 0) // DWROD != NO_ERROR
            {
                Debug.WriteLine("GetBestInterface() 함수로부터 정상작으로 NIC 인덱스를 가져오지 못했습니다.");
                throw new Win32Exception(result);
            }
            bestNic = GetNetworkInterfaceByIndex(interfaceIndex);
            return true;
        }
    }
}