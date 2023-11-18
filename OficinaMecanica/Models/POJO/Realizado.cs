namespace OficinaMecanica.Models.POJO
{
    public class Realizado : OrdemServico
    {
        public int? ordemServico_idOrdemServico { get; set; }
        public int? servico_idServico { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public Servico Servico { get; set; }
        public List<OrdemServico> ordemServicos { get; set; }
        public List<Servico> servicos { get; set; }
    }
}
