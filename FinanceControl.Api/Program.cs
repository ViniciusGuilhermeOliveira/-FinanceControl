var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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


