using GerenciadorDeLivros.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeLivros.Data;

public class LivroContext : DbContext
{
	public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }

	public DbSet<Livro> Livros { get; set; }
}