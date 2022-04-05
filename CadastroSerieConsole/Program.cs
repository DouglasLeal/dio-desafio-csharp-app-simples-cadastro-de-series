using CadastroSerieConsole.Classes;
using CadastroSerieConsole.Repositorios;

using System;

namespace CadastroSerieConsole
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = SelecionarOpcao();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						CriarSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = SelecionarOpcao();
			}

			Console.WriteLine("Até a próxima!!!");
			Console.ReadLine();
			Environment.Exit(0);
		}

		private static void ExcluirSerie()
		{
            Console.WriteLine("----- Excluir Série -----");
			Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			repositorio.Excluir(id);
		}

		private static void VisualizarSerie()
		{
            Console.WriteLine("----- Detalhes da Série -----");
			Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			var serie = repositorio.BuscarPorId(id);

			Console.WriteLine(serie);
		}

		private static void AtualizarSerie()
		{
            Console.WriteLine("----- Atualizar Série -----");
			Console.Write("Digite o id da série: ");
			int id = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Título: ");
			string titulo = Console.ReadLine();

			Console.Write("Ano de lançamento: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Temporadas: ");
			int temporadas = int.Parse(Console.ReadLine());

			Console.Write("Descrição: ");
			string descricao = Console.ReadLine();

			Serie serieAtualizada = new Serie(id: id,
										genero: (Genero)genero,
										titulo: titulo,
										ano: ano,
										temporadas: temporadas,
										descricao: descricao);

			repositorio.Atualizar(id, serieAtualizada);
		}
		
		private static void ListarSeries()
		{
			Console.WriteLine("----- Listar Séries -----");

			var lista = repositorio.Listar();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                if (!serie.Excluido)
                {
                    Console.WriteLine($"Id: {serie.Id} | {serie.Titulo} | {serie.Ano}");
                }
			}
		}

		private static void CriarSerie()
		{
			Console.WriteLine("----- Criar Série -----");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Título: ");
			string titulo = Console.ReadLine();

			Console.Write("Ano de lançamento: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Temporadas: ");
			int temporadas = int.Parse(Console.ReadLine());

			Console.Write("Descrição: ");
			string descricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)genero,
										titulo: titulo,
										ano: ano,
										temporadas: temporadas,
										descricao: descricao);

			repositorio.Criar(novaSerie);
		}

		private static string SelecionarOpcao()
		{
			Console.WriteLine();
			Console.WriteLine("===== Controle de Séries =====");
			

			Console.WriteLine("1 - Listar séries");
			Console.WriteLine("2 - Inserir nova série");
			Console.WriteLine("3 - Atualizar série");
			Console.WriteLine("4 - Excluir série");
			Console.WriteLine("5 - Visualizar série");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine();

			Console.Write("Informe a opção desejada:");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}