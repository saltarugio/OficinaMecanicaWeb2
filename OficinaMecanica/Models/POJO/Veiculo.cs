

namespace OficinaMecanica.Models.POJO
{
    public class Veiculo
    {
        public int idVeiculo { get; set; }
        public string ano { get; set; }
        public string placa { get; set; }
        public DateTime dataCadastro { get; set; }
        public int status { get; set; }
        public int? marca_idMarca { get; set; }
        public int? modelo_idModelo { get; set; }
        public int? cliente_idCliente { get; set; }
        public Marca marca { get; set; }
        public Modelo modelo { get; set;}
        public Cliente cliente { get; set; }
        public List<Marca> marcas { get; set; }
        public List<Modelo> modelos { get; set; }
        public List<Cliente> clientes { get; set; }
    }
}
