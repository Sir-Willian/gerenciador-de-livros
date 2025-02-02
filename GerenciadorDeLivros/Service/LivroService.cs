﻿using GerenciadorDeLivros.Data;
using GerenciadorDeLivros.Model;

namespace GerenciadorDeLivros.Service;

public static class LivroService
{
	static LivroService() { }

	public static List<Livro> GetLivros(LivroContext livroContext) => livroContext.Livros.ToList();

	public static Livro? GetLivro(int id, LivroContext livroContext) => livroContext.Livros.FirstOrDefault(l => l.Id == id);

	public static List<Livro> GetLivrosByTitulo(string titulo, LivroContext livroContext) => livroContext.Livros.ToList().FindAll(l => l.Titulo == titulo);

	public static List<Livro> GetLivrosByAutor(string autor, LivroContext livroContext) => livroContext.Livros.ToList().FindAll(l => l.Autor == autor);

	public static List<Livro> GetLivrosByGenero(string genero, LivroContext livroContext) => livroContext.Livros.ToList().FindAll(l => l.Genero == genero);

	public static List<Livro> GetLivrosByClassificacao(int classificacao, LivroContext livroContext) => livroContext.Livros.ToList().FindAll(l => l.Classificacao == classificacao);

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
		livroNotUp.Classificacao = toUp.Classificacao != default ? toUp.Classificacao : livroNotUp.Classificacao;

		livroContext.SaveChanges();
	}
}