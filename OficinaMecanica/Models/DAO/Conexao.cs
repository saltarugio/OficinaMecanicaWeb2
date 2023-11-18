using MySql.Data.MySqlClient;

namespace OficinaMecanica.Models.DAO
{
    using MySql.Data.MySqlClient;
    using System;

    public class Conexao
    {
        private MySqlConnection conn;

        public MySqlConnection abreConn()
        {
            try
            {
                // Substitua as informações de conexão com o seu servidor MySQL
                string connectionString = "Server=127.0.0.1;Database=OficinaMecanica;Uid=root;Pwd=root;Convert Zero Datetime=True";

                conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (MySqlException ex)
            {
                // Lida com erros de conexão, você pode personalizar esta parte de acordo com suas necessidades.
                Console.WriteLine("Erro de conexão: " + ex.Message);
                return null;
            }
        }

        public void fechaConn()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }

}
