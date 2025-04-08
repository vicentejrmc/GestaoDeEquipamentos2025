
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante
{
    public Fabricante[] fabricantes = new Fabricante[100];
    public int contadorFabricantes = 0;


    public void CadastrarFabricante(Fabricante novoFabricante)
    {
        novoFabricante.Id = GeradorIds.GerarIdFabricante();

        fabricantes[contadorFabricantes++] = novoFabricante;
    }

    public bool ExcluirFabricante(int idFabricante)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;
            else if (fabricantes[i].Id == idFabricante)
            {
                fabricantes[i] = null;
                return true;
            }
        }
        return false;
    }

   
    public bool EditarFabricante(int idFabricante, Fabricante fabricanteEditado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;

            else if (fabricantes[i].Id == idFabricante)
            {
                fabricantes[i].Nome = fabricanteEditado.Nome;
                fabricantes[i].Email = fabricanteEditado.Email;
                fabricantes[i].Telefone = fabricanteEditado.Telefone;

                return true;
            }
        }

        return false;
    }

    public Fabricante[] SelecionarFabricantes()
    {
        return fabricantes;
    }

    public Fabricante SelecionarFabricantePorId(int idFabricante)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[i] == null) continue;

            else if (fabricantes[i].Id == idFabricante)
                return fabricantes[i];
        }
        return null;
    }
}