using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class ContextoDeDados
    {
        public List<Fabricante> Fabricantes { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
        public List<Chamado> Chamados { get; set; }

        private string pastaArmazenamento = "C:\\temp";
        private string arquivoArmazenamento = "dados.json";

        public ContextoDeDados()
        {
            Fabricantes = new List<Fabricante>();
            Equipamentos = new List<Equipamento>();
            Chamados = new List<Chamado>();
        }

        public ContextoDeDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        public void Salvar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            string json = JsonSerializer.Serialize(this, jsonOptions);

            if (!Directory.Exists(pastaArmazenamento))
                Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminhoCompleto, json);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminhoCompleto)) return;

            string json = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(json)) return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;
            ContextoDeDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDeDados>(json, jsonOptions)!;

            if (contextoArmazenado == null) return;

            this.Fabricantes = contextoArmazenado.Fabricantes;
            this.Equipamentos = contextoArmazenado.Equipamentos;
            this.Chamados = contextoArmazenado.Chamados;
        }
    }
}
