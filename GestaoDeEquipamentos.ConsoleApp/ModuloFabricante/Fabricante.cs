using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System.Net.Mail;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante : EntidadeBase<Fabricante>
{

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public List<Equipamento> Equipamentos { get; set; }
    public int QuantidadeEquipamentos
    {
        get
        {
            return Equipamentos.Count;
        }
    }

    public Fabricante()
    {
        Equipamentos = new List<Equipamento>();
    }

    public Fabricante(string nome, string email, string telefone) : this()
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Email))
            erros += "O campo 'Email' é obrigatório.\n";

        if (!MailAddress.TryCreate(Email, out _))
            erros += "O campo 'Email' deve estar em um formato válido.\n";

        if (string.IsNullOrWhiteSpace(Telefone))
            erros += "O campo 'Telefone' é obrigatório.\n";

        if (Telefone.Length < 12)
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

        return erros;
    }


    public void AdicionarEquipamento(Equipamento equipamento)
    {
        if (!Equipamentos.Contains(equipamento))
            Equipamentos.Add(equipamento);
    }

    public void RemoverEquipamento(Equipamento equipamento)
    {
        if (Equipamentos.Contains(equipamento))
            Equipamentos.Remove(equipamento);
    }

    public override void AtualizarRegistro(Fabricante fabricanteEditado)
    {
        Nome = fabricanteEditado.Nome;
        Email = fabricanteEditado.Email;
        Telefone = fabricanteEditado.Telefone;
    }

}
