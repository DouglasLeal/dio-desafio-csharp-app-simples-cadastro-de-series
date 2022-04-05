using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSerieConsole.Repositorios
{
    public interface IRepositorio<T>
    {
        void Criar(T entidade);
        List<T> Listar();
        T BuscarPorId(int id);
        void Atualizar(int id, T entidade);
        void Excluir(int id);  

        int ProximoId();
    }
}
