using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeLivros.Model;

[Table("emprestimos")]
public class Emprestimo
{
	[Column("emprestimo_id")]
	[Key()]
	public int EmprestimoId { get; set; }

	[Column("email")]
	[EmailAddress(ErrorMessage = "Endereço inválido.")]
	[Required()]
	public string? Email { get; set; }

	[Column("nome")]
	[Required()]
	[MinLength(2)]
	[MaxLength(40)]
	public string? Nome { get; set; }

	[Column("valor")]
	[Required()]
	[Range(5.00,100.00)]
	public double Valor { get; set; }

	[Column("livro_id")]
	[Required()]
	[ForeignKey(nameof(LivroToBind))]
	public int LivroId { get; set; }

	// Propriedade de navegação
	public Livro? LivroToBind { get; set; }

	[Column("data_do_emprestimo")]
	[Required()]
	public DateOnly DataDoEmprestimo { get; set; }

	[Column("data_da_devolucao")]
	[Required()]
	public DateOnly DataDaDevolucao { get; set; }
}
