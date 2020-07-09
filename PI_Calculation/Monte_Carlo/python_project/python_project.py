import random as rnd
from matplotlib import pyplot as plt


def display_pi_calc(n_tries: int):
    """지정된 횟수만큼의 몬테 카를로 시뮬레이션에 의해 계산된 원주율(Pi) 값 표시

    원의 반지름 r = 1, 이 원에 외접하는 사각형이 있고, 사각형 내에 무수히 많은 점을 찍었을 때,

    원 넓이 / 사각형 넓이 = Pi / 4
    = 원 안의 점의 개수 / 사각형 안의 점의 개수

    Args:
        n_tries (int): 몬테 카를로 시뮬레이션 시도 횟수

    Returns:
        None: see the plot window
    """
    # ----- initialize
    title = "Pi calculation by Monte Carlo Simulation"
    plt.rcParams['toolbar'] = 'None'  # 하단 툴바 감춤

    # 하나의 그래프라도 내부적으로 Figure -> Axes 가 생성되므로, 명시적으로 생성하는 것이 좋다.
    fig = plt.figure()
    fig.canvas.set_window_title(title)  # 윈도우 타이틀(tkInter canvas)
    axes = fig.add_subplot(1, 1,
                           1)  # Figure 내에 1 x 1 매트릭스 생성하여 1번째 서브플롯을 axes로 지정
    axes.set_aspect('equal')  # x-y 축 비율 동일
    axes.set_title(title)
    axes.set_xlim([-1.0, 1.0])
    axes.set_ylim([-1.0, 1.0])
    # -----

    # 원 추가
    circle = plt.Circle(xy=(0, 0), radius=1.0, fill=False, color='y')
    axes.add_patch(circle)  # drawing 개체의 추가는 add_patch

    # ----- Monte Carlo Simulation
    cnt_in_circle = 0
    for nth_pos in range(1, n_tries + 1):
        x = rnd.uniform(-1.0, 1.0)
        y = rnd.uniform(-1.0, 1.0)
        if (x * x + y * y) <= 1:
            dot_color = "b"
            cnt_in_circle += 1
        else:
            dot_color = "r"
        axes.scatter(x, y, marker=".", color=dot_color)
        pi = 4 * float(cnt_in_circle) / nth_pos
        axes.set_xlabel(f"Pi = {pi:0.7f} when the number of points = {nth_pos}")
        # plt.pause(1e-17)  # 중간 과정 그래프 갱신 표시
        print(f"Pi = {pi:0.5f} when the number of points = {nth_pos}", end="\r")

    axes.set_xlabel(f"Pi = {pi:0.5f} when the number of points = {n_tries}")
    print()
    print("Drawing plot, wait...")
    plt.show()
    print("Done.")
    # -----


def main():
    n_tries = int(input("Input the number of simulation: "))
    if n_tries < 1:
        n_tries = 1
    display_pi_calc(n_tries)


if __name__ == "__main__":
    main()
