using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using OficinaMecanica.Models.POJO;
using System.Data;

namespace OficinaMecanica.Models.DAO
{
    public class VeiculoDAO
    {
        public (List<Marca> marcas, List<Modelo> modelos, List<Cliente> clientes) Busca()
        {
            List<Marca> marcas = new List<Marca>();
            List<Modelo> modelos = new List<Modelo>();
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                //----------------------------Conexão com o banco de dados-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idMarca, nomeMarca FROM marca";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Marca objMarca = new Marca();
                    objMarca.idMarca = Reader.GetInt32(0);
                    objMarca.nomeMarca = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    marcas.Add(objMarca);
                }

                Reader.Close();

                command.CommandText = "SELECT idModelo, nomeModelo FROM modelo";
                Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Modelo objModelo = new Modelo();
                    objModelo.idModelo = Reader.GetInt32(0);
                    objModelo.nomeModelo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    modelos.Add(objModelo);
                }

                Reader.Close();

                command.CommandText = "SELECT idCliente, nomeCliente FROM cliente";
                Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.idCliente = Reader.GetInt32(0);
                    objCliente.nomeCliente = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    clientes.Add(objCliente);
                }

                Reader.Close();

                command.Dispose();
                objCon.fechaConn();
            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;
            }

            return (marcas, modelos, clientes);
        }
        public List<Veiculo> SelectObject()
        {
            List<Veiculo> listObj = new List<Veiculo>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idVeiculo, placa FROM veiculo";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Veiculo obj = new Veiculo();
                    obj.idVeiculo = Reader.GetInt32(0);
                    obj.placa = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


                    listObj.Add(obj);
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

            }
            return listObj;
        }
        public String Insert(Veiculo c)
        {
            string result;
            string SQL;
            Conexao objCon = new Conexao();
            MySqlConnection conn = new MySqlConnection();
            //ValidaBL validacao = new ValidaBL();
            conn = objCon.abreConn();
            MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                cmd.Parameters.AddWithValue("@ano", c.ano);
                cmd.Parameters.AddWithValue("@placa", c.placa);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@marca_idMarca", c.marca_idMarca);
                cmd.Parameters.AddWithValue("@modelo_idModelo", c.modelo_idModelo);
                cmd.Parameters.AddWithValue("@cliente_idCliente", c.cliente_idCliente);
                SQL = "INSERT INTO Veiculo (ano, placa, dataCadastro, status, marca_idMarca, modelo_idModelo, cliente_idCliente) VALUES (@ano, @placa, @dataCadastro, @status, @marca_idMarca, @modelo_idModelo, @cliente_idCliente)";
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
        public String Update(Veiculo c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE Veiculo SET ano = @ano, placa = @placa, dataCadastro = @dataCadastro, status = @status, marca_idMarca = @marca_idMarca, modelo_idModelo = @modelo_idModelo, cliente_idCliente = @cliente_idCliente WHERE idVeiculo = " + c.idVeiculo;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ano", c.ano);
                cmd.Parameters.AddWithValue("@placa", c.placa);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@marca_idMarca", c.marca_idMarca);
                cmd.Parameters.AddWithValue("@modelo_idModelo", c.modelo_idModelo);
                cmd.Parameters.AddWithValue("@cliente_idCliente", c.cliente_idCliente);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Veiculo atualizada com sucesso!";
                }
                else
                {
                    result = "Erro";
                }
                cmd.Dispose();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }
            return result;
        }
        public Veiculo SelectSpecific(Veiculo Veiculo)
        {

            Veiculo obj = new Veiculo();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idVeiculo, ano, placa, veiculo.dataCadastro, veiculo.status, marca_idMarca, modelo_idModelo, cliente_idCliente, marca.nomeMarca, modelo.nomeModelo, cliente.nomeCliente FROM veiculo INNER JOIN marca ON veiculo.marca_idMarca = marca.idMarca INNER JOIN modelo ON veiculo.modelo_idModelo = modelo.idModelo INNER JOIN cliente ON veiculo.cliente_idCliente = cliente.idCliente WHERE idVeiculo = " + Veiculo.idVeiculo;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {
                    obj.idVeiculo = Reader.GetInt32(0);
                    obj.ano = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.placa = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.dataCadastro = Reader.GetDateTime(3);
                    obj.status = Reader.GetInt32(4);
                    obj.marca_idMarca = Reader.GetInt32(5);
                    obj.modelo_idModelo = Reader.GetInt32(6);
                    obj.cliente_idCliente = Reader.GetInt32(7);
                    obj.marca = new Marca { nomeMarca = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : string.Empty };
                    obj.modelo = new Modelo { nomeModelo = (!Reader.IsDBNull(9)) ? Reader.GetString(9) : string.Empty };
                    obj.cliente = new Cliente { nomeCliente = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : string.Empty };
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

            }
            return obj;
        }
    }
}
