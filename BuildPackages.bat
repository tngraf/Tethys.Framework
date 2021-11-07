:REM ===============================
:REM Build NuGet Packages for Tethys
:REM ===============================

mkdir export\packages

cd Tethys
nuget pack Tethys.Framework.nuspec
move Tethys.*.nupkg ..\export\packages 
cd ..

cd Tethys.Forms
nuget pack Tethys.Forms.nuspec
move Tethys.*.nupkg ..\export\packages
cd ..

cd Tethys.Forms.NET5
nuget pack Tethys.Forms.NET5.nuspec
move Tethys.*.nupkg ..\export\packages 
cd ..

cd Tethys.Win
nuget pack Tethys.Win.nuspec
move Tethys.*.nupkg ..\export\packages
cd ..

cd Tethys.Win.NET5
nuget pack Tethys.Win.NET5.nuspec
move Tethys.*.nupkg ..\export\packages 
cd ..

:REM ============================
:REM ============================
