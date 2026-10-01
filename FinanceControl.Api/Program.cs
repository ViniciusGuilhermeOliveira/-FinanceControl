using FinanceControl.Application.Interfaces;
using FinanceControl.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IDbConnectionFactory>(new SqliteConnectionFactory(connectionString));


var app = builder.Build();



SQLitePCL.Batteries.Init();


if (connectionString != null)
{
    FinanceControl.Infrastructure.DatabaseMigration.AtualizarBancoDeDados(connectionString);    
}



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // Habilita o Swagger UI
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "API v1");
        options.RoutePrefix = string.Empty; // Define o Swagger na raiz (opcional: localhost:xxxx/)
    });
}

app.UseHttpsRedirection();
app.Run();


