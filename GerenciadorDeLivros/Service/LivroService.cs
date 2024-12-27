using GerenciadorDeLivros.Data;
using GerenciadorDeLivros.Model;

namespace GerenciadorDeLivros.Service;

public static class LivroService
{
	static LivroService() { }

	public static List<Livro> GetLivros(LivroContext livroContext) => livroContext.Livros.ToList();

	public static Livro? GetLivro(int id, LivroContext livroContext) => livroContext.Livros.FirstOrDefault(l => l.Id == id);

	public static void AddLivro(Livro livro, LivroContext livroContext)
	{
		livroContext.Livros.Add(livro);
		livroContext.SaveChanges();
	}

	public static void DeleteLivro(Livro livro, LivroContext livroContext)
	{
		livroContext.Livros.Remove(livro);
		livroContext.SaveChanges();
	}

	public static void UpdateLivro(Livro livroNotUp, Livro toUp, LivroContext livroContext)
	{
		livroNotUp.Titulo = toUp.Titulo;
		livroNotUp.Autor = toUp.Autor;
		livroNotUp.Genero = toUp.Genero;
		livroNotUp.DataDePublicacao = toUp.DataDePublicacao != default ? toUp.DataDePublicacao : livroNotUp.DataDePublicacao;
		livroNotUp.Resumo = toUp.Resumo ?? livroNotUp.Resumo;
		livroNotUp.Classificacao = toUp.Classificacao;

		livroContext.SaveChanges();
	}
}