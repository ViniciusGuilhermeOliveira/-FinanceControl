using DbUp;
using System.Reflection;

namespace FinanceControl.Infrastructure;

public static class DatabaseMigration
{
    public static void AtualizarBancoDeDados(string connectionString)
    {
        // Configura o DbUp para o SQLite apontando para seus scripts
        var upgrader = DeployChanges.To
            .SqliteDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

        // Executa os scripts que ainda não foram rodados
        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            throw new System.Exception("Erro ao rodar as migrations do banco de dados", result.Error);
        }
    }
}