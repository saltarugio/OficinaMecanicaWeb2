using Org.BouncyCastle.Asn1.Cms;

namespace OficinaMecanica.Models.POJO
{
    public class OrdemServico
    {
        public int idOrdemServico { get; set; }
        public DateTime data { get; set; }
        public DateTime dataCadastro { get; set; }
        public string observacao { get; set; }
        public TimeSpan hora { get; set; }
        public int desconto { get; set; }
        public Decimal valor { get; set; }
        public int? funcionario_idFuncionario { get; set; }
        public int? cliente_idCliente { get; set; }
        public int? veiculo_idVeiculo { get; set; }
        public Servico servico { get; set; }
        public Funcionario funcionario { get; set; }
        public Cliente cliente { get; set; }
        public Veiculo veiculo { get; set; }
    }
}
