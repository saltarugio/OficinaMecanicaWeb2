using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using OficinaMecanica.Models.DAO;
using OficinaMecanica.Models.POJO;
using System;
using System.Collections.Generic;

namespace OficinaMecanica.Models.BL
{
    public class Validacao
    {
        CargoDAO cargoDAO = new CargoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        ClienteDAO clienteDAO = new ClienteDAO();
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        MarcaDAO marcaDAO = new MarcaDAO();
        ModeloDAO modeloDAO = new ModeloDAO();
        OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
        ServicoDAO servicoDAO = new ServicoDAO();
        VeiculoDAO veiculoDAO = new VeiculoDAO();
        public string validaCargo(Cargo cargo)
        {
            var todos = cargoDAO.SelectObject();

            if (todos.Any(u => u.nomeCargo == cargo.nomeCargo))
            {
                return cargo.nomeCargo + " já cadastrado!";
            }
            else
            {
                cargoDAO.Insert(cargo);
                return "sucesso";
            }
        }
        public string validaCategoria(Categoria categoria)
        {
            var todos = categoriaDAO.SelectObject();

            if (todos.Any(u => u.nomeCategoria == categoria.nomeCategoria))
            {
                return categoria.nomeCategoria + " já cadastrado!";
            }
            else
            {
                categoriaDAO.Insert(categoria);
                return "sucesso";
            }
        }
        public string validaClienteCPF(Cliente cliente)
        {
            var todos = clienteDAO.SelectObject();

            if (todos.Any(u => u.cpf == cliente.cpf))
            {
                return cliente.nomeCliente + " já cadastrado!";
            }
            else
            {
                clienteDAO.Insert(cliente);
                return "sucesso";
            }
        }
        public string validaClienteCNPJ(Cliente cliente)
        {
            var todos = clienteDAO.SelectObject();

            if (todos.Any(u => u.cnpj == cliente.cnpj))
            {
                return cliente.nomeCliente + " já cadastrado!";
            }
            else
            {
                clienteDAO.Insert(cliente);
                return "sucesso";
            }
        }
        public string validaFuncionario(Funcionario funcionario)
        {
            var todos = funcionarioDAO.SelectObject();

            if (todos.Any(u => u.cpf == funcionario.cpf))
            {
                return funcionario.nomeFuncionario + " já cadastrado!";
            }
            else
            {
                funcionarioDAO.Insert(funcionario);
                return "sucesso";
            }
        }
        public string validaMarca(Marca marca)
        {
            var todos = marcaDAO.SelectObject();

            if (todos.Any(u => u.nomeMarca == marca.nomeMarca))
            {
                return marca.nomeMarca+ " já cadastrado!";
            }
            else
            {
                marcaDAO.Insert(marca);
                return "sucesso";
            }
        }
        public string validaModelo(Modelo modelo)
        {
            var todos = modeloDAO.SelectObject();

            if (todos.Any(u => u.nomeModelo == modelo.nomeModelo))
            {
                return modelo.nomeModelo + " já cadastrado!";
            }
            else
            {
                modeloDAO.Insert(modelo);
                return "sucesso";
            }
        }
        public string validaServico(Servico servico)
        {
            var todos = servicoDAO.SelectObject();

            if (todos.Any(u => u.nomeServico == servico.nomeServico))
            {
                return servico.nomeServico + " já cadastrado!";
            }
            else
            {
                servicoDAO.Insert(servico);
                return "sucesso";
            }
        }
        public string validaVeiculo(Veiculo veiculo)
        {
            var todos = veiculoDAO.SelectObject();

            if (todos.Any(u => u.placa == veiculo.placa))
            {
                return veiculo.placa + " já cadastrado!";
            }
            else
            {
                veiculoDAO.Insert(veiculo);
                return "sucesso";
            }
        }

    }
}
