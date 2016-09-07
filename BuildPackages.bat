:REM ===============================
:REM Build NuGet Packages for Tethys
:REM ===============================

mkdir export\packages

cd Tethys
nuget pack Tethys.csproj
move Tethys.*.nupkg ..\export\packages
cd ..

cd Tethys.Forms
nuget pack Tethys.Forms.csproj
move Tethys.*.nupkg ..\export\packages
cd ..

cd Tethys.Win
nuget pack Tethys.Win.csproj
move Tethys.*.nupkg ..\export\packages
cd ..

:REM ============================
:REM ============================
