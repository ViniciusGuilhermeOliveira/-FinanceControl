using System.Data;
using Microsoft.Data.Sqlite; // O pacote do SQLite que você instalou
using FinanceControl.Application.Interfaces;

namespace FinanceControl.Infrastructure.Data;

public class SqliteConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    // A fábrica recebe a string de conexão no momento em que a API inicia
    public SqliteConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CriarConexao()
    {
        // Retorna a conexão específica do SQLite disfarçada como a interface genérica IDbConnection
        return new SqliteConnection(_connectionString);
    }
}