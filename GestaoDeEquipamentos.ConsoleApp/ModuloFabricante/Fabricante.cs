using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante
{
    public int Id;
    public string Nome;
    public string Email;
    public string Telefone;
    public Equipamento[] Equipamentos;

    public string Validar()
    {
        string erros = "";

        if(string.IsNullOrWhiteSpace(Nome)) // string.IsNullOrWhiteSpace() verifica se a string é nula ou vazia
            erros += "O campo Nome é obrigatório.\n";

        if(Nome.Length < 3) // verifica se o nome tem menos de 3 caracteres
            erros += "O campo Nome deve ter no mínimo 3 caracteres.\n";

        if(string.IsNullOrWhiteSpace(Email)) // verifica se o email é nulo ou vazio
            erros += "O campo E-mail é obrigatório.\n";

         if (!MailAddress.TryCreate(Email, out _)); // _ (underline) é um placeholder(palavraChave) para ignorar o valor retornado(descarte)
        erros += "O campo E-mail deve ser um e-mail válido.\n";

        if (string.IsNullOrWhiteSpace(Telefone)) // verifica se o telefone é nulo ou vazio
            erros += "O campo Telefone é obrigatório.\n";

        if (Telefone.Length < 11) // verifica se o telefone tem menos de 10 caracteres
            erros += "O campo Telefone deve seguir o formato 00 0000-0000.\n";

        return erros;
    }


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
