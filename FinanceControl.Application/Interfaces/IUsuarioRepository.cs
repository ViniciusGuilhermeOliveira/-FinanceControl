using System.Reflection.Metadata.Ecma335;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Interfaces;

public interface IUsuarioRepository
{
    void adicionar(Usuario usuario);
    IEnumerable<Usuario> ObterTodos();
}