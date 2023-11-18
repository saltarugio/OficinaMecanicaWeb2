using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class CategoriaDAO
    {
        public List<Categoria> SelectObject()
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

            }
            catch (Exception ex)
            {
                String erro = ex.InnerException + ex.Message;
                erro += ex.StackTrace;

            }
            return listObj;
        }
        public String Insert(Categoria c)
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
                cmd.Parameters.AddWithValue("@nomeCategoria", c.nomeCategoria);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                SQL = "INSERT INTO Categoria (nomeCategoria,dataCadastro, status) VALUES (@nomeCategoria, @dataCadastro, @status)";
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
        public String Update(Categoria c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE categoria sET nomeCategoria = @nomeCategoria, dataCadastro = @dataCadastro, status = @status WHERE idCategoria = " + c.idCategoria;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeCategoria", c.nomeCategoria);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Categoria atualizada com sucesso!";
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
        public Categoria SelectSpecific(Categoria categoria)
        {

            Categoria obj = new Categoria();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCategoria, nomeCategoria, dataCadastro, status FROM Categoria WHERE idCategoria = " + categoria.idCategoria;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {

                    obj.idCategoria = Reader.GetInt32(0);
                    obj.nomeCategoria = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.dataCadastro = Reader.GetDateTime(2);
                    obj.status = Reader.GetInt32(3);
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
