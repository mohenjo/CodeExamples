@echo off
@chcp 65001 > NUL
title MTU 설정 변경 및 복구
COLOR 1E
echo ********************************
echo  MTU 설정 변경 및 복구 스크립트
echo ********************************
echo Powered 2019 by 박햇님
echo.

bcdedit > nul || (echo 이 스크립트는 관리자 권한으로 실행되어야 합니다. & pause & exit)

setlocal

::::::::::::::::::::::::::::::::::::
:PARAMETERS
rem 매개변수 설정치는 아래를 수정하세요.

rem GLOBAL 설정확인: netsh interface ipv4 show global
rem 연결 목록 확인: netsh interface ipv4 show interfaces

rem 최소 MTU의 기본값
set DEFAULTMINMTU=576

rem MTU의 기본값
set DEFAULTMTU=1500

rem 최소 MTU의 변경값
set TARGETMINMTU=400

rem MTU의 변경값
set TARGETMTU=400

rem 인터넷 연결 목록의 색인 번호 
set TARGETINTERFACE="4"
::::::::::::::::::::::::::::::::::::


::::::::::::::::::::::::::::::::::::
:LOOP
set /p CHOICE=[0] MTU 설정 변수 보기, [1] MTU 기본 설정 복구, [2] MTU 설정 변경, [3] MTU 현재 설정 보기, [4] 종료 ?
if "%CHOICE%" == "0" goto PARAINFO
if "%CHOICE%" == "1" goto RECOVERDEFAULTS
if "%CHOICE%" == "2" goto CHANGESETTINGS
if "%CHOICE%" == "3" goto SHOWSETTINGS
if "%CHOICE%" == "4" goto QUIT
goto LOOP
::::::::::::::::::::::::::::::::::::


:PARAINFO
echo - 대상 인터페이스: %TARGETINTERFACE%
echo - 최소 MTU 값: %TARGETMINMTU% (기본값은 %DEFAULTMINMTU%)
echo - MTU 값: %TARGETMTU% (기본값은 %DEFAULTMTU%)
echo - 설정 값의 변경이 필요할 경우 본 파일의 PARAMETERS 레이블을 참조하시기 바랍니다.
echo.
goto LOOP


:RECOVERDEFAULTS
netsh interface ipv4 set global minmtu=%DEFAULTMINMTU% > nul
netsh interface ipv4 set subinterface %TARGETINTERFACE% mtu=%DEFAULTMTU% store=persistent > nul
echo - MTU 기본 설정이 복구되었습니다.
echo.
goto LOOP


:CHANGESETTINGS
netsh interface ipv4 set global minmtu=%TARGETMINMTU% store=active> nul
netsh interface ipv4 set subinterface %TARGETINTERFACE% mtu=%TARGETMTU% store=active > nul
echo - MTU 설정이 변경되었습니다. 시스템 재부팅시 기본값으로 자동 복구됩니다.
echo.
goto LOOP


:SHOWSETTINGS
echo.
echo [글로벌 구성 매개변수]
netsh interface ipv4 show global
echo.
echo [인터페이스 매개변수]
netsh interface ipv4 show interfaces
echo.
goto LOOP


:QUIT
endlocal
pause
exit
