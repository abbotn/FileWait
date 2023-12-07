@Echo off
REM Save_obsReplay.bat
REM Usage: Save_obsReplay.bat "Replay obsReplay.mp4"

:Top

Filewait %1

If %ERRORLEVEL% NEQ 0 Goto Fini

Set year=%date:~10,4%
Set month=%date:~4,2%
Set day=%date:~7,2%
Set hour=%time:~0,2%
REM For hour < 10
If "%hour:~0,1%" == " "  set hour=0%hour:~1,1%
Set minute=%time:~3,2%
Set timeStamp=%year%%month%%day%%hour%%minute%

REM Copy file with added datetime suffix

Echo Copying %~n1_%timeStamp%%~x1
Copy /V /Y %1 "C:\Temp\%~n1_%timeStamp%%~x1"

Goto Top

:Fini