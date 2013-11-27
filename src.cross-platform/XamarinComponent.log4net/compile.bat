@echo off
call "%PROGRAMFILES%\Microsoft Visual Studio 10.0\VC\vcvarsall.bat"


rmdir /q /s .\bin\
rmdir /q /s .\content\bin\
rmdir /q /s .\content\lib

msbuild ..\log4net.XamarinAndroid.vs2010\log4net.XamarinAndroid.vs2010.csproj ^
		/p:Configuration=Release ^
		/property:OutDir=..\XamarinComponent.log4net\content\bin\

msbuild ..\log4net.XamariniOS.vs2010\log4net.XamariniOS.vs2010.csproj ^
		/p:Configuration=Release ^
		/property:OutDir=..\XamarinComponent.log4net\content\bin\

echo ======================================================================================
echo creating references for component samples in content\lib
echo folders 
echo		lib\android 
echo and
echo 		lib\ios
echo are generated during xam packaging
echo only Release build is for component
echo ======================================================================================

msbuild ..\log4net.XamarinAndroid.vs2010\log4net.XamarinAndroid.vs2010.csproj ^
		/p:Configuration=Release ^
		/property:OutDir=..\XamarinComponent.log4net\content\lib\android

msbuild ..\log4net.XamariniOS.vs2010\log4net.XamariniOS.vs2010.csproj ^
		/p:Configuration=Release ^
		/property:OutDir=..\XamarinComponent.log4net\content\lib\ios


@IF %ERRORLEVEL% NEQ 0 PAUSE	
