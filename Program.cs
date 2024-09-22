//dotnet new web = criar projeto
//dotnet run ou dotnet watch run = executar

//dotnet add package Microsoft.EntityFrameworkCore
//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet add package Microsoft.EntityFrameworkCore.Tools
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer

using minimal_api.Domain.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/Login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login com sucesso");
    }
    else
    {
        return Results.Unauthorized();
    }
});



app.Run();
