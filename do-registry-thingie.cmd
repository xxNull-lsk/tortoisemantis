@ECHO OFF
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe bin\Release\TortoiseMantis.dll /codebase /regfile:TortoiseMantis.reg

echo. >> TortoiseMantis.reg
echo [HKEY_CLASSES_ROOT\CLSID\{F25B6B8F-1BA0-4BCA-A809-0C0B6F4A0CED}\Implemented Categories\{3494FA92-B139-4730-9591-01135D5E7831}] >> TortoiseMantis.reg
echo. >> TortoiseMantis.reg
