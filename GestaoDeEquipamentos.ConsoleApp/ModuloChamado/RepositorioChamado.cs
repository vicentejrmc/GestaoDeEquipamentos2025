using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class RepositorioChamado : RepositorioBaseEmArquivo<Chamado>, IRepositorioChamado
{
    public RepositorioChamado(ContextoDeDados contexto) : base(contexto)
    {
    }

    protected override List<Chamado> ObterRegistros()
    {
        return contexto.Chamados;
    }
}


