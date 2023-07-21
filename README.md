# .Net Core Upload Excel file

> This project use for practice develop web api using .Net Core web api for upload file excel file and store to Postgres database.

### Tools
- Visual Studio Code
- .Net SDK version 6
- Docker
- Postgres

### Packages
- Microsoft.EntityFrameworkCore.Design
- Npgsql.EntityFrameworkCore.PostgreSQ
- Microsoft.EntityFrameworkCore
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection"
- EPPlus


## Steps 
Create Project using command like this. In this example I using dotnet version 6

```bash
dotnet new webapi -o ReadExcelFile -f net6.0
```

After project created open it using this command.
```bash
code ReadExcelFile
```

Install all package. If you use NuGet GUI extension on VSCode you can copy package name for find it and __click__ install version you want to use.
