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

	public static void UpdateLivro(Livro livroToUp, LivroContext livroContext)
	{
		livroContext.Livros.Update(livroToUp);
		livroContext.SaveChanges();
	}
}