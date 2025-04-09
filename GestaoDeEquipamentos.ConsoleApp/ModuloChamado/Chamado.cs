using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado
{
    public int Id;
    public string Titulo;
    public string Descricao;
    public Equipamento Equipamento;
    public DateTime DataAbertura;

    public Chamado(string titulo, string descricao, Equipamento equipamento)
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = DateTime.Now;
    }

    public int ObterTempoDecorrido()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);

        return diferencaTempo.Days;
    }

    public string Validar()
    {
        string erros = "";
        if (string.IsNullOrWhiteSpace(Titulo) && Titulo.Length < 3)
            erros += "O campo Título é obrigatório e deve ter no mínimo 3 caracteres.\n";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo Descrição é obrigatório.\n";

        if (Descricao.Length < 10)
            erros += "O campo Descrição deve ter no mínimo 10 caracteres.\n";

        if (Equipamento == null)
            erros += "O campo Equipamento é obrigatório.\n";

        return erros;
    }

}
