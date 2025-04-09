using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System.Security.Cryptography.X509Certificates;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante
{
    public int Id;
    public string Nome;
    public string Email;
    public string Telefone;
    public Equipamento[] Equipamentos;

    public Fabricante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Equipamentos = new Equipamento[100];
    }

    public void AdicionarEquipamento(Equipamento equipamento)
    {
        for (int i = 0; i < Equipamentos.Length; i++)
        {
            if (Equipamentos[i] == null)
            {
                Equipamentos[i] = equipamento;
                return;
            }
        }
    }

    public void RemoverEquipamento(Equipamento equipamento)
    {
        for (int i = 0; i < Equipamentos.Length; i++)
        {
            if (Equipamentos[i] == equipamento)
            {
                Equipamentos[i] = null;
                return;
            }
        }
    }

    public int ObterQuantidadeEquipamentos()
    {
        int quantidade = 0;
        for (int i = 0; i < Equipamentos.Length; i++)
        {
            if (Equipamentos[i] != null)
                quantidade++;
        }
        return quantidade;
    }



}
