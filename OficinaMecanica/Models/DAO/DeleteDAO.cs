using MySql.Data.MySqlClient;

namespace OficinaMecanica.Models.DAO
{
    public class DeleteDAO
    {
        public String DeleteFun(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from funcionario WHERE idFuncionario = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteCar(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from cargo WHERE idCargo = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteCat(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from categoria WHERE idCategoria = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteCli(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from cliente WHERE idCliente = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteMar(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from marca WHERE idMarca = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteMod(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from modelo WHERE idModelo = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteOrS(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from ordemservico WHERE idOrdemServico = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteSer(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from servico WHERE idServico = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
                objCon.fechaConn();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                result = "Error " + ex.Number + " has occurred: " + ex.Message;
            }


            return result;
        }
        public String DeleteVei(int id)
        {

            string result;
            Conexao objCon = new Conexao();
            MySqlConnection Conn = new MySqlConnection();
            Conn = objCon.abreConn();
            MySqlCommand command = Conn.CreateCommand();
            try
            {
                command.CommandText = "delete from veiculo WHERE idVeiculo = " + id + "";
                int verify = command.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Data deleted into database successfully!";
                }
                else
                {
                    result = "Error";
                }
                command.Dispose();
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
