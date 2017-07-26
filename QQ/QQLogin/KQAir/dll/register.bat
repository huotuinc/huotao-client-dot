@echo 开始注册
copy KQAir\dll\msvcp140d.dll %windir%\system32\
copy KQAir\dll\ucrtbased.dll %windir%\system32\
copy KQAir\dll\vcruntime140d.dll %windir%\system32\
copy KQAir\dll\msvcp140d.dll %windir%\SysWOW64\
copy KQAir\dll\ucrtbased.dll %windir%\SysWOW64\
copy KQAir\dll\vcruntime140d.dll %windir%\SysWOW64\

regsvr32 /s %windir%\system32\msvcp140d.dll
regsvr32 /s %windir%\system32\ucrtbased.dll
regsvr32 /s %windir%\system32\vcruntime140d.dll
@echo dll注册成功
