
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using System;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante
    {

        public RepositorioFabricante repositorioFabricante;
        public TelaFabricante()
        {
            repositorioFabricante = new RepositorioFabricante();
        }
        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         Gestão de Fabricantes        |");
            Console.WriteLine("----------------------------------------");
        }
        public char ApresentarMenuFabricante()
        {
            ExibirCabecalho();

            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1 - Cadastrar novo Fabricante");
            Console.WriteLine("2 - Editar Fabricante");
            Console.WriteLine("3 - Excluir Fabricante");
            Console.WriteLine("4 - Visualizar Fabricantes");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

            return operacaoEscolhida;
        }

        public void CadastrarFabricante()
        {

            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         Cadastro de Fabricante       |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            Console.Write("Digite o nome do Fabricante: ");
            string nome = Console.ReadLine()!;

            Console.Write("Digite o e-mail do Fabricante: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite o telefone do Fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);
            novoFabricante.Id = GeradorIds.GerarIdFabricante();

            repositorioFabricante.CadastrarFabricante(novoFabricante);
        }
            
        public void EditarFabricante()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         Edição de Fabricante         |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do Fabricante: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine()!);
            Fabricante fabricante = repositorioFabricante.SelecionarFabricantePorId(idFabricante);
            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }
            Console.Write("Digite o novo nome do Fabricante: ");
            string nome = Console.ReadLine()!;
            Console.Write("Digite o novo e-mail do Fabricante: ");
            string email = Console.ReadLine()!;
            Console.Write("Digite o novo telefone do Fabricante: ");
            string telefone = Console.ReadLine()!;

            Fabricante fabricanteEditado = new Fabricante(nome, email, telefone);
            repositorioFabricante.EditarFabricante(idFabricante, fabricanteEditado);

            Console.WriteLine("Fabricante editado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void ExcluirFabricante()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|         Exclusão de Fabricante       |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            VisualizarFabricantes(false);
            Console.Write("Digite o ID do Fabricante: ");
            int idFabricante = Convert.ToInt32(Console.ReadLine()!);
            Fabricante fabricante = repositorioFabricante.SelecionarFabricantePorId(idFabricante);
            if (fabricante == null)
            {
                Console.WriteLine("Fabricante não encontrado.");
                return;
            }

            Console.Write("Tem certeza que deseja excluir o Fabricante? (S/N): ");
            char confirmacao = Convert.ToChar(Console.ReadLine()!.ToUpper());

            if (confirmacao != 'S')
            {
                Console.WriteLine("Exclusão cancelada.");
                return;
            }

            if (repositorioFabricante.ExcluirFabricante(idFabricante) == false)
            {
                Console.WriteLine("Erro ao excluir o Fabricante.");
                return;
            }

            if (repositorioFabricante.ExcluirFabricante(idFabricante) == true)
            {
                repositorioFabricante.ExcluirFabricante(idFabricante);
                Console.WriteLine("Fabricante excluído com sucesso!");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                ExibirCabecalho();

                Console.WriteLine("Visualizando Fabricantes...");
                Console.WriteLine("--------------------------------------------");
            }

            Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15}",
                "Id", "Nome", "E-mail", "Telefone"
            );
            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante f = fabricantes[i];
                if (f == null)
                    continue;
                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -11} | {3, -15}",
                    f.Id, f.Nome, f.Email, f.Telefone
                );
            }
            Console.WriteLine();
        }
    }
}
