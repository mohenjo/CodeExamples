import re


def get_new_number(old_num_str: str) -> str:
    """구 01X 휴대폰 번호에 대응하는 010 번호를 반환합니다.

    Args:
        old_num_str (str): 011, 016, 017, 018, 019로 시작하는 번호입니다.
            입력 문자열은 '01X-OOOO-OOOO'의 형태로 주어지며, 하이픈(-)은
            생략이 가능합니다.

    Returns:
        대응하는 변경 후 번호의 문자열(010-OOOO-OOOO)을 반환합니다.
        입력 인수가 유효한 번호의 형태가 아닐 경우 None을 반환합니다.

    Raises:
        ValueError: 입력 인수가 유효한 또는 변경 가능한 번호가 아닐 경우 
    """

    # 번호 유효성 검사 1
    old_num_str = old_num_str.strip()
    regex = re.compile(r"^01[16789]-?\d{3,4}-?\d{4}$")
    match_result = regex.match(old_num_str)
    if match_result is None:
        raise ValueError

    # 전화 번호 요소 분리
    old_num_str = old_num_str.replace("-", "")
    mno: str = old_num_str[:3]  # 통신사 번호 3자리
    dia: str = old_num_str[3:-4]  # 국번 3~4자리
    num: str = old_num_str[-4:]  # 전화번호 4자리

    # 번호 유효성 검사 2
    dianum = int(dia)
    check = 200 <= dianum < 900
    if mno in ["011", "016", "019"]:
        check = check or 9000 <= dianum < 10000
    if mno == "011":
        check = check or 1700 <= dianum < 1800
    if not check:
        raise ValueError

    # 변경 후 번호 계산
    if mno == "011":
        if 200 <= dianum < 500:
            dia = "5" + dia
        elif 500 <= dianum < 900:
            dia = "3" + dia
        elif 1700 <= dianum < 1800:
            dia = "71" + dia[2:]
        elif 9500 <= dianum < 10000:
            dia = "8" + dia[1:]
    elif mno == "016":
        if 200 <= dianum < 500:
            dia = "3" + dia
        elif 500 <= dianum < 900:
            dia = "2" + dia
        elif 9000 <= dianum < 9500:
            dia = "7" + dia[1:]
    elif mno == "017":
        if 200 <= dianum < 500:
            dia = "6" + dia
        elif 500 <= dianum < 900:
            dia = "4" + dia
    elif mno == "018":
        if 200 <= dianum < 500:
            dia = "4" + dia
        elif 500 <= dianum < 900:
            dia = "6" + dia
    elif mno == "019":
        if 200 <= dianum < 500:
            dia = "2" + dia
        elif 500 <= dianum < 900:
            dia = "5" + dia
        elif 9000 <= dianum < 9500:
            dia = "8" + dia[1:]
        elif 9500 <= dianum < 10000:
            dia = "7" + dia[1:]

    return f"010-{dia}-{num}"


if __name__ == "__main__":
    # rst = get_new_number("011-55-6666")  # ValueError
    # rst = get_new_number("011-1555-6666")  # ValueError
    rst = get_new_number("011-555-6666")
    print(rst)
