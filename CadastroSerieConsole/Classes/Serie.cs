using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSerieConsole.Classes
{
    public class Serie : EntidadeBase
    {


        public string Titulo { get; private set; }
        public int Ano { get; private set; }
        public int Temporadas { get; private set; }
        public string Descricao { get; private set; }
        public Genero Genero { get; private set; }
        public bool Excluido { get; private set; }

        public Serie(int id, string titulo, int ano, int temporadas, string descricao, Genero genero)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Temporadas = temporadas;
            Descricao = descricao;
            Genero = genero;
            Excluido = false;
        }

        public override string ToString()
        {
            return $"Título: {Titulo} | Ano: {Ano} | Temporadas: {Temporadas} | Gênero: {Genero} | Descrição: {Descricao} | Excluído: {Excluido}";
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}
