using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class RepositorioChamado
{
    private Chamado[] chamados = new Chamado[100];
    private int contadorChamados  = 0;

    public void CadastrarChamado(Chamado novoChamado)
    {
        novoChamado.Id = GeradorIds.GerarIdChamado();

        chamados[contadorChamados++] = novoChamado;
    }

    public bool EditarChamado(int idChamado, Chamado novoChamado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null)
                continue;

            else if (chamados[i].Id == idChamado)
            {
                chamados[i].Titulo = novoChamado.Titulo;
                chamados[i].Descricao = novoChamado.Descricao;
                chamados[i].Equipamento = novoChamado.Equipamento;

                return true;
            }
        }

        return false;
    }

    public Chamado[] SelecionarChamados()
    {
        return chamados;
    }

    public bool ExcluirChamado(int idChamado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null) continue;

            else if (chamados[i].Id == idChamado)
            {
                chamados[i] = null;

                return true;
            }
        }

        return false;
    }
}


