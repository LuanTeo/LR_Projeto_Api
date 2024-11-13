namespace LR_Projeto_Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Genero {  get; set; }

        public string Email { get; set; }

        public int Cpf { get; set; }

        public string Telefone {  get; set; }

        public string Senha { get; set; }

        public DateTime Data_Nascimento { get; set; }
    }
}
