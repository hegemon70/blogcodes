$current = [string] (Get-Location -PSProvider FileSystem)
$fileName = $args[0]
$file = "$current\$fileName"
$shell_app=new-object -com shell.application
$zip_file = $shell_app.namespace($file)
$destination = $shell_app.namespace($current)
$destination.Copyhere($zip_file.items())
Remove-Item $fileName
Copy-Item "$current\setup\nginx.conf" "$current\nginx-1.6.0\conf\" -force
$firewallFile = "$current\nginx-1.6.0\nginx.exe"
netsh advfirewall firewall add rule name="nginx" dir=in action=allow program="$firewallFile" enable=yes