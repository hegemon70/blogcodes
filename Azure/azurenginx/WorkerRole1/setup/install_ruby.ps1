$current = [string] (Get-Location -PSProvider FileSystem)
$fileName = $args[0]
$rubyargs= "/tasks=""assocfiles,modpath"" /silent"
$file = "$current\$fileName" 
Start-Process $file -ArgumentList $rubyargs -Wait
Write-Host
Write-Host "Ruby installed"
Write-Host
Remove-Item $fileName
$rubydir = 'C:\ruby200'
if(Test-Path -Path $rubydir ){
	Write-Host
	Write-Host "installing sinatra from C:\"
    Write-Host
    cmd.exe /C "C:\Ruby200\bin\gem.bat install sinatra --no-ri --no-rdoc"
}
else{
	Write-Host
	Write-Host "installing sinatra from D:\"
    Write-Host
    cmd.exe /C "D:\Ruby200\bin\gem.bat install sinatra --no-ri --no-rdoc"
}