# -*- coding: utf-8 -*-
import ctypes
import sys


def main():
    if not is_admin():
        # 관리자 권한으로 본인 프로세스 다시 실행
        ctypes.windll.shell32.ShellExecuteW(
            None, "runas", sys.executable, __file__, None, 1)
        # 원래 프로세스는 종료되지 않고 남음 (창 2개): 핸들링 필요
    else:
        input("Press enter to exit.")


def is_admin():
    """실행된 프로세스의 권한이 관리자 권한인지 확인합니다."""
    if ctypes.windll.shell32.IsUserAnAdmin():
        print("관리자 권한으로 실행되었습니다.")
        return True  # 관리자 권한으로 실행된 프로세스
    else:
        print("일반 권한으로 실행되었습니다.")
        return False  # 일반 권한으로 실행된 프로세스


if __name__ == "__main__":
    main()
