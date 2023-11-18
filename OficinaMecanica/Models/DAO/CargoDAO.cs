using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class CargoDAO
    {
        public List<Cargo> SelectObject()
        {
            List<Cargo> listObj = new List<Cargo>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCargo, nomeCargo FROM cargo";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cargo obj = new Cargo();
                    obj.idCargo = Reader.GetInt32(0);
                    obj.nomeCargo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
    public String Insert(Cargo c)
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
                cmd.Parameters.AddWithValue("@nomeCargo", c.nomeCargo);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                SQL = "INSERT INTO cargo (nomeCargo,dataCadastro, status) VALUES (@nomeCargo, @dataCadastro, @status)";
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
        public String Update(Cargo c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE cargo SET nomeCargo = @nomeCargo, dataCadastro = @dataCadastro, status = @status WHERE idCargo = "+c.idCargo;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeCargo", c.nomeCargo);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Cargo atualizado com sucesso!";
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
        public Cargo SelectSpecific(Cargo cargo)
        {

            Cargo obj = new Cargo();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCargo, nomeCargo, dataCadastro, status FROM cargo WHERE idCargo = "+cargo.idCargo;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {

                    obj.idCargo = Reader.GetInt32(0);
                    obj.nomeCargo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
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
