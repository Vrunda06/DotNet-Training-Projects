# EFCoreSQLServer

ASP.NET Core project demonstrating EF Core with SQL Server.

## Features
- Code-first migration setup
- Basic Book model

## Run Instructions
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```