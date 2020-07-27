https://github.com/trycatchlearn/skinet 



 mkdir skinet

cd /c/Projects/waleryjasinski/learn-to-build-an-e-commerce-app-with-net-core-and-angular/skinet
cd c:\Projects\waleryjasinski\learn-to-build-an-e-commerce-app-with-net-core-and-angular\skinet 


dotnet new sln
dotnet new webapi -o API
dotnet sln add .\API\

F1 .NET generate assets for build and debug

dotnet dev-certs https -t

dotnet new classlib -o Core
dotnet new classlib -o Infrastructure

dotnet sln add .\Core\
dotnet sln add .\Infrastructure\

dotnet watch run 

