using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class MarcaDAO
    {
        public List<Marca> SelectObject()
        {
            List<Marca> listObj = new List<Marca>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idMarca, nomeMarca FROM marca";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Marca obj = new Marca();
                    obj.idMarca = Reader.GetInt32(0);
                    obj.nomeMarca = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
        public String Insert(Marca c)
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
                cmd.Parameters.AddWithValue("@nomeMarca", c.nomeMarca);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                SQL = "INSERT INTO Marca (nomeMarca,dataCadastro, status) VALUES (@nomeMarca, @dataCadastro, @status)";
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
        public String Update(Marca c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE Marca set nomeMarca = @nomeMarca, dataCadastro = @dataCadastro, status = @status WHERE idMarca = " + c.idMarca;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeMarca", c.nomeMarca);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Marca atualizada com sucesso!";
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
        public Marca SelectSpecific(Marca marca)
        {

            Marca obj = new Marca();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idMarca, nomeMarca, dataCadastro, status FROM marca WHERE idMarca = " + marca.idMarca;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {

                    obj.idMarca = Reader.GetInt32(0);
                    obj.nomeMarca = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
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
