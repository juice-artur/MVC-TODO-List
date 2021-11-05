# MVC-TODO-List

## Web API for TODO list using  `SQL`, `Entity Framework Core`, `ASP.NET Core` and `REST API`
***
# How run this 
## Required packages
```shell
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package EFCore.NamingConventions
 ```
## Packages for working migrations
```shell
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
 ```
## Setup migration
```shell
dotnet ef migrations add InitialSchema
dotnet ef database update
 ```
## Run application
```shell
dotnet run
 ```
# Remove migration
 ```shell
dotnet ef migrations  remove
dotnet ef database update 0
 ```
