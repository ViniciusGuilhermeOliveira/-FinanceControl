using System.Security.Cryptography;

namespace FinanceControl.Domain.Entities;


public class Usuario
{
    public int id {get;set;}
    public string nome {get;set;}
    public string cpf {get;set;}
}