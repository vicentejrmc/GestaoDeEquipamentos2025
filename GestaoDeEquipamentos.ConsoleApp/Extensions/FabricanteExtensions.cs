using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Extensions
{
    public static class FabricanteExtensions
    {
        public static Fabricante ParaEntidade(this FormularioFabricanteViewModel formularioVM)
        {
            return new Fabricante(formularioVM.Nome, formularioVM.Email, formularioVM.Telefone);
        }

        public static DetalhesFabricanteViewModel ParaDetalhesVM(this Fabricante fabricante)
        {
            return new DetalhesFabricanteViewModel(
                    fabricante.Id,
                    fabricante.Nome,
                    fabricante.Email,
                    fabricante.Telefone
            );
        }
    }
}
