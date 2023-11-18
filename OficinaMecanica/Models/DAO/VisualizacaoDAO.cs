using MySql.Data.MySqlClient;
using OficinaMecanica.Models.POJO;

namespace OficinaMecanica.Models.DAO
{
    public class VisualizacaoDAO
    { 
        public List<Funcionario> buscaFun()
        {
            List<Funcionario> listObj = new List<Funcionario>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT funcionario.idFuncionario, funcionario.nomeFuncionario, funcionario.cpf, funcionario.sexo, funcionario.salario, funcionario.celular, funcionario.dataAdmissao, funcionario.status, cargo.nomeCargo FROM funcionario INNER JOIN cargo ON funcionario.cargo_idCargo = cargo.idCargo";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Funcionario obj = new Funcionario();
                    obj.idFuncionario = Reader.GetInt32(0);
                    obj.nomeFuncionario = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.cpf = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.sexo = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : string.Empty;
                    obj.salario = Reader.GetInt32(4);
                    obj.celular = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : string.Empty;
                    obj.dataAdmissao = Reader.GetDateTime(6);
                    obj.status = Reader.GetInt32(7);
                    obj.cargo = new Cargo() { nomeCargo = (!Reader.IsDBNull(8)) ? Reader.GetString(8) : string.Empty };

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
        public List<Cliente> buscaCliCPF()
        {
            List<Cliente> listObj = new List<Cliente>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCliente, nomeCliente, cpf, sexo, email, celular, status FROM cliente";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cliente obj = new Cliente();
                    obj.idCliente = Reader.GetInt32(0);
                    obj.nomeCliente = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.cpf = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.sexo = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : string.Empty;
                    obj.email = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty;
                    obj.celular = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : string.Empty;
                    obj.status = Reader.GetInt32(6);

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
        public List<Cliente> buscaCliCNPJ()
        {
            List<Cliente> listObj = new List<Cliente>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCliente, nomeCliente, cnpj, sexo, email, celular, status FROM cliente";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cliente obj = new Cliente();
                    obj.idCliente = Reader.GetInt32(0);
                    obj.nomeCliente = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.cnpj = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.sexo = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : string.Empty;
                    obj.email = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty;
                    obj.celular = (!Reader.IsDBNull(5)) ? Reader.GetString(5) : string.Empty;
                    obj.status = Reader.GetInt32(6);

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

        public List<Cargo> buscaCar()
        {
            List<Cargo> listObj = new List<Cargo>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCargo, nomeCargo, dataCadastro, status FROM cargo";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Cargo obj = new Cargo();
                    obj.idCargo = Reader.GetInt32(0);
                    obj.nomeCargo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.dataCadastro = Reader.GetDateTime(2);
                    obj.status = Reader.GetInt32(3);

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

        public List<Categoria> buscaCat()
        {
            List<Categoria> listObj = new List<Categoria>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idCategoria, nomeCategoria, status FROM categoria";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Categoria obj = new Categoria();
                    obj.idCategoria = Reader.GetInt32(0);
                    obj.nomeCategoria = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.status = Reader.GetInt32(2);


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
        public List<Modelo> buscaMod()
        {
            List<Modelo> listObj = new List<Modelo>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idModelo, nomeModelo, status FROM modelo";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Modelo obj = new Modelo();
                    obj.idModelo = Reader.GetInt32(0);
                    obj.nomeModelo = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.status = Reader.GetInt32(2);


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
        public List<Marca> buscaMar()
        {
            List<Marca> listObj = new List<Marca>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT idMarca, nomeMarca, status FROM marca";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Marca obj = new Marca();
                    obj.idMarca = Reader.GetInt32(0);
                    obj.nomeMarca = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.status = Reader.GetInt32(2);

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
        public List<Veiculo> buscaVei()
        {
            List<Veiculo> listObj = new List<Veiculo>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT veiculo.idVeiculo, veiculo.ano, veiculo.placa, veiculo.status, marca.nomeMarca, modelo.nomeModelo, cliente.nomeCliente FROM veiculo INNER JOIN marca ON veiculo.marca_idMarca = marca.idMarca INNER JOIN modelo ON veiculo.modelo_idModelo = modelo.idModelo INNER JOIN cliente ON veiculo.cliente_idCliente = cliente.idCliente";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Veiculo obj = new Veiculo();
                    obj.idVeiculo = Reader.GetInt32(0);
                    obj.ano = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.placa = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty;
                    obj.status = Reader.GetInt32(3);
                    obj.marca = new Marca() { nomeMarca = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty };
                    obj.modelo = new Modelo() { nomeModelo= (!Reader.IsDBNull(5)) ? Reader.GetString(5) : string.Empty };
                    obj.cliente = new Cliente() { nomeCliente = (!Reader.IsDBNull(6)) ? Reader.GetString(6) : string.Empty };


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
        public List<Servico> buscaSer()
        {
            List<Servico> listObj = new List<Servico>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT servico.idServico, servico.nomeServico, servico.preco, servico.status, categoria.nomeCategoria FROM servico INNER JOIN categoria ON servico.categoria_idCategoria = categoria.idCategoria";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    Servico obj = new Servico();
                    obj.idServico = Reader.GetInt32(0);
                    obj.nomeServico = (!Reader.IsDBNull(1)) ? Reader.GetString(1) : string.Empty;
                    obj.preco = Reader.GetInt32(2);
                    obj.status = Reader.GetInt32(3);
                    obj.categoria = new Categoria() { nomeCategoria = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty };

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
        public List<OrdemServico> buscaOrS()
        {
            List<OrdemServico> listObj = new List<OrdemServico>();
            try
            {
                //----------------------------Mysql Connection-----
                Conexao objCon = new Conexao();
                MySqlConnection Conn = new MySqlConnection();
                Conn = objCon.abreConn();
                MySqlCommand command = Conn.CreateCommand();
                command.CommandText = "SELECT ordemservico.idOrdemServico, ordemservico.data, funcionario.nomefuncionario, veiculo.placa, cliente.nomeCliente FROM ordemservico INNER JOIN funcionario ON ordemservico.funcionario_idFuncionario = funcionario.idFuncionario INNER JOIN veiculo ON ordemservico.veiculo_idVeiculo = veiculo.idVeiculo INNER JOIN cliente ON ordemservico.cliente_idCliente = cliente.idCliente";
                MySqlDataReader Reader = command.ExecuteReader();

                while (Reader.Read())
                {
                    OrdemServico obj = new OrdemServico();
                    obj.idOrdemServico = Reader.GetInt32(0);
                    obj.data = Reader.GetDateTime(1);
                    obj.funcionario = new Funcionario() { nomeFuncionario = (!Reader.IsDBNull(2)) ? Reader.GetString(2) : string.Empty };
                    obj.veiculo = new Veiculo() { placa = (!Reader.IsDBNull(3)) ? Reader.GetString(3) : string.Empty };
                    obj.cliente = new Cliente() { nomeCliente = (!Reader.IsDBNull(4)) ? Reader.GetString(4) : string.Empty };

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
    }
}
