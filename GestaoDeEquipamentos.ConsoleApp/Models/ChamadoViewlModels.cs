using GestaoDeEquipamentos.ConsoleApp.Extensions;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.Models
{
    public abstract class FormularioChamadoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int EquipamentoId { get; set; }
        public List<SelecionarEquipamentoViewModel> EquipamentosDisponiveis { get; set; }

        protected FormularioChamadoViewModel()
        {
            EquipamentosDisponiveis = new List<SelecionarEquipamentoViewModel>();
        }
    }

    public class SelecionarEquipamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public SelecionarEquipamentoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class CadastrarChamadoViewModel : FormularioChamadoViewModel
    {
        public CadastrarChamadoViewModel() { }

        public CadastrarChamadoViewModel(List<Equipamento> equipamentos)
        {
            foreach (var equipamento in equipamentos)
            {
                var selecionarVM = new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome);

                EquipamentosDisponiveis.Add(selecionarVM);
            }
        }
    }

    public class EditarChamadoViewModel : FormularioChamadoViewModel
    {
        public int Id { get; set; }

        public EditarChamadoViewModel() { }

        public EditarChamadoViewModel(
            int id,
            string titulo,
            string descricao,
            int equipamentoId,
            List<Equipamento> equipamentos
        )
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            EquipamentoId = equipamentoId;

            foreach (var equipamento in equipamentos)
            {
                var selecionarVM = new SelecionarEquipamentoViewModel(equipamento.Id, equipamento.Nome);

                EquipamentosDisponiveis.Add(selecionarVM);
            }
        }
    }

    public class ExcluirChamadoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public ExcluirChamadoViewModel(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }

    public class VisualizarChamadosViewModel
    {
        public List<DetalhesChamadoViewModel> Registros { get; set; }

        public VisualizarChamadosViewModel(List<Chamado> chamados)
        {
            Registros = new List<DetalhesChamadoViewModel>();

            foreach (var c in chamados)
            {
                var detalhesVM = c.ParaDetalhesVM();

                Registros.Add(detalhesVM);
            }
        }
    }

    public class DetalhesChamadoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public int TempoDecorrido { get; set; }
        public string NomeEquipamento { get; set; }

        public DetalhesChamadoViewModel(
            int id,
            string titulo,
            string descricao,
            DateTime dataAbertura,
            int tempoDecorrido,
            string nomeEquipamento
        )
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            TempoDecorrido = tempoDecorrido;
            NomeEquipamento = nomeEquipamento;
        }

        public override string ToString()
        {
            return $"Id: {Id} - Equipamento: {NomeEquipamento} -  Título: {Titulo} - Descrição: {Descricao} - Data de Abertura: {DataAbertura:d} - Dias em Aberto: {TempoDecorrido} dias";
        }
    }
}