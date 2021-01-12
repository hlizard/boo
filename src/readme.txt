

1.发布exe时若“输出”中提示找不到：
src\booc\obj\Release\netcoreapp2.0\win-x86\booc.Core.dll
则手动复制过去就行了


2.Rider不支持pulish，自定义.NET Executable也有bug，会以mono运行dotnet，导致失败，所以只能直接使用命令（记得先将booc.csproj重命名为booc.csproj.bak）：
~/mycode/boo-0.9.6/src/booc $ /usr/share/dotnet/dotnet publish -r ubuntu.16.04-x64 -c Release


3.linux使用nant构建的hack：
wine z-zip-zstd覆盖解压build-tools/build-tools-offline.7z
sudo mkdir -p /Library/Frameworks/Mono.framework/Versions/Current/bin
cd /Library/Frameworks/Mono.framework/Versions/Current/bin
sudo ln -s /usr/bin/mcs ./mcs
sudo ln -s /usr/bin/mono ./mono
cd ~/mycode/boo-0.9.6/
#./build-tools/bootstrap
./nant


4..net core版booish启动方法：先publish工程booc.Core.csproj，再执行booish.cmd

