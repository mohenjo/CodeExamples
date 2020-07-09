"""Module docstring header

개인 사용을 위한 Google - Python 스타일 docstring 필수 사항 정리

주석 본문 내 reStructuredText의 포맷도 사용 가능.

빈 줄이 삽입되면 다음 줄로 넘어감. (주석 내 개행이 빈 줄을 만들지 않음)

- 주석문은 가능하면 80 컬럼 안의 영역에서 작성.

섹션은 섹션헤더 및 콜론(:)으로 구성됨:
    섹션 내용은 콜론 다음 줄부터 들여쓰기 하여 작성.

    이 안에서도 빈 줄을 삽입하면 다음 줄로 넘어감.

들어쓰기를 해제하여 섹션 종료.

소스코드의 삽입:
    ('::')를 문장 끝에 삽입. 다음 들여쓰기 블록(전후 공백 라인)::

        import modulename

        def display(string):
            print(string)

        rst = modulename.get_result()
        display(rst)


'\*' 또는 '\-' 를 이용하여 일반 목록 구성:
    * 목록 항목
    - 목록 항목

'\#' 를 이용하여 순서 목록 구성:
    #. 목록 항목 1
    #. 목록 항목 2

목록 항목 내 다른 목록(일반, 순서)를 포함할 수 있으나, 이 때 네스팅 되는 목록의
전후에 공백 라인이 필요함.

글자 포맷:
    * 앞 뒤에 '\*\*'를 붙이면 **굵게** 표시됨.
    * 앞 뒤에 '\*' 또는 '\`'를 붙이면 *기울여서* 표시됨.
    * 앞 뒤에 '``'를 붙이면 ``code`` 표시됨
    * 기타 이스케이프 문자 사용

TODO:
    * 할 일1
    * 할 일2

하이퍼 링크의 삽입:
    * `링크 텍스트 <http://target>`_ (under score 유의)
    * `레퍼런스 내용`_ (under score 유의)
    * 하이퍼 링크를 그냥 삽입해도 됨: https://www,python.org

.. _레퍼런스 내용:
    https://www.google.co.kr

    """

module_variable = 'modvar'
"""모듈 수준의 변수 주석화

모듈 변수 설명
"""


def function_ex1(arg1: int, arg2):
    """Function docstring header

    함수에 대한 자세한 설명.

    ``Args`` 부분에서 매개변수에 대한 설명.
    ``Returns`` 부분에서 반환값에 대한 설명.

    Args:
        arg1: 매개변수 1 - '매개변수 (타입): 내용'
        arg2 (int): 이 곳에서 매개변수 타입을 적어도 되나,
            선언부에서 타입 힌트를 적는 것이 관리에 좋음

    Returns:
        int: 반환이 없을 경우 Returns 섹션은 생략.
            타입을 생략(또는 선언부에 기입)하고 내용을 기입하는 것이 관리에 좋음

    """
    return arg1 + arg2


def function_ex2(arg1: int, arg2: str = None, *args, **kwargs):
    """Function docstring header

    함수에 대한 자세한 설명

    매개변수의 타입 힌트는 주석 내보다는 선언부에 적는 것이 관리하기 좋음

    Args:
        arg1:
        arg2: 기본값은 None
        *args:
        **kwargs:

    Returns:
        리턴 값에 대한 설명

    Raises:
        ValueError: 예외 발생 가능한 경우 반드시 명시함.
    """
    if arg1 == arg2:
        raise ValueError("arg1과 arg2는 다른 타입이어야 합니다.")
    return True


def function_ex3(n: int) -> int:
    """Function docstring header

    Args:
        n: 매개변수 설명

    Returns:
        == Yields로 사용할 수도 있으나, 후자의 경우 docstring에 표시X (PyCharm)

    Examples:
        다음과 같이 사용함::

            rst = sum(i for i in function_ex3(10))
            print(rst)  # 45

    """
    for i in range(n):
        yield i


class ClassEx:
    """Class docstring header

    클래스 설명
    """

    class_var: int = 99
    """클래스 변수"""

    def __init__(self, n):
        """생성자

        Args:
            n: 인스턴수 변수 초기값
        """
        self.inst_var = n
