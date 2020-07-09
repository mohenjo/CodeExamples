# Change MTU Value [Batch Script]

MTU 값 변경을 위한 배치파일 샘플 (**IPv4**)

## 1. netsh 설정 확인
`> netsh interface ipv4 show global`  
`> netsh interface ipv4 show interfaces`

## 2. netsh 설정 변경 (관리자 권한 필요)
+ `MINMTU` - 최소 MTU 값 (352~576) (기본값 576) 
+ `TARGETINTERFACE` - 인터페이스 연결 목록 중 변경 대상 목록의 색인 또는 이름(문자열)
+ `MTU` - 새로운 MTU 값 (기본값 1500)

### 전역 설정 (MTU 최소값) 변경:

`> netsh interface ipv4 set global minmtu=%MINMTU%`  

+ `store=persistent`가 기본값이므로 변경된 값으로 설정할 때에는 `store=active` 사용 추천
+ `store=active` 설정된 경우, 시스템 재부팅 후 기본값으로 자동 복구됨

### 인터페이스 연결에 대한 MTU 설정 변경:

`> netsh interface ipv4 set subinterface %TARGETINTERFACE% mtu=%MTU% store=persistent`
+ 변경된 값으로 설정할 때에는 `store=active`, 기본값 설정 시 `store=persistent` 사용 추천
+ `store=active` 설정된 경우, 시스템 재부팅 후 기본값으로 자동 복구됨





