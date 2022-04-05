using CadastroSerieConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSerieConsole.Repositorios
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> _listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie entidade)
        {
            _listaSerie[id] = entidade;
        }

        public Serie BuscarPorId(int id)
        {
            return _listaSerie[id];
        }

        public void Criar(Serie entidade)
        {
            _listaSerie.Add(entidade);
        }

        public void Excluir(int id)
        {
            _listaSerie[id].Excluir();
        }

        public List<Serie> Listar()
        {
            return _listaSerie;
        }

        public int ProximoId()
        {
            return _listaSerie.Count;
        }
    }
}
