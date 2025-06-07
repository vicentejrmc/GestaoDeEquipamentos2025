using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers
{
    [Route("/")]
    public class ControladorInicial : Controller
    {
        private ContextoDeDados contextoDados;
        private IRepositorioEquipamento repositorioEquipamento;
        private IRepositorioFabricante repositorioFabricante;

        public ControladorInicial()
        {
            contextoDados = new ContextoDeDados(true);
            repositorioEquipamento = new RepositorioEquipamento(contextoDados);
            repositorioFabricante = new RepositorioFabricante(contextoDados);
        }

        public IActionResult PaginaInicial()
        {
            var equipamentos = repositorioEquipamento.SelecionarRegistros();

            var equipamentosVM = new VisualizarEquipamentosViewModel(equipamentos);

            ViewBag.Equipamentos = equipamentosVM.Registros;

            var fabricantes = repositorioFabricante.SelecionarRegistros();

            var fabricantesVM = new VisualizarFabricantesViewModel(fabricantes);

            ViewBag.Fabricantes = fabricantesVM.Registros;

            return View();
        }
    }
}
