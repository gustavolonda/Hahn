# Hahn.ApplicatonProcess.Application

### Programming language
<code><img height="40" src="https://www.fixedbuffer.com/wp-content/uploads/2019/06/reflexion.png" title="c#"></code>



### IDE
<code><img height="40" src="https://alternativas-a.com/wp-content/uploads/alternativas-a-Visual-Studio-Code-150x150.jpg" title="Visual Code"></code>

### Steps to run the project

#### 1. Add References

- dotnet add ./Hahn.ApplicatonProcess.July2021.Data/Hahn.ApplicatonProcess.July2021.Data.csproj reference ./Hahn.ApplicatonProcess.July2021.Domain/Hahn.ApplicatonProcess.July2021.Domain.csproj

- dotnet add ./Hahn.ApplicatonProcess.July2021.Web/Hahn.ApplicatonProcess.July2021.Web.csproj reference ./Hahn.ApplicatonProcess.July2021.Data/Hahn.ApplicatonProcess.July2021.Data.csproj

- dotnet add ./Hahn.ApplicatonProcess.July2021.Web/Hahn.ApplicatonProcess.July2021.Web.csproj reference ./Hahn.ApplicatonProcess.July2021.Domain/Hahn.ApplicatonProcess.July2021.Domain.csproj

#### 2. Add External Libraries

- \Hahn\Hahn.ApplicatonProcess.July2021.Data>
    dotnet add package Microsoft.EntityFrameworkCore.InMemory  --version 5.0.8

- \Hahn\Hahn.ApplicatonProcess.July2021.Domain>
    dotnet add package FluentValidation --version 5.0.8

- \Hahn\Hahn.ApplicatonProcess.July2021.Web>
    dotnet add package Microsoft.EntityFrameworkCore.InMemory  --version 5.0.8
    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 5.0.8
    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 8.1.1
    dotnet add package BCrypt.Net-Next --version 4.0.2
    dotnet add package Serilog.AspNetCore --version 4.1.0
    dotnet add package Serilog.Filters.Expressions --version 2.1.0
    dotnet add package Serilog.Settings.Configuration --version 3.1.0
    dotnet add package System.IdentityModel.Tokens.Jwt --version 6.12.0
    dotnet add package Microsoft.IdentityModel.Tokens --version 6.12.0
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.8
    
#### 2. Install docker & docker-compose

#### 3. sudo docker-compose up --d




