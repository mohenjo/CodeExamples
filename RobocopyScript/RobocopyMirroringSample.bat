@echo off
set source=D:\Storage
set target=D:\Storage.Backup
echo.
echo [ROBOCOPY Backup/Mirroring]
echo.
echo Source directory: %source%
echo Target directory: %target%
echo.
echo Press any key when ready.
pause > nul
echo.
robocopy %source% %target% /MIR /R:5 /W:1 /TEE /NDL /NP /LOG:Mirroring_log.txt
echo.
echo Mirroring backup completed.
echo.
pause