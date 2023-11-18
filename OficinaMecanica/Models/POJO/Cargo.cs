using System.ComponentModel.DataAnnotations;

namespace OficinaMecanica.Models.POJO
{
    public class Cargo
    {
        public int idCargo { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string nomeCargo { get; set; }
        public DateTime dataCadastro { get; set; }
        public int status { get; set; }

    }
}
