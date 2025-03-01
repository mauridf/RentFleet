using System;

namespace RentFleet.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string NomeAtendente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; } // ADM (Admin), USR (User) e CLI (Cliente).
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}