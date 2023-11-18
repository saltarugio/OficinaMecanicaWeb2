using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using OficinaMecanica.Models;
using OficinaMecanica.Models.BL;
using OficinaMecanica.Models.DAO;
using OficinaMecanica.Models.POJO;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Transactions;

namespace OficinaMecanica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //--------------------------------------------------------------------------

        //----------------------------------Add-------------------------------------
        [HttpGet]
        public IActionResult CadastroCargo()
        {
            CargoDAO cargoDAO = new CargoDAO();
            return View();
        }
        [HttpPost]
        public IActionResult CadastroCargo(Cargo cargo)
        {
            CargoDAO cargoDAO = new CargoDAO();
            Validacao valida = new Validacao();
            if (ModelState.IsValid)
            {
                string retorno = valida.validaCargo(cargo);

                if (retorno == "sucesso")
                {
                    ViewBag.Sucesso = "Cadastro do " + cargo.nomeCargo + " realizado com sucesso!";
                }
                else
                {
                    ViewBag.Erro = retorno;
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult CadastroCategoria()
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            return View();
        }
        [HttpPost]
        public IActionResult CadastroCategoria(Categoria categoria)
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            Validacao valida = new Validacao();
            if (ModelState.IsValid)
            {
                string retorno = valida.validaCategoria(categoria);

                if (retorno == "sucesso")
                {
                    ViewBag.Sucesso = "Cadastro da " + categoria.nomeCategoria + " realizada com sucesso!";
                }
                else
                {
                    ViewBag.Erro = retorno;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CadastroMarca()
        {
            MarcaDAO marcaDAO = new MarcaDAO();
            return View();
        }
        [HttpPost]
        public IActionResult CadastroMarca(Marca marca)
        {
            MarcaDAO marcaDAO = new MarcaDAO();
            Validacao valida = new Validacao();
            if (ModelState.IsValid)
            {
                string retorno = valida.validaMarca(marca);

                if (retorno == "sucesso")
                {
                    ViewBag.Sucesso = "Cadastro da " + marca.nomeMarca + " realizada com sucesso!";
                }
                else
                {
                    ViewBag.Erro = retorno;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CadastroModelo()
        {
            ModeloDAO modeloDAO = new ModeloDAO();
            return View();
        }
        [HttpPost]
        public IActionResult CadastroModelo(Modelo modelo)
        {
            ModeloDAO modeloDAO = new ModeloDAO();
            Validacao valida = new Validacao();
            if (ModelState.IsValid)
            {
                string retorno = valida.validaModelo(modelo);

                if (retorno == "sucesso")
                {
                    ViewBag.Sucesso = "Cadastro do " + modelo.nomeModelo + " realizado com sucesso!";
                }
                else
                {
                    ViewBag.Erro = retorno;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult CadastroClienteCPF()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            return View();
        }
        [HttpPost]
        public IActionResult CadastroClienteCPF(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            Validacao valida = new Validacao();

            string retorno = valida.validaClienteCPF(cliente);

            if (retorno == "sucesso")
            {
                ViewBag.Sucesso = "Cadastro do " + cliente.nomeCliente + " realizado com sucesso!";
            }
            else
            {
                ViewBag.Erro = retorno;
            }

            return View();
        }

        [HttpGet]
        public IActionResult CadastroClienteCNPJ()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            return View();
        }
        [HttpPost]
        public IActionResult CadastroClienteCNPJ(Cliente cliente)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            Validacao valida = new Validacao();

            string retorno = valida.validaClienteCNPJ(cliente);

            if (retorno == "sucesso")
            {
                ViewBag.Sucesso = "Cadastro do " + cliente.nomeCliente + " realizado com sucesso!";
            }
            else
            {
                ViewBag.Erro = retorno;
            }

            return View();
        }

        [HttpGet]
        public IActionResult CadastroFuncionario()
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            var cargos = funcionarioDAO.Busca();
            ViewBag.Cargos = cargos;
            return View();
        }
        [HttpPost]
        public IActionResult CadastroFuncionario(Funcionario funcionario)
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            Validacao valida = new Validacao();
            
            string retorno = valida.validaFuncionario(funcionario);

            if (retorno == "sucesso")
            {
                ViewBag.Sucesso = "Cadastro do " + funcionario.nomeFuncionario + " realizado com sucesso!";
            }
            else
            {
                ViewBag.Erro = retorno;
            }
            
            var cargos = funcionarioDAO.Busca();
            ViewBag.Cargos = cargos;

            return View(funcionario);
        }

        [HttpGet]
        public IActionResult CadastroServico()
        {
            ServicoDAO servicoDAO = new ServicoDAO();
            var categorias = servicoDAO.Busca();
            
            ViewBag.Categorias = categorias;
            return View();
        }
        [HttpPost]
        public IActionResult CadastroServico(Servico servico)
        {
            ServicoDAO servicoDAO = new ServicoDAO();
            Validacao valida = new Validacao();
            CategoriaDAO categoria = new CategoriaDAO();
            try
            {
                string retorno = valida.validaServico(servico);

                if (retorno == "sucesso")
                {
                    ViewBag.Sucesso = "Cadastro do " + servico.nomeServico + " realizado com sucesso!";
                }
                else
                {
                    ViewBag.Erro = retorno;
                }
                var categorias = servicoDAO.Busca();
                ViewBag.Categorias = categorias;
            }
            catch(Exception ex)
            {
                ViewBag.Error = "O correu um erro no cadastro" + ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult CadastroVeiculo()
        {
            VeiculoDAO veiculoDAO = new VeiculoDAO();

            // Chame o método ObterDados() nas respectivas classes DAO para obter os dados
            var (marcas, modelos, clientes) = veiculoDAO.Busca();

            // Coloque os dados obtidos em ViewBag ou ViewModel para passar para a View
            ViewBag.Marcas = marcas;
            ViewBag.Modelos = modelos;
            ViewBag.Clientes = clientes;

            return View();
        }

        [HttpPost]
        public IActionResult CadastroVeiculo(Veiculo veiculo)
        {
            VeiculoDAO veiculoDAO = new VeiculoDAO();
            Validacao valida = new Validacao();

            string retorno = valida.validaVeiculo(veiculo);

            if (retorno == "sucesso")
            {
                ViewBag.Sucesso = "Cadastro da " + veiculo.placa + " realizado com sucesso!";
            }
            else
            {
                ViewBag.Erro = retorno;
            }
            var (marcas, modelos, clientes) = veiculoDAO.Busca();

            // Coloque os dados obtidos em ViewBag ou ViewModel para passar para a View
            ViewBag.Marcas = marcas;
            ViewBag.Modelos = modelos;
            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpGet]
        public IActionResult CadastroOrdemServico()
        {
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();

            
            var (funcionarios, veiculos, clientes, servicos) = ordemServicoDAO.Busca();

            ViewBag.Funcionarios = funcionarios;
            ViewBag.Veiculos= veiculos;
            ViewBag.Clientes = clientes;
            ViewBag.Servicos = servicos;
            return View();
        }

        [HttpPost]
        public IActionResult CadastroOrdemServico(OrdemServico ordemServico, Servico servico)
        {
            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            RealizadoDAO realizadoDAO = new RealizadoDAO();

            var (funcionarios, veiculos, clientes, servicos) = ordemServicoDAO.Busca();

            if (ordemServico != null)
            {
                // Insira a Ordem de Serviço no banco de dados
                string retorno = ordemServicoDAO.Insert(ordemServico);

                // Agora, para cada Serviço selecionado, crie um objeto Realizado e insira no banco de dados

                //Realizado realizado = new Realizado
                //{
                    //ordemServico_idOrdemServico = ordemServico.idOrdemServico,
                    //servico_idServico = servico.idServico
                //};

                // Insira o objeto Realizado no banco de dados
                //string retornoRealizado = realizadoDAO.Insert(realizado);
            }
            ViewBag.Funcionarios = funcionarios;
            ViewBag.Veiculos = veiculos;
            ViewBag.Clientes = clientes;
            ViewBag.Servicos = servicos;

            return View(ordemServico);
        }
        //--------------------------------------------------------------------------

        //----------------------------------Updates---------------------------------
        [HttpGet]
        public IActionResult EditarCargo(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            CargoDAO cargoDAO = new CargoDAO();
            Cargo cargo = new Cargo();
            cargo.idCargo = int.Parse(id);
            cargo = cargoDAO.SelectSpecific(cargo);
            return View(cargo);
        }
        [HttpPost]
        public IActionResult EditarCargo(Cargo cargo)
        {
            CargoDAO cargoDAO = new CargoDAO();
            string retorno = cargoDAO.Update(cargo);
            return View(cargo);
        }

        [HttpGet]
        public IActionResult EditarCategoria(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            Categoria categoria = new Categoria();
            categoria.idCategoria = int.Parse(id);
            categoria = categoriaDAO.SelectSpecific(categoria);
            return View(categoria);
        }
        [HttpPost]
        public IActionResult EditarCategoria(Categoria categoria)
        {

            CategoriaDAO categoriaDAO = new CategoriaDAO();
            string retorno = categoriaDAO.Update(categoria);

            ViewBag.resultado = retorno;
            return View(categoria);
        }

        [HttpGet]
        public IActionResult EditarClienteCPF(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            ClienteDAO clienteDAO = new ClienteDAO();
            Cliente cliente = new Cliente();
            cliente.idCliente = int.Parse(id);
            cliente = clienteDAO.SelectSpecific(cliente);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult EditarClienteCPF(Cliente cliente)
        {

            ClienteDAO clienteDAO = new ClienteDAO();
            string retorno = clienteDAO.Update(cliente);

            ViewBag.resultado = retorno;
            return View(cliente);
        }

        [HttpGet]
        public IActionResult EditarClienteCNPJ(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            ClienteDAO clienteDAO = new ClienteDAO();
            Cliente cliente = new Cliente();
            cliente.idCliente = int.Parse(id);
            cliente = clienteDAO.SelectSpecific(cliente);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult EditarClienteCNPJ(Cliente cliente)
        {

            ClienteDAO clienteDAO = new ClienteDAO();
            string retorno = clienteDAO.Update(cliente);

            ViewBag.resultado = retorno;
            return View(cliente);
        }

        [HttpGet]
        public IActionResult EditarFuncionario(string? id)
        {
            if (id == null)
            {
                id = "0";
            }

            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            CargoDAO cargoDAO = new CargoDAO();
            Funcionario funcionario = new Funcionario();
            funcionario.idFuncionario = int.Parse(id);
            funcionario = funcionarioDAO.SelectSpecific(funcionario);

            var test = funcionarioDAO.Busca();
            ViewBag.Cargos = test;
            return View(funcionario);
        }
        [HttpPost]
        public IActionResult EditarFuncionario(Funcionario funcionario)
        {

            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            CargoDAO cargoDAO = new CargoDAO();  
            string retorno = funcionarioDAO.Update(funcionario);
            var test = funcionarioDAO.Busca();
            ViewBag.Cargos = test;
            return View(funcionario);
        }

        [HttpGet]
        public IActionResult EditarMarca(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            MarcaDAO marcaDAO = new MarcaDAO();
            Marca marca = new Marca();
            marca.idMarca = int.Parse(id);
            marca = marcaDAO.SelectSpecific(marca);
            return View(marca);
        }
        [HttpPost]
        public IActionResult EditarMarca(Marca marca)
        {

            MarcaDAO marcaDAO = new MarcaDAO();
            string retorno = marcaDAO.Update(marca);

            ViewBag.resultado = retorno;
            return View(marca);
        }

        [HttpGet]
        public IActionResult EditarModelo(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            ModeloDAO modeloDAO = new ModeloDAO();
            Modelo modelo = new Modelo();
            modelo.idModelo = int.Parse(id);
            modelo = modeloDAO.SelectSpecific(modelo);
            return View(modelo);
        }
        [HttpPost]
        public IActionResult EditarModelo(Modelo modelo)
        {

            ModeloDAO modeloDAO = new ModeloDAO();
            string retorno = modeloDAO.Update(modelo);

            ViewBag.resultado = retorno;
            return View(modelo);
        }

        [HttpGet]
        public IActionResult EditarOrdemServico(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            OrdemServico ordemServ = new OrdemServico();
            ordemServ.idOrdemServico = int.Parse(id);
            ordemServ = ordemServicoDAO.SelectSpecific(ordemServ);

            var (funcionarios, veiculos, clientes, servicos) = ordemServicoDAO.Busca();

            ViewBag.Funcionarios = funcionarios;
            ViewBag.Veiculos = veiculos;
            ViewBag.Clientes = clientes;
            ViewBag.Servicos = servicos;
            return View(ordemServ);
        }
        [HttpPost]
        public IActionResult EditarOrdemServico(OrdemServico ordemServico)
        {

            OrdemServicoDAO ordemServicoDAO = new OrdemServicoDAO();
            string retorno = ordemServicoDAO.Update(ordemServico);

            var (funcionarios, veiculos, clientes, servicos) = ordemServicoDAO.Busca();

            ViewBag.Funcionarios = funcionarios;
            ViewBag.Veiculos = veiculos;
            ViewBag.Clientes = clientes;
            ViewBag.Servicos = servicos;
            return View(ordemServico);
        }

        [HttpGet]
        public IActionResult EditarServico(string? id)
        {

            if (id == null)
            {
                id = "0";
            }

            ServicoDAO servicoDAO = new ServicoDAO();
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            Servico serv = new Servico();
            serv.idServico= int.Parse(id);
            serv = servicoDAO.SelectSpecific(serv);
            serv.categorias = categoriaDAO.SelectObject();
            var ser = servicoDAO.Busca();
            ViewBag.Categorias = ser;
            return View(serv);
        }
        [HttpPost]
        public IActionResult EditarServico(Servico servico)
        {
            ServicoDAO servicoDAO = new ServicoDAO();
            CategoriaDAO categoriaDAO = new CategoriaDAO();

            string retorno = servicoDAO.Update(servico);
            var ser = servicoDAO.Busca();
            ViewBag.Categorias = ser;
            return View(servico);
        }

        [HttpGet]
        public IActionResult EditarVeiculo(string? id)
        {

            if (id == null)
            {
                id = "0";
            }
            VeiculoDAO veiculoDAO = new VeiculoDAO();
            MarcaDAO marcaDAO = new MarcaDAO();
            ModeloDAO modeloDAO = new ModeloDAO();
            ClienteDAO clienteDAO = new ClienteDAO();
            Veiculo veiculo = veiculoDAO.SelectSpecific(new Veiculo { idVeiculo = int.Parse(id) });
            veiculo.marcas = marcaDAO.SelectObject();
            veiculo.modelos = modeloDAO.SelectObject();
            veiculo.clientes = clienteDAO.SelectObject();
            
            ViewBag.Marcas = veiculo.marcas;
            ViewBag.Modelos = veiculo.modelos;
            ViewBag.Clientes = veiculo.clientes;
            return View(veiculo);
        }
        [HttpPost]
        public IActionResult Editarveiculo(Veiculo veiculo)
        {

            VeiculoDAO veiculoDAO = new VeiculoDAO();
            string retorno = veiculoDAO.Update(veiculo);
            var (mar, mod, cli) = veiculoDAO.Busca();
            ViewBag.Marcas = mar;
            ViewBag.Modelos = mod;
            ViewBag.Clientes = cli;
            return RedirectToAction("Visualizacao");
        }
        //--------------------------------------------------------------------------
        //---------------------------------Detalhes---------------------------------
        public IActionResult DetalheCargo(string? id) { 
            CargoDAO cargoDAO = new CargoDAO();
            Cargo cargo = cargoDAO.SelectSpecific(new Cargo { idCargo = int.Parse(id) });
            
            ViewBag.Cargo = cargo;
            return View(cargo); 
        }
        public IActionResult DetalheCategoria(string? id) {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            Categoria categoria = categoriaDAO.SelectSpecific(new Categoria { idCategoria = int.Parse(id) });
            
            ViewBag.Categoria  = categoria;
            return View(categoria); 
        }
        public IActionResult DetalheClienteCPF(string? id) { 
            ClienteDAO clienteDAO = new ClienteDAO();
            Cliente cliente = clienteDAO.SelectSpecific(new Cliente { idCliente= int.Parse(id) });
            
            ViewBag.Cliente= cliente;
            return View(cliente); 
        }
        public IActionResult DetalheClienteCNPJ(string? id) {
            ClienteDAO clienteDAO = new ClienteDAO();
            Cliente cliente = clienteDAO.SelectSpecific(new Cliente { idCliente = int.Parse(id) });

            ViewBag.Cliente = cliente;
            return View(cliente);
        }
        public IActionResult DetalheFuncionario(string? id) { 
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            Funcionario funcionario = funcionarioDAO.SelectSpecific(new Funcionario{ idFuncionario = int.Parse(id) });
            
            ViewBag.Funcionario = funcionario;
            return View(funcionario); 
        }
        public IActionResult DetalheMarca(string? id) { 
            MarcaDAO marcaDAO = new MarcaDAO();
            Marca marca= marcaDAO.SelectSpecific(new Marca { idMarca = int.Parse(id) });
            
            ViewBag.Marca = marca;
            return View(marca); 
        }
        public IActionResult DetalheModelo(string? id) { 
            ModeloDAO modeloDAO = new ModeloDAO();
            Modelo modelo = modeloDAO.SelectSpecific(new Modelo{ idModelo= int.Parse(id) });
            
            ViewBag.Modelo = modelo;
            return View(modelo); 
        }
        public IActionResult DetalheOrdemServico(string? id) { 
            OrdemServicoDAO ordemServicoDAO= new OrdemServicoDAO();
            OrdemServico ordemServico = ordemServicoDAO.SelectSpecific(new OrdemServico { idOrdemServico = int.Parse(id) });
            
            ViewBag.OrdemServico = ordemServico;
            return View(ordemServico); 
        }
        public IActionResult DetalheServico(string? id) {
            ServicoDAO servicoDAO = new ServicoDAO();
            Servico servico = servicoDAO.SelectSpecific(new Servico { idServico = int.Parse(id) });
            
            ViewBag.Servico = servico;
            return View(servico); 
        }
        public IActionResult DetalheVeiculo(string? id) { 
            VeiculoDAO veiculoDAO = new VeiculoDAO();
            Veiculo veiculo = veiculoDAO.SelectSpecific(new Veiculo{ idVeiculo= int.Parse(id) });
            var (mar, mod, cli) = veiculoDAO.Busca();
            ViewBag.Marcas = mar;
            ViewBag.Modelos = mod;
            ViewBag.Clientes = cli;
            ViewBag.Veiculo= veiculo;
            return View(veiculo); 
        }
        //--------------------------------------------------------------------------
        //----------------------------------Deletes---------------------------------

        public IActionResult ApagarCar(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteCar(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarCat(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteCat(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarCli(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteCli(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarFun(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteFun(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarMar(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteMar(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarMod(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteMod(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarOrS(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteOrS(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarSer(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteSer(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult ApagarVei(int id)
        {
            DeleteDAO del = new DeleteDAO();
            del.DeleteVei(id);
            return RedirectToAction("Visualizacao");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        //--------------------------------------------------------------------------

        //-------------------------------Visualização-------------------------------
        [HttpGet]
        public IActionResult Visualizacao()
        {
            VisualizacaoDAO visualiza = new VisualizacaoDAO();
            ViewBag.Funcionarios = visualiza.buscaFun();
            ViewBag.ClientesCpf = visualiza.buscaCliCPF();
            ViewBag.ClientesCnpj = visualiza.buscaCliCNPJ();
            ViewBag.Marcas = visualiza.buscaMar();
            ViewBag.Modelos = visualiza.buscaMod();
            ViewBag.Servicos = visualiza.buscaSer();
            ViewBag.OrdemServicos = visualiza.buscaOrS();
            ViewBag.Cargos = visualiza.buscaCar();
            ViewBag.Veiculos = visualiza.buscaVei();
            ViewBag.Categorias = visualiza.buscaCat();
            return View(visualiza);
        }
        [HttpPost]
        public IActionResult Visualizacao(int op)
        {
            VisualizacaoDAO visualiza = new VisualizacaoDAO();
            if(op == 0) {
            }
            else if(op == 1) {
                ViewBag.Funcionarios = visualiza.buscaFun(); 
            }
            else if(op == 2){
                ViewBag.ClientesCpf = visualiza.buscaCliCPF();
            }
            else if(op == 3){
                ViewBag.ClientesCnpj = visualiza.buscaCliCNPJ();
            }
            else if (op == 5){
                ViewBag.Marcas = visualiza.buscaMar();
            }
            else if(op == 6){
            ViewBag.Modelos = visualiza.buscaMod();
            }
            else if(op == 9) {
                ViewBag.Servicos = visualiza.buscaSer();
            }
            else if(op == 8){
                ViewBag.OrdemServicos = visualiza.buscaOrS();
            }
            else if(op == 4){
                ViewBag.Cargos = visualiza.buscaCar();
            }
            else if(op == 10){
                ViewBag.Veiculos = visualiza.buscaVei();
            }
            else if (op == 7){
                ViewBag.Categorias = visualiza.buscaCat();
            }
            return View(op);
        }
        //--------------------------------------------------------------------------

        //--------------------------------Relatórios--------------------------------
        public IActionResult Relatorio()
        {
            RelatorioDAO relatorio = new RelatorioDAO();

            ViewBag.Quantidade = relatorio.QuantidadeQrS();
            ViewBag.Quantidades = relatorio.QuantidadeVei();
            ViewBag.CalculaValor = relatorio.CalcularValorPorData();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 