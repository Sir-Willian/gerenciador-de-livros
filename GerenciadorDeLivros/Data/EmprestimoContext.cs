using GerenciadorDeLivros.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeLivros.Data;

public class EmprestimoContext : DbContext
{
	public EmprestimoContext(DbContextOptions<EmprestimoContext> options) : base(options) { }

	public DbSet<Emprestimo> Emprestimos { get; set; }
}
