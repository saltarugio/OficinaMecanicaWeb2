using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class ClienteDAO
    {
        public List<Cliente> SelectObject()
        {
            List<Cliente> listObj = new List<Cliente>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCliente, nomeCliente FROM cliente";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cliente obj = new Cliente();
                    obj.idCliente = Reader.GetInt32(0);
                    obj.nomeCliente = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
        public String Insert(Cliente c)
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
                cmd.Parameters.AddWithValue("@nomeCliente", c.nomeCliente);
                cmd.Parameters.AddWithValue("@cnpj", c.cnpj);
                cmd.Parameters.AddWithValue("@cpf", c.cpf);
                cmd.Parameters.AddWithValue("@sexo", c.sexo);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@telefone", c.telefone);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@uf", c.uf);
                cmd.Parameters.AddWithValue("@cidade", c.cidade);
                cmd.Parameters.AddWithValue("@bairro", c.bairro);
                cmd.Parameters.AddWithValue("@cep", c.cep);
                cmd.Parameters.AddWithValue("@rua", c.rua);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@dataNascimento", c.dataNascimento);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                SQL = "INSERT INTO cliente (nomeCliente, cnpj, cpf, sexo, email, telefone, celular, uf, cidade, bairro, cep, rua, numero, dataNascimento, dataCadastro, status) VALUES (@nomeCliente, @cnpj, @cpf, @sexo, @email, @telefone, @celular, @uf, @cidade, @bairro, @cep, @rua, @numero, @dataNascimento, @dataCadastro, @status)";
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
        public String Update(Cliente c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE Cliente set nomeCliente = @nomeCliente, cnpj = @cnpj, cpf = @cpf, sexo = @sexo, email = @email, telefone = @telefone, celular = @celular, uf = @uf, cidade = @cidade, bairro = @bairro, cep = @cep, rua = @rua, numero = @numero, dataNascimento = @dataNascimento, dataCadastro = @dataCadastro, status = @status WHERE idCliente = " + c.idCliente;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeCliente", c.nomeCliente);
                cmd.Parameters.AddWithValue("@cnpj", c.cnpj);
                cmd.Parameters.AddWithValue("@cpf", c.cpf);
                cmd.Parameters.AddWithValue("@sexo", c.sexo);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@telefone", c.telefone);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@uf", c.uf);
                cmd.Parameters.AddWithValue("@cidade", c.cidade);
                cmd.Parameters.AddWithValue("@bairro", c.bairro);
                cmd.Parameters.AddWithValue("@cep", c.cep);
                cmd.Parameters.AddWithValue("@rua", c.rua);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@dataNascimento", c.dataNascimento);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Cliente atualizado com sucesso!";
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
        public Cliente SelectSpecific(Cliente c)
        {

            Cliente obj = new Cliente();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCliente, nomeCliente, cnpj, cpf, sexo, email, telefone, celular, uf, cidade, bairro, cep, rua, numero, dataNascimento, dataCadastro, status FROM cliente WHERE idCliente = " + c.idCliente;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {
                    obj.idCliente = Reader.GetInt32(0);
                    obj.nomeCliente = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.cnpj = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.cpf = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : string.Empty;
                    obj.sexo = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty;
                    obj.email = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : string.Empty;
                    obj.telefone = (!Reader.IsDBNull(6)) ? Reader.GetString(6) : string.Empty;
                    obj.celular = (!Reader.IsDBNull(7)) ? Reader.GetString(7) : string.Empty;
                    obj.uf = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : string.Empty;
                    obj.cidade = (!Reader.IsDBNull(9)) ? Reader.GetString(9) : string.Empty;
                    obj.bairro = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : string.Empty;
                    obj.cep = (!Reader.IsDBNull(11)) ? Reader.GetString(11) : string.Empty;
                    obj.rua = (!Reader.IsDBNull(12)) ? Reader.GetString(12) : string.Empty;
                    obj.numero = Reader.GetInt32(13);
                    obj.dataNascimento = Reader.GetDateTime(14);
                    obj.dataCadastro = Reader.GetDateTime(15);
                    obj.status = Reader.GetInt32(16);
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
