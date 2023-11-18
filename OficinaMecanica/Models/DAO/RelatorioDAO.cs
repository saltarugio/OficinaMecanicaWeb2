using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;
using System.Globalization;

namespace OficinaMecanica.Models.DAO
{
    public class RelatorioDAO
    {
        public Dictionary<string, int> QuantidadeQrS()
        {
            Dictionary<string, int> countPorFuncionario = new Dictionary<string, int>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT f.nomeFuncionario, COUNT(o.idOrdemServico) AS Quantidade " +
                                      "FROM funcionario f " +
                                      "LEFT JOIN ordemservico o ON f.idFuncionario = o.funcionario_idFuncionario " +
                                      "GROUP BY f.idFuncionario";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    string nomeFuncionario = Reader.GetString(0);
                    int quantidade = Reader.GetInt32(1);

                    // Adiciona a quantidade ao dicionário associada ao nome do funcionário
                    countPorFuncionario[nomeFuncionario] = quantidade;
                }

                command.Dispose();
                objCon.fechaConn();

            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

                // Lide com exceções, se necessário
            }
            return countPorFuncionario;
        }
        public Dictionary<string, int> QuantidadeVei()
        {
            Dictionary<string, int> countPorVeiculo = new Dictionary<string, int>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT c.nomeCliente, COUNT(v.idVeiculo) AS QuantidadeVeiculos FROM cliente c LEFT JOIN veiculo v ON c.idCliente = v.cliente_idCliente GROUP BY c.idCliente;";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    string placa = Reader.GetString(0);
                    int quantidade = Reader.GetInt32(1);

                    // Adiciona a quantidade ao dicionário associada ao nome do funcionário
                    countPorVeiculo[placa] = quantidade;
                }

                command.Dispose();
                objCon.fechaConn();

            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

                // Lide com exceções, se necessário
            }
            return countPorVeiculo;
        }
        public Dictionary<string, decimal> CalcularValorPorData()
        {
            Dictionary<string, decimal> valorPorData = new Dictionary<string, decimal>();

            try
            {
                //----------------------------Conexão com o MySQL-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT valor, data FROM ordemservico ORDER BY data;";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    decimal valor = Convert.ToDecimal(Reader["valor"], CultureInfo.InvariantCulture);

                    DateTime data = Reader.GetDateTime(1);
                    string dataFormatada = data.ToString("yyyy-MM-dd");


                    // Verifica se a chave (data) já existe no dicionário
                    if (valorPorData.ContainsKey(dataFormatada))
                    {
                        // Se a data já existe, adiciona o valor ao total existente
                        valorPorData[dataFormatada] += valor;
                    }
                    else
                    {
                        // Se a data não existe, adiciona uma nova entrada no dicionário
                        valorPorData[dataFormatada] = valor;
                    }
                }

                command.Dispose();
                objCon.fechaConn();
            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

                // Lide com exceções, se necessário
            }

            return valorPorData;
        }

    }
}
