@echo off
dotnet publish -c Release -o out 1>&2
if %errorlevel% neq 0 exit /b %errorlevel%
dotnet out/MyBot.dll