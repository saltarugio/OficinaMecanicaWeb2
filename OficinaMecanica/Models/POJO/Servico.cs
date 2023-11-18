using System.ComponentModel.DataAnnotations;

namespace OficinaMecanica.Models.POJO
{
    public class Servico
    {
        public int idServico { get; set; }
        public string descricao { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string nomeServico { get; set; }
        [Required(ErrorMessage = "Digite o preço")]
        public int preco { get; set; }
        [Required(ErrorMessage = "Digite a data de cadastro")]
        public DateTime dataCadastro { get; set; }
        [Required(ErrorMessage = "selecione o status")]
        public int status { get; set; }
        [Required(ErrorMessage = "Selecione uma categoria")]
        public int? categoria_idCategoria { get; set; }
        public Categoria categoria { get; set;}
        public List<Categoria> categorias { get; set; }
    }
}
