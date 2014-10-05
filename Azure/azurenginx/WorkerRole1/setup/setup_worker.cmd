@echo off

echo Granting permissions for Network Service to the deployment directory...
icacls . /grant "Users":(OI)(CI)F
if %ERRORLEVEL% neq 0 goto error
echo OK

echo downloading nginx...
powershell .\setup\download.ps1 '%NGINXURL%' '%NGINXFILE%'
if %ERRORLEVEL% neq 0 goto error
echo nginx downloaded
echo installing nginx...
powershell .\setup\install_nginx.ps1 '%NGINXFILE%'
echo nginx installed...

if "%EMULATED%"=="true" exit /b 0

echo Configuring powershell permissions
powershell -c "set-executionpolicy unrestricted"

echo Downloading nodejs
powershell .\setup\download.ps1 '%NODEURL%' '%NODEFILE%'
if %ERRORLEVEL% neq 0 goto error
echo installing nodejs
powershell .\setup\install_node.ps1 '%NODEFILE%'

echo Downloading Ruby
powershell .\setup\download.ps1 '%RUBYURL%' '%RUBYFILE%'
if %ERRORLEVEL% neq 0 goto error
echo installing Ruby and Sinatra
powershell .\setup\install_ruby.ps1 '%RUBYFILE%'

echo SUCCESS
exit /b 0

:error

echo FAILED
exit /b -1