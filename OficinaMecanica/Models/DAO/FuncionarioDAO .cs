using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class FuncionarioDAO
    {
        public List<Cargo> Busca()
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
                    obj.idCargo= Reader.GetInt32(0);
                    obj.nomeCargo= (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
        public List<Funcionario> SelectObject()
        {
            List<Funcionario> listObj = new List<Funcionario>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idFuncionario, nomeFuncionario FROM funcionario";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Funcionario obj = new Funcionario();
                    obj.idFuncionario = Reader.GetInt32(0);
                    obj.nomeFuncionario = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;


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
        public String Insert(Funcionario c)
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
                cmd.Parameters.AddWithValue("@nomeFuncionario", c.nomeFuncionario);
                cmd.Parameters.AddWithValue("@rg", c.rg);
                cmd.Parameters.AddWithValue("@cpf", c.cpf);
                cmd.Parameters.AddWithValue("@sexo", c.sexo);
                cmd.Parameters.AddWithValue("@salario", c.salario);
                cmd.Parameters.AddWithValue("@telefone", c.telefone);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@uf", c.uf);
                cmd.Parameters.AddWithValue("@cidade", c.cidade);
                cmd.Parameters.AddWithValue("@bairro", c.bairro);
                cmd.Parameters.AddWithValue("@cep", c.cep);
                cmd.Parameters.AddWithValue("@rua", c.rua);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@dataNascimento", c.dataNascimento);
                cmd.Parameters.AddWithValue("@dataAdmissao", c.dataAdmissao);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@cargo_idCargo", c.cargo_idCargo);
                SQL = "INSERT INTO Funcionario (nomeFuncionario, rg, cpf, sexo, salario, telefone, celular, uf, cidade, bairro, cep, rua, numero, dataNascimento, dataAdmissao, dataCadastro, status, cargo_idCargo) VALUES (@nomeFuncionario, @rg, @cpf, @sexo, @salario, @telefone, @celular, @uf, @cidade, @bairro, @cep, @rua, @numero, @dataNascimento, @dataAdmissao, @dataCadastro, @status, @cargo_idCargo)";
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
        public String Update(Funcionario c)
        {
            string result;
            Conexao objCon = new Conexao();
            MySqlConnection con = new MySqlConnection();
            con = objCon.abreConn();
            try
            {
                string sql = "UPDATE funcionario SET nomeFuncionario = @nomeFuncionario, rg = @rg, cpf = @cpf , sexo = @sexo , salario = @salario, telefone = @telefone, celular = @celular, uf = @uf, cidade = @cidade, bairro = @bairro, cep = @cep, rua = @rua, numero = @numero, dataNascimento = @dataNascimento, dataAdmissao = @dataAdmissao, dataCadastro = @dataCadastro, status = @status, cargo_idCargo = @cargo_idCargo WHERE idFuncionario = " + c.idFuncionario;
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nomeFuncionario", c.nomeFuncionario);
                cmd.Parameters.AddWithValue("@rg", c.rg);
                cmd.Parameters.AddWithValue("@cpf", c.cpf);
                cmd.Parameters.AddWithValue("@sexo", c.sexo);
                cmd.Parameters.AddWithValue("@salario", c.salario);
                cmd.Parameters.AddWithValue("@telefone", c.telefone);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@uf", c.uf);
                cmd.Parameters.AddWithValue("@cidade", c.cidade);
                cmd.Parameters.AddWithValue("@bairro", c.bairro);
                cmd.Parameters.AddWithValue("@cep", c.cep);
                cmd.Parameters.AddWithValue("@rua", c.rua);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@dataNascimento", c.dataNascimento);
                cmd.Parameters.AddWithValue("@dataAdmissao", c.dataAdmissao);
                cmd.Parameters.AddWithValue("@dataCadastro", c.dataCadastro);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@cargo_idCargo", c.cargo_idCargo);
                int verify = cmd.ExecuteNonQuery();
                if (verify != -1)
                {
                    result = "Funcionario atualizado com sucesso!";
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
        public Funcionario SelectSpecific(Funcionario funcionario)
        {

            Funcionario obj = new Funcionario();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT funcionario.idFuncionario, funcionario.nomeFuncionario, funcionario.rg, funcionario.cpf, funcionario.sexo, funcionario.salario, funcionario.telefone, funcionario.celular, funcionario.uf, funcionario.cidade, funcionario.bairro, funcionario.cep, funcionario.rua, funcionario.numero, funcionario.dataNascimento, funcionario.dataCadastro, funcionario.dataAdmissao, funcionario.status, funcionario.cargo_idCargo, cargo.nomeCargo FROM Funcionario INNER JOIN cargo ON funcionario.cargo_idCargo = cargo.idCargo WHERE funcionario.idFuncionario = " + funcionario.idFuncionario;
                MySqlDataReader Reader = command.ExecuteReader();


                if (Reader.Read())
                {
                    obj.idFuncionario = Reader.GetInt32(0);
                    obj.nomeFuncionario = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.rg = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.cpf = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : string.Empty;
                    obj.sexo = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty;
                    obj.salario = Reader.GetInt32(5);
                    obj.telefone = (!Reader.IsDBNull(6)) ? Reader.GetString(6) : string.Empty;
                    obj.celular = (!Reader.IsDBNull(7)) ? Reader.GetString(7) : string.Empty;
                    obj.uf = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : string.Empty;
                    obj.cidade = (!Reader.IsDBNull(9)) ? Reader.GetString(9) : string.Empty;
                    obj.bairro = (!Reader.IsDBNull(10)) ? Reader.GetString(10) : string.Empty;
                    obj.cep = (!Reader.IsDBNull(11)) ? Reader.GetString(11) : string.Empty;
                    obj.rua = (!Reader.IsDBNull(12)) ? Reader.GetString(12) : string.Empty;
                    obj.numero = Reader.GetInt32(13);
                    obj.dataNascimento = Reader.GetDateTime(14);
                    obj.dataAdmissao = Reader.GetDateTime(15);
                    obj.dataCadastro = Reader.GetDateTime(16);
                    obj.status = Reader.GetInt32(17);
                    obj.cargo_idCargo = Reader.GetInt32(18);
                    obj.cargo = new Cargo { nomeCargo = (!Reader.IsDBNull(19)) ? Reader.GetString(19) : string.Empty };
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
