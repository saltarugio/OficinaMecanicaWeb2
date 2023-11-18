namespace OficinaMecanica.Models.POJO
{
    public class Funcionario : Cargo
    {
        public int idFuncionario { get; set; }
        public string nomeFuncionario { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string cpf { get; set; }
        public string sexo { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string uf { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime dataAdmissao { get; set; }
        public int numero { get; set; }
        public string rg { get; set; }
        public int salario { get; set; }
        public int status {  get; set; }
        public DateTime dataCadastro { get; set; }
        public int? cargo_idCargo { get; set; }
        public Cargo cargo { get; set; }
    }
}
