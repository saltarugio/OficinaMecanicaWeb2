using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class ModeloDAO
    {
        public List<Modelo> SelectObject()
        {
            List<Modelo> listObj = new List<Modelo>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idModelo, nomeModelo FROM modelo";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Modelo obj = new Modelo();
                    obj.idModelo = Reader.GetInt32(0);
                    obj.nomeModelo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
        public String Insert(Modelo c)
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
                cmd.Parameters.AddWithValue("@nomeModelo", c.nomeModelo);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                SQL = "INSERT INTO Modelo (nomeModelo,dataCadastro, status) VALUES (@nomeModelo, @dataCadastro, @status)";
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
        public String Update(Modelo modelo)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE Modelo set nomeModelo = @nomeModelo, dataCadastro = @dataCadastro, status = @status WHERE idModelo = " + modelo.idModelo;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeModelo", modelo.nomeModelo);
                cmd.Parameters.AddWithValue("@dataCadastro", modelo.dataCadastro);
                cmd.Parameters.AddWithValue("@status", modelo.status);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Modelo atualizado com sucesso!";
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
        public Modelo SelectSpecific(Modelo modelo)
        {

            Modelo obj = new Modelo();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idModelo, nomeModelo, dataCadastro, status FROM Modelo WHERE idModelo = " + modelo.idModelo;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {

                    obj.idModelo = Reader.GetInt32(0);
                    obj.nomeModelo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
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
