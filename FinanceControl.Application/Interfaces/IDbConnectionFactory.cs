using System.Data; // Pacote nativo do .NET que contém o IDbConnection

namespace FinanceControl.Application.Interfaces;

public interface IDbConnectionFactory
{
    // Qualquer banco do mundo C# (SQLite, Postgres, SQL Server) implementa IDbConnection
    IDbConnection CriarConexao(); 
}