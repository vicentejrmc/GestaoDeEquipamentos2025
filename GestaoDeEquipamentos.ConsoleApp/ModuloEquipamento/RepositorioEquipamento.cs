using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamento : RepositorioBaseEmArquivo<Equipamento>, IRepositorioEquipamento
{
    public RepositorioEquipamento(ContextoDeDados contexto) : base(contexto)
    {
    }

    protected override List<Equipamento> ObterRegistros()
    {
        return contexto.Equipamentos;
    }
}
