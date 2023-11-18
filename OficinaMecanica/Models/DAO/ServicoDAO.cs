using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;
using System.Data;

namespace OficinaMecanica.Models.DAO
{
    public class ServicoDAO
    {
        public List<Categoria> Busca()
        {
            List<Categoria> listObj = new List<Categoria>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCategoria, nomeCategoria FROM categoria";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Categoria obj = new Categoria();
                    obj.idCategoria = Reader.GetInt32(0);
                    obj.nomeCategoria = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;

                    listObj.Add(obj);
                }
                command.Dispose();
                objCon.fechaConn();

            } catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

            }
            return listObj;
        }
        public List<Servico> SelectObject()
        {
            List<Servico> listObj = new List<Servico>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idServico, nomeServico, descricao, preco, dataCadastro, status,categoria_idCategoria FROM servico";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Servico obj = new Servico();
                    obj.idServico = Reader.GetInt32(0);
                    obj.nomeServico = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
        public String Insert(Servico c)
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
                cmd.Parameters.AddWithValue("@nomeServico", c.nomeServico);
                cmd.Parameters.AddWithValue("@descricao", c.descricao);
                cmd.Parameters.AddWithValue("@preco", c.preco);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@categoria_idCategoria", c.categoria_idCategoria);
                SQL = "INSERT INTO Servico (nomeServico, descricao, preco, dataCadastro, status,categoria_idCategoria) VALUES (@nomeServico, @descricao, @preco, @dataCadastro, @status,@categoria_idCategoria)";
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
        public String Update(Servico c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE servico SET nomeServico = @nomeServico, descricao = @descricao, preco = @preco, dataCadastro = @dataCadastro, status = @status, categoria_idCategoria = @categoria_idCategoria WHERE idServico = " + c.idServico;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeServico", c.nomeServico);
                cmd.Parameters.AddWithValue("@descricao", c.descricao);
                cmd.Parameters.AddWithValue("@preco", c.preco);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@categoria_idCategoria", c.categoria_idCategoria);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Servico atualizada com sucesso!";
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
        public Servico SelectSpecific(Servico servico)
        {

            Servico obj = new Servico();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT servico.idServico, servico.nomeServico, servico.descricao, servico.preco, servico.dataCadastro, servico.status, servico.categoria_idCategoria, categoria.nomeCategoria FROM servico INNER JOIN categoria ON servico.categoria_idCategoria = categoria.idCategoria WHERE servico.idServico = " + servico.idServico;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {
                    obj.idServico = Reader.GetInt32(0);
                    obj.nomeServico = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.descricao = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.preco = Reader.GetInt32(3);
                    obj.dataCadastro = Reader.GetDateTime(4);
                    obj.status = Reader.GetInt32(5);
                    obj.categoria_idCategoria = Reader.GetInt32(6);
                    obj.categoria = new Categoria { nomeCategoria = Reader.GetString(7) };
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
