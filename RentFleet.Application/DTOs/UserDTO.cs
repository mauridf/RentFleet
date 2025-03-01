namespace RentFleet.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NomeAtendente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}