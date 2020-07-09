using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GetNetworkIPs
{
    /// <summary>
    /// 네트워크 내부/외부 IP 주소를 얻는 클래스입니다
    /// </summary>
    public class H_NetworkIPInfo
    {
        /// <summary>
        /// 네트워크의 내부 IP(v4) 주소를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public IPAddress GetInternalIP()
        {
            IPHostEntry host;
            try
            {
                host = Dns.GetHostEntry(Dns.GetHostName());
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("로컬 호스트 명/IP 주소를 확인하는 중 오류가 발생했습니다.");
                Debug.WriteLine(ex.Message);
                throw;
            }

            IPAddress ipAddressV4 = default;
            foreach (var ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddressV4 = ipAddress;
                }
            }

            return ipAddressV4;
        }

        /// <summary>
        /// 네트워크의 외부 IP 주소를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public IPAddress GetExternalIP()
        {
            string checkUrl = "http://ipinfo.io/ip";
            string parsedIPString = string.Empty;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    parsedIPString = wc.DownloadString(checkUrl).Trim();
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine($"{checkUrl}에서 정보를 읽어오는데 실패했습니다.");
                Debug.WriteLine(ex.Message);
                throw;
            }

            IPAddress iPAddress;
            try
            {
                iPAddress = IPAddress.Parse(parsedIPString);
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is FormatException)
            {
                Debug.WriteLine($"얻어진 IP 주소 문자열이 null이거나 유효하지 않습니다.");
                Debug.WriteLine(ex.Message);
                throw;
            }

            return iPAddress;
        }
    }
}
