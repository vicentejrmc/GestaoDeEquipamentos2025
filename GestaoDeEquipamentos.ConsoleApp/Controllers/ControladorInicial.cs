using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers
{
    [Route("/")]
    public class ControladorInicial : Controller
    {
        public IActionResult PaginaInicial()
        {
            return View("PaginaInicial");
        }
    }
}
