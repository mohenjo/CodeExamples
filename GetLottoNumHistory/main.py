# 로또 번호 크롤링
# 동행복권: https://dhlottery.co.kr/
import datetime
import urllib.request
from typing import List

import bs4


def get_lucky_numbers_of_session(session_no_text: int):
    search_url = f"https://dhlottery.co.kr/gameResult.do?method=byWin&drwNo={session_no_text}"
    response = urllib.request.urlopen(search_url)
    rawdata = response.read()

    soup = bs4.BeautifulSoup(rawdata, features="html.parser")
    base_block = soup.findAll("div", attrs={"class": "win_result"})

    # 회차 번호 확인 및 유효성 검증
    session_no = None
    for sub_tags in base_block:
        session_no_text = sub_tags.find("h4").find("strong").get_text().strip()
        # 존재하지 않는 회차인 경우
        if session_no_text == "회":
            raise ValueError("존재하지 않는 회차입니다.")
        session_no = int(session_no_text[:-1])  # 회차번호

    # 회차 실시 날짜
    session_date = None
    for sub_tags in base_block:
        session_date_text = sub_tags.find("p", attrs={"class": "desc"}).get_text().strip()
        dt_obj = datetime.datetime.strptime(session_date_text, "(%Y년 %m월 %d일 추첨)")
        session_date = (dt_obj.year, dt_obj.month, dt_obj.day)

    # 당첨 번호 및 보너스 번호
    # 모두 'span' 태그 내에 위치
    luck_numbers: List[int] = []
    for sub_tags in base_block:
        winnum_tags = sub_tags.findAll("span")
        for item in winnum_tags:
            luck_numbers.append(int(item.get_text()))

    return session_no, session_date, luck_numbers


if __name__ == '__main__':
    sesson_no = 925
    ret = get_lucky_numbers_of_session(sesson_no)
    print(ret)

    for i in range(900, 911):
        ret = get_lucky_numbers_of_session(i)
        print(f"{ret[0]}회 ({ret[1][0]}년 {ret[1][1]}월 {ret[1][2]}일 추첨) - ", end='')
        print(f"당첨번호: {ret[2][:-1]}, 보너스 번호: {ret[2][-1]}")
