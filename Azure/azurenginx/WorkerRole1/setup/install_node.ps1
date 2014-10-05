$current = [string] (Get-Location -PSProvider FileSystem)
$fileName = $args[0]
$node = "$current\$fileName"
msiexec /quiet /i $node
Remove-Item $fileName