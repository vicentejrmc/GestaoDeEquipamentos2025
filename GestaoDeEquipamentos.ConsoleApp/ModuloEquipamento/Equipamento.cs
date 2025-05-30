using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase<Equipamento>
{
    public string Nome { get; set; }
    public Fabricante Fabricante { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }

    public List<Chamado> Chamados { get; set; }

    public string NumeroSerie
    {
        get
        {
            string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

            return $"{tresPrimeirosCaracteres}-{Id}";
        }
    }

    public Equipamento()
    {
        Chamados = new List<Chamado>();
    }

    public Equipamento(string nome, decimal precoAquisicao, DateTime dataFabricacao, Fabricante fabricante) : this()
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }

    public void AdicionarChamado(Chamado chamado)
    {
        if (!Chamados.Contains(chamado))
            Chamados.Add(chamado);
    }

    public void RemoverChamado(Chamado chamado)
    {
        if (Chamados.Contains(chamado))
            Chamados.Remove(chamado);
    }

    public override void AtualizarRegistro(Equipamento equipamentoAtualizado)
    {
        Nome = equipamentoAtualizado.Nome;
        DataFabricacao = equipamentoAtualizado.DataFabricacao;
        PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo 'Nome' é obrigatório.\n";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (PrecoAquisicao <= 0)
            erros += "O campo 'Preço de Aquisição' deve ser maior que zero.\n";

        if (DataFabricacao > DateTime.Now)
            erros += "O campo 'Data de Fabricação' deve conter uma data passada.\n";

        return erros;
    }
}
