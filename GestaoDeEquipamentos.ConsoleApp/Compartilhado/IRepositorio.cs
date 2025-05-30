using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        public void CadastrarRegistro(T novoRegistro);
        public bool EditarRegistro(int idRegistro, T registroEditado);
        public bool ExcluirRegistro(int idRegistro);
        public List<T> SelecionarRegistros();
        public T SelecionarRegistroPorId(int idRegistro);
    }
}
