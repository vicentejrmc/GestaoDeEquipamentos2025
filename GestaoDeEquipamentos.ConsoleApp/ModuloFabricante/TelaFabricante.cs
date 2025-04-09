
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {
        public RepositorioFabricante repositorioFabricante;

        public TelaFabricante(RepositorioFabricante repositorioFabricante)
        {
            this.repositorioFabricante = repositorioFabricante;
        }
        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         Gestão de Fabricantes        |");
            Console.WriteLine("----------------------------------------\n");
        }
        public char ApresentarMenuFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1 - Cadastrar Fabricante");
            Console.WriteLine("2 - Editar Fabricante");
            Console.WriteLine("3 - Excluir Fabricante");
            Console.WriteLine("4 - Visualizar Fabricantes");
            Console.WriteLine("S - Voltar\n");

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

            return operacaoEscolhida;
        }

        public void CadastrarFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("|         Cadastro de Fabricante       |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            Fabricante novoFabricante = ObterDadosFabricante();

            string erros = novoFabricante.Validar();

            if(erros.Length > 0)
            {
                Notificador.ExibirMensagem(erros, ConsoleColor.Red);
                return;
            }

            repositorioFabricante.CadastrarFabricante(novoFabricante);

            Notificador.ExibirMensagem("Registro concluido com Sucesso!", ConsoleColor.Green);

        }

        public void EditarFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("|         Edição de Fabricante         |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do registro que deseja selecionar: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine()!);

            Fabricante fabricanteEditado = ObterDadosFabricante();

            bool conseguiuEditar = repositorioFabricante.EditarFabricante(idFabricante, fabricanteEditado);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição do registro!", ConsoleColor.Red);

                return;
            }

            Notificador.ExibirMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("|         Exclusão de Fabricante       |");
            Console.WriteLine("----------------------------------------\n");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do registro que deseja excluir: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine()!);

            bool consegiuExcluir = repositorioFabricante.ExcluirFabricante(idFabricante);

            if (!consegiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusao do registo!", ConsoleColor.Red);
                return;
            }

            Notificador.ExibirMensagem("Registro Excluido com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
                ExibirCabecalho();

            Console.WriteLine("Visualizando Fabricantes...");
            Console.WriteLine("--------------------------------------------\n");

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -11} | {3, -15} | {4, -20}",
                "Id", "Nome", "E-mail", "Telefone", "Qte. Equipamentos"
            );

            Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante f = fabricantes[i];

                if (f == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -20}",
                    f.Id, f.Nome, f.Email, f.Telefone, f.ObterQuantidadeEquipamentos()
                );
            }
            Console.WriteLine();
        }

        public Fabricante ObterDadosFabricante()
        {
            Console.Write("Digite o nome do Fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o e-mail do Fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite o telefone do Fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante Fabricante = new Fabricante(nome, email, telefone);

            return Fabricante;
        }
    }
}
