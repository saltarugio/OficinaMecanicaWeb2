namespace OficinaMecanica.Models.POJO
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string cnpj { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public string nomeFantasia { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string complemento { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataNascimento { get; set; }
        public int numero { get; set; }
        public int status { get; set; }
    }
}
