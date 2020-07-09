import urllib.request
import urllib.error
import socket
import logging


def is_inetavail():
    """인터넷 연결 여부를 확인합니다.

    Vista 이상의 Microsoft 윈도우에서는 인터넷 정상 접속 여부를 체크를 위해
    NCSI(Network Connectivity Status Indicator)라는 기능을 사용합니다.

    이 함수는 NCSI 체크 방식을 통해 인터넷 정상 접속 여부를 판단합니다:
        #. www.msftncsi.com/ncsi.txt에서 가져온 텍스트 일치 여부 체크
        #. dns.msftncsi.com의 IP 주소 일치 여부 체크

    Returns:
        연결 가능(True) or 연결 불가(False)
    """
    ncsi_test_url = "http://www.msftncsi.com/ncsi.txt"
    ncsi_test_result = "Microsoft NCSI"
    ncsi_dns = "dns.msftncsi.com"
    ncsi_dns_ip_address = "131.107.255.255"

    try:
        obj = urllib.request.urlopen(ncsi_test_url)
        contents: str = obj.read().decode("utf-8").strip()
        if contents != ncsi_test_result:
            msg = f"{ncsi_test_url}의 문자열 '{contents}'이 '{ncsi_test_result}'와 일치하지 않습니다."
            logging.warning(msg)
            return False
        _, _, host_ips = socket.gethostbyname_ex(ncsi_dns)
        if len(host_ips) <= 0 or host_ips[0] != ncsi_dns_ip_address:
            msg = f"{ncsi_dns}의 IP 주소가 확인되지 않거나 기준 IP가 {ncsi_dns_ip_address}가 아닙니다."
            logging.warning(msg)
            return False
    except Exception as ex:
        msg = f"인터넷 연결 확인 중 예외가 발생하였습니다: {ex}"
        logging.warning(msg)
        return False

    return True


def get_local_ip():
    """로컬 IP 주소의 리스트를 얻습니다."""
    host = socket.gethostname()
    _, _, ips = socket.gethostbyname_ex(host)
    return ips


def get_global_ip():
    """글로벌 IP 주소를 얻습니다."""
    chkurl = "http://ipinfo.io/ip"
    try:
        obj = urllib.request.urlopen(chkurl)
        ip: str = obj.read().decode("utf-8").strip()
    except Exception as ex:
        msg = f"{chkurl}로부터 글로벌 IP 주소를 파싱하는데 실패했습니다."
        logging.error(msg)
        raise
    return ip


if __name__ == "__main__":
    conchk = is_inetavail()
    print(f"인터넷 연결 여부: {conchk}")
    localip = get_local_ip()
    print(f"로컬 IPv4s: {localip}")
    globalip = get_global_ip()
    print(f"글로벌 IPv4: {globalip}")
