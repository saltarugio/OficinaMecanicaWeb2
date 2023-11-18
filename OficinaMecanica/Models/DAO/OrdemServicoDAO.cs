using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using OficinaMecanica.Models.POJO;
using System.Data;

namespace OficinaMecanica.Models.DAO
{
    public class OrdemServicoDAO
    {
        public (List<Funcionario> fun,List<Veiculo> vei, List<Cliente> cli, List<Servico> ser) Busca()
        {
            List<Funcionario> listObjFun = new List<Funcionario>();
            List<Veiculo> listObjVei = new List<Veiculo>();
            List<Cliente> listObjCli = new List<Cliente>();
            List<Servico> listObjSer = new List<Servico>();

            try
            {
                //----------------------------Conexão com o banco de dados-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idFuncionario, nomeFuncionario FROM funcionario";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Funcionario objFuncionario  = new Funcionario();
                    objFuncionario.idFuncionario = Reader.GetInt32(0);
                    objFuncionario.nomeFuncionario = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    listObjFun.Add(objFuncionario);
                }

                Reader.Close();

                command.CommandText = "SELECT idVeiculo, placa FROM veiculo";
                Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Veiculo objVeiculo = new Veiculo();
                    objVeiculo.idVeiculo = Reader.GetInt32(0);
                    objVeiculo.placa = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    listObjVei.Add(objVeiculo);
                }

                Reader.Close();

                command.CommandText = "SELECT idCliente, nomeCliente FROM cliente";
                Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.idCliente = Reader.GetInt32(0);
                    objCliente.nomeCliente = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    listObjCli.Add(objCliente);
                }

                Reader.Close();

                command.CommandText = "SELECT idServico, nomeServico, preco FROM servico";
                Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Servico objServico = new Servico();
                    objServico.idServico = Reader.GetInt32(0);
                    objServico.nomeServico = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    objServico.preco = Reader.GetInt32(2);
                    listObjSer.Add(objServico);
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
            return (listObjFun, listObjVei, listObjCli, listObjSer);
        }
        public List<OrdemServico> SelectObject()
        {
            List<OrdemServico> listObj = new List<OrdemServico>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idOrdemServico, data FROM ordemservico";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    OrdemServico obj = new OrdemServico();
                    obj.idOrdemServico = Reader.GetInt32(0);
                    obj.data = Reader.GetDateTime(1);


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
        public String Insert(OrdemServico c)
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
                cmd.Parameters.AddWithValue("@data", c.data);
                cmd.Parameters.AddWithValue("@observacao", c.observacao);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@hora", c.hora);
                cmd.Parameters.AddWithValue("@desconto", c.desconto);
                cmd.Parameters.Add("@valor", MySqlDbType.Decimal).Value = c.valor;
                cmd.Parameters.AddWithValue("@funcionario_idFuncionario", c.funcionario_idFuncionario);
                cmd.Parameters.AddWithValue("@veiculo_idVeiculo", c.veiculo_idVeiculo);
                cmd.Parameters.AddWithValue("@cliente_idCliente", c.cliente_idCliente);
                SQL = "INSERT INTO OrdemServico (data, observacao, dataCadastro, hora, desconto, valor, funcionario_idFuncionario, veiculo_idVeiculo, cliente_idCliente) VALUES (@data, @observacao, @dataCadastro, @hora, @desconto, @valor,  @funcionario_idFuncionario, @veiculo_idVeiculo, @cliente_idCliente)";
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
        public String Update(OrdemServico c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE ordemservico SET data = @data, observacao = @observacao, dataCadastro = @dataCadastro, hora = @hora, desconto = @desconto, valor = @valor, funcionario_idFuncionario = @funcionario_idFuncionario, veiculo_idVeiculo = @veiculo_idVeiculo, cliente_idCliente = @cliente_idCliente WHERE idOrdemServico = " + c.idOrdemServico;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@data", c.data);
                cmd.Parameters.AddWithValue("@observacao", c.observacao);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@hora", c.hora);
                cmd.Parameters.AddWithValue("@desconto", c.desconto);
                cmd.Parameters.AddWithValue("@valor", c.valor);
                cmd.Parameters.AddWithValue("@funcionario_idFuncionario", c.funcionario_idFuncionario);
                cmd.Parameters.AddWithValue("@veiculo_idVeiculo", c.veiculo_idVeiculo);
                cmd.Parameters.AddWithValue("@cliente_idCliente", c.cliente_idCliente);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "OrdemServico atualizada com sucesso!";
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
        public OrdemServico SelectSpecific(OrdemServico ordemServico)
        {

            OrdemServico obj = new OrdemServico();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT ordemservico.idOrdemServico, ordemservico.data, ordemservico.observacao, ordemservico.dataCadastro, ordemservico.hora, ordemservico.desconto, ordemservico.valor, ordemservico.funcionario_idFuncionario, ordemservico.veiculo_idVeiculo, ordemservico.cliente_idCliente, funcionario.nomeFuncionario, veiculo.placa, cliente.nomeCliente FROM ordemservico INNER JOIN funcionario ON ordemservico.funcionario_idFuncionario = idFuncionario INNER JOIN veiculo ON ordemservico.veiculo_idVeiculo = idVeiculo INNER JOIN cliente ON ordemservico.cliente_idCliente = idCliente WHERE idOrdemServico =" + ordemServico.idOrdemServico;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {

                    obj.idOrdemServico = Reader.GetInt32(0);
                    obj.data = Reader.GetDateTime(1);
                    obj.observacao = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.dataCadastro = Reader.GetDateTime(3);
                    obj.hora = Reader.GetTimeSpan(4);
                    obj.desconto = Reader.GetInt32(5);
                    obj.valor = Reader.GetInt32(6);
                    obj.funcionario_idFuncionario = Reader.GetInt32(7);
                    obj.veiculo_idVeiculo = Reader.GetInt32(8);
                    obj.cliente_idCliente = Reader.GetInt32(9);
                    obj.funcionario = new Funcionario { nomeFuncionario = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : string.Empty };
                    obj.veiculo = new Veiculo { placa = (!Reader.IsDBNull(11)) ? Reader.GetString(11) : string.Empty };
                    obj.cliente = new Cliente { nomeCliente = (!Reader.IsDBNull(12)) ? Reader.GetString(12) : string.Empty };
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
