using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Extensions;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers
{
    [Route("fabricantes")]
    public class ControladorFabricante : Controller
    {
        [HttpGet("cadastrar")]
        public IActionResult ExibirFormularioCadastroFabricante()
        {
            CadastrarFabricanteViewModel cadastrarVM = new CadastrarFabricanteViewModel();

            return View("Cadastrar", cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarFabricante(CadastrarFabricanteViewModel cadastrarVM)
        {
            ContextoDeDados contextoDados = new ContextoDeDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

            Fabricante novoFabricante = cadastrarVM.ParaEntidade();

            repositorioFabricante.CadastrarRegistro(novoFabricante);

            NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
                "Fabricante Cadastrado!",
                $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso!"
            );

            return View("Notificacao", notificacaoVM);
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult ExibirFormularioEdicaoFabricante([FromRoute] int id)
        {
            ContextoDeDados contextoDados = new ContextoDeDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

            Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

            EditarFabricanteViewModel editarVM = new EditarFabricanteViewModel(
                id,
                fabricanteSelecionado.Nome,
                fabricanteSelecionado.Email,
                fabricanteSelecionado.Telefone
            );

            return View("Editar", editarVM);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult EditarFabricante([FromRoute] int id, EditarFabricanteViewModel editarVM)
        {
            ContextoDeDados contextoDados = new ContextoDeDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

            Fabricante fabricanteEditado = editarVM.ParaEntidade();

            repositorioFabricante.EditarRegistro(id, fabricanteEditado);

            NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
                "Fabricante Editado!",
                $"O registro \"{fabricanteEditado.Nome}\" foi editado com sucesso!"
            );

            return View("Notificacao", notificacaoVM);
        }

        [HttpGet("excluir/{id:int}")]
        public IActionResult ExibirFormularioExclusaoFabricante([FromRoute] int id)
        {
            ContextoDeDados contextoDados = new ContextoDeDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

            Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

            ExcluirFabricanteViewModel excluirVM = new ExcluirFabricanteViewModel(
                fabricanteSelecionado.Id,
                fabricanteSelecionado.Nome
            );

            return View("Excluir", excluirVM);
        }

        [HttpPost("excluir/{id:int}")]
        public IActionResult ExcluirFabricante([FromRoute] int id)
        {
            ContextoDeDados contextoDados = new ContextoDeDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

            repositorioFabricante.ExcluirRegistro(id);

            NotificacaoViewModel notificacaoVM = new NotificacaoViewModel(
                "Fabricante Excluído!",
                "O registro foi excluído com sucesso!"
            );

            return View("Notificacao", notificacaoVM);
        }

        [HttpGet("visualizar")]
        public IActionResult VisualizarFabricantes()
        {
            ContextoDeDados contextoDados = new ContextoDeDados(true);
            IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

            VisualizarFabricantesViewModel visualizarVM = new VisualizarFabricantesViewModel(fabricantes);

            return View("Visualizar", visualizarVM);
        }
    }
}
