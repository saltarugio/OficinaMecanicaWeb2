using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class RealizadoDAO
    {
        public string Insert(Realizado r)
        {
            string result;
            string SQL;
            Conexao objCon = new Conexao();
            MySqlConnection conn = new MySqlConnection();
            conn = objCon.abreConn();
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                cmd.Parameters.AddWithValue("@idOrdemServico", r.ordemServico_idOrdemServico);
                cmd.Parameters.AddWithValue("@idServico", r.servico_idServico);
                SQL = "INSERT INTO Categoria (ordemServico_idOrdemServico, servico_idServico) VALUES (@ordemServico_idOrdemServico, @servico_idServico)";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
                result = "Cadastrado com Sucesso!";
                objCon.fechaConn();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }
            return result;
        }
    }
}
