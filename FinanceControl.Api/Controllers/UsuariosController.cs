using Microsoft.AspNetCore.Mvc;
using FinanceControl.Application.Interfaces;
using FinanceControl.Domain.Entities;
using FinanceControl.Api.DTOs;

namespace FinanceControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")] // A URL ficará: localhost:porta/api/usuarios
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    // A Injeção de Dependência entrega o repositório pronto aqui
    public UsuariosController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult CriarUsuario([FromBody] CriarUsuarioRequest request)
    {
        // 1. Mapeia o DTO que veio da internet para a Entidade de Domínio
        var novoUsuario = new Usuario 
        {
            nome = request.Nome,
            cpf = request.Cpf
        };

        // 2. Aciona o Repositório para salvar no banco
        _usuarioRepository.adicionar(novoUsuario);

        // 3. Retorna Sucesso (HTTP 200)
        return Ok(new { Mensagem = "Usuário salvo com sucesso!" });
    }

    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        // Consulta o banco e retorna a lista de usuários no formato JSON
        var usuarios = _usuarioRepository.ObterTodos();
        return Ok(usuarios);
    }
}