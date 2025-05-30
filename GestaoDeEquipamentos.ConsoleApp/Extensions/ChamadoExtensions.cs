using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.Extensions
{
    public static class ChamadoExtensions
    {
        public static Chamado ParaEntidade(
       this FormularioChamadoViewModel formularioVM,
       List<Equipamento> equipamentos
   )
        {
            Equipamento equipamentoSelecionado = null;

            foreach (var f in equipamentos)
            {
                if (f.Id == formularioVM.EquipamentoId)
                    equipamentoSelecionado = f;
            }

            return new Chamado(
                formularioVM.Titulo,
                formularioVM.Descricao,
                equipamentoSelecionado
            );
        }

        public static DetalhesChamadoViewModel ParaDetalhesVM(this Chamado chamado)
        {
            return new DetalhesChamadoViewModel(
                chamado.Id,
                chamado.Titulo,
                chamado.Descricao,
                chamado.DataAbertura,
                chamado.TempoDecorrido,
                chamado.Equipamento.Nome
            );
        }
    }
}
