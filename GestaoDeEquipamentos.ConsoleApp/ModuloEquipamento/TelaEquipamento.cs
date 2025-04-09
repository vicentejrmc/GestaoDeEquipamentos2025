using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System.ComponentModel.Design;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(RepositorioEquipamento repositorioEquipamento, RepositorioFabricante repositorioFabricante)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioFabricante = repositorioFabricante;
    }

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("--------------------------------------------\n");
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("2 - Edição de Equipamento");
        Console.WriteLine("3 - Exclusão de Equipamento");
        Console.WriteLine("4 - Visualização de Equipamentos");
        Console.WriteLine("S - Voltar");
        Console.WriteLine("--------------------------------------------\n");

        Console.Write("Digite um opção válida: ");
        char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

        return opcaoEscolhida;
    }

    public void CadastrarEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Equipamento...");
        Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Equipamento novoEquipamento = ObterDadosEquipamento();

        string erros = novoEquipamento.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);

            CadastrarEquipamento(); 

            return;
        }

        Fabricante fabricante = novoEquipamento.Fabricante;

        fabricante.AdicionarEquipamento(novoEquipamento);

        repositorioEquipamento.CadastrarEquipamento(novoEquipamento);

        Notificador.ExibirMensagem("Registro Concuido com sucesso!", ConsoleColor.Green);

    }

    public void EditarEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine("|         Editando Equipamento...          |");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamenteAntigo = repositorioEquipamento.SelecionarEquipamentoPorId(idSelecionado);
        Fabricante fabricanteAntigo = equipamenteAntigo.Fabricante;

        Console.WriteLine();

        Equipamento equipamentoEditado = ObterDadosEquipamento();
        Fabricante fabricanteEditado = equipamentoEditado.Fabricante;

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, equipamentoEditado);

        if(!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição do resgistro!", ConsoleColor.Red);
            return;
        }

        if(fabricanteAntigo != fabricanteEditado)
        {
            fabricanteAntigo.RemoverEquipamento(equipamenteAntigo);
            fabricanteEditado.AdicionarEquipamento(equipamentoEditado);
        }

        Notificador.ExibirMensagem("O equipamento foi editado com sucesso!", ConsoleColor.Green);
    }

    public void ExcluirEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Equipamento...");
        Console.WriteLine("--------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O equipamento foi excluído com sucesso!");
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();
            
            Console.WriteLine("Visualizando Equipamentos...");
            Console.WriteLine("--------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento e = equipamentosCadastrados[i];

            if (e == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                e.Id, e.Nome, e.ObterNumeroSerie(), e.Fabricante.Nome, e.PrecoAquisicao.ToString("C2"), e.DataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();
    }

    public Equipamento ObterDadosEquipamento()
    {
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço de aquisição R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (dd/MM/yyyy) ");
        string dataFabString = Console.ReadLine();

        ValidarDataFabricacao(Convert.ToDateTime(dataFabString));
        DateTime dataFabricacao = Convert.ToDateTime(dataFabString);

        VisualizarFabricantes();

        Console.Write("Selecione o registro que deseja selecionar: ");
        int opcaoFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarFabricantePorId(opcaoFabricante);

        Equipamento equipamento = new Equipamento(nome, precoAquisicao, dataFabricacao, fabricanteSelecionado);

        return equipamento;
    }

    public DateTime ValidarDataFabricacao( DateTime data)
    {
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        int erros = 0;

        if (data == DateTime.MinValue)
            Console.WriteLine("O campo Data de Fabricação é obrigatório.\n"); erros++;

        if (data > DateTime.Now)
            Console.WriteLine("A data de fabricação não pode ser maior que a data atual.\n"); erros++;

        if (erros > 0)
        ObterDadosEquipamento();

        return data;
    }

    private void VisualizarFabricantes()
    {
        Console.WriteLine();

        Console.WriteLine("Visualizando Fabricantes...");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
            "Id", "Nome", "Email", "Telefone", "Qtd. Equipamentos"
        );

        Fabricante[] fabCadastrados = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabCadastrados.Length; i++)
        {
            Fabricante fab = fabCadastrados[i];

            if (fab == null) continue;

            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
                fab.Id, fab.Nome, fab.Email, fab.Telefone, fab.ObterQuantidadeEquipamentos()
            );
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
}
