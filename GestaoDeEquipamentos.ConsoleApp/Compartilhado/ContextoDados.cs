using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class ContextoDados
    {
        public List<Fabricante> Fabricantes { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
        public List<Chamado> Chamados { get; set; }

        private string pastaArmazenamento = "C:\\ArquivosJson";
        private string arquivoArmazenamento = "dados-gestao-de-equipamentos.json";

        public ContextoDados()
        {
            Fabricantes = new List<Fabricante>();
            Equipamentos = new List<Equipamento>();
            Chamados = new List<Chamado>();
        }

        public void Salvar()
        {
            string caminhoDaPasta = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;
            string json = JsonSerializer.Serialize(jsonOptions);

            if(!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoDaPasta, json);
        }

        public void Carregar()
        {
            string caminhoDaPasta = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if(!File.Exists(caminhoDaPasta)) return;

            string json = File.ReadAllText(caminhoDaPasta);

            if(string.IsNullOrWhiteSpace(json)) return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados contexto = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions)!;

            if (contexto == null) return;

            this.Fabricantes = contexto.Fabricantes;
            this.Equipamentos = contexto.Equipamentos;
            this.Chamados = contexto.Chamados;
        }

    }
}
