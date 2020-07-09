using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckNetworkAvailability
{
    /// <summary>
    /// 인터넷 접속 여부 및 최적의 NIC을 검색하는 클래스입니다.
    /// </summary>
    public static class H_NetAvailability
    {
        /// <summary>
        /// 인터넷 접속 가능 여부를 확인합니다.
        /// </summary>
        /// <returns></returns>
        public static bool IsInternetConnected()
        {
            /*
             * Microsoft는 인터넷 정상 접속 여부를 체크를 위해 특별한 웹 페이지를 제공합니다.
             * Vista 이상의 Windows OS에서는 NCSI(Network Connectivity Status Indicator)라는 기능을 통해
             * 인터넷 사용 가능 여부를 체크합니다:
             * 1. HTTP GET 을 사용하여 www.msftncsi.com/ncsi.txt를 가져올 수 있는지 체크
             * 2. dns.msftncsi.com 이라는 DNS 호스트의 IP가 131.107.255.255 이 되는지 체크
             * 출처: http://www.csharpstudy.com/Tip/Tip-network-connectivity.aspx
             */

            const string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
            const string NCSI_TEST_RESULT = "Microsoft NCSI";
            const string NCSI_DNS = "dns.msftncsi.com";
            const string NCSI_DNS_IP_ADDRESS = "131.107.255.255";

            try
            {
                // 1. NCSI 링크에서 텍스트를 제대로 가져올 수 있는지 체크
                var webClient = new WebClient();
                string result = webClient.DownloadString(NCSI_TEST_URL);
                if (result != NCSI_TEST_RESULT)
                {
                    return false;
                }

                // 2. NCSI DNS 호스트 IP 체크
                var dnsHost = Dns.GetHostEntry(NCSI_DNS);
                if (dnsHost.AddressList.Count() <= 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}