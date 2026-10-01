using Dapper;
using FinanceControl.Application.Interfaces;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IDbConnectionFactory _dbFactory;

    // A fábrica que configuramos anteriormente é injetada aqui
    public UsuarioRepository(IDbConnectionFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public void adicionar(Usuario usuario)
    {
         using var conexao = _dbFactory.CriarConexao();
        
        // No INSERT, as variáveis @Nome e @Cpf devem ter o nome exato das propriedades da classe C#
        string sql = @"
            INSERT INTO Usuario (usu_nam, usu_cpf) 
            VALUES (@Nome, @Cpf)";
        
        conexao.Execute(sql, usuario);
    }

    public IEnumerable<Usuario> ObterTodos()
    {
        using var conexao = _dbFactory.CriarConexao();
        
        // No SELECT, usamos AS para ensinar o Dapper a colocar a coluna 'usu_nam' dentro da propriedade 'Nome'
        string sql = @"
            SELECT 
                usu_id AS Id, 
                usu_nam AS Nome, 
                usu_cpf AS Cpf 
            FROM Usuario";
        
        return conexao.Query<Usuario>(sql);
    }
}