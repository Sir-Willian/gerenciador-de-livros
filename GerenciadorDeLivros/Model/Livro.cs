using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeLivros.Model;

[Table("livros")]
public class Livro
{
	[Column("titulo")]
	[Required()]
	[MinLength(2)]
	[MaxLength(40)]
	public string? Titulo { get; set; }

	[Column("autor")]
	[Required()]
	[MinLength(2)]
	[MaxLength(30)]
	public string? Autor { get; set; }

	[Column("genero")]
	[Required()]
	[MinLength(2)]
	[MaxLength(30)]
	public string? Genero { get; set; }

	[Column("data_de_publicacao")]
	[Required()]
	public DateOnly DataDePublicacao { get; set; }

	[Column("resumo")]
	public string? Resumo { get; set; }

	[Column("classificacao")]
	[Range(0, 5)]
	public int Classificacao { get; set; }
}