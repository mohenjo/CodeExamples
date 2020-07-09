# -*- coding: utf-8 -*-
import tkinter as tk
import tkinter.filedialog as tkfd
import os


class Application:
    def __init__(self, master):
        self.master = master
        self.initUI()

    def initUI(self):
        # ------ 사용 변수
        # 라벨에 사용할 변수 지정 - 다음 방식으로 미리 선언
        self.filename = tk.StringVar()
        self.filesize = tk.StringVar()

        # ------ 윈도우 설정
        self.master.geometry("300x150")
        self.master.title("윈도우 타이틀")
        self.master.resizable(False, False)
        # ------ 위젯 설정
        # --- 버튼
        self.btn_load = tk.Button(self.master,
                                  text="Open File", width=20,
                                  command=self.load_file)
        self.btn_load.place(x=20, y=20)
        # --- 라벨: 파일명
        self.lbl_1 = tk.Label(self.master, text="파일명: ")
        self.lbl_1.place(x=20, y=70)
        self.lbl_filename = tk.Label(
            self.master, anchor=tk.W, textvariable=self.filename)
        # --- 라벨: 파일 크기
        self.lbl_2 = tk.Label(self.master, text="파일크기(bytes): ")
        self.lbl_2.place(x=20, y=100)
        self.lbl_filesize = tk.Label(
            self.master, anchor=tk.W, textvariable=self.filesize)

    # ------ 사용자 함수
    # --- Open File 버튼
    def load_file(self):
        self.open_filename = tkfd.askopenfilename(
            initialdir="C:/", title="텍스트 파일을 선택하세요",
            filetypes=(("텍스트 파일", "*.txt"), ("모든 파일", "*.*")))
        # 파일명 변수값 설정
        self.filename.set(os.path.basename(self.open_filename))
        # 파일 크기 변수값 설정
        self.filesize.set(os.path.getsize(self.open_filename))
        # 라벨 업데이트
        self.lbl_filename.place(x=65, y=70)
        self.lbl_filesize.place(x=110, y=100)
        # 새 창 열기 호출
        self.open_new_window()

    # --- 새 창 열기
    def open_new_window(self):
        self.newwin = tk.Toplevel(self.master)
        self.newwin.geometry("500x500")
        self.newwin.title("새로운 윈도우 타이틀")
        # --- 메뉴 바 설정

        def close():
            self.newwin.destroy()

        menubar = tk.Menu(self.newwin)
        menu_1 = tk.Menu(menubar, tearoff=0)
        menu_1.add_command(label="하위메뉴 1_1")
        menu_1.add_command(label="하위메뉴 1_2")
        menu_1.add_separator()
        menu_1.add_command(label="닫기", command=close)
        menubar.add_cascade(label="메뉴_1", menu=menu_1)
        self.newwin.config(menu=menubar)


def main():
    mainwindow = tk.Tk()
    app = Application(mainwindow)
    mainwindow.mainloop()


if __name__ == "__main__":
    main()
