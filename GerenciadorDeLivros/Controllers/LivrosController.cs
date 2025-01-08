using GerenciadorDeLivros.Data;
using GerenciadorDeLivros.Model;
using GerenciadorDeLivros.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers;

[ApiController()]
[Route("[controller]")]
public class LivrosController : ControllerBase
{
	private readonly LivroContext _context;

	public LivrosController(LivroContext context) { _context = context; }

	[HttpGet()]
	[Authorize()]
	public ActionResult<List<Livro>> GetAll() => LivroService.GetLivros(_context);

	[HttpGet("{id}")]
	[Authorize()]
	public ActionResult<Livro> Get(int id)
	{
		var livro = LivroService.GetLivro(id, _context);
		if(livro == null) { return NotFound("Este livro não existe."); }

		return Ok(livro);
	}

	[HttpGet("titulo={titulo}")]
	[Authorize()]
	public ActionResult<List<Livro>> GetLivrosByTitulo(string titulo) => LivroService.GetLivrosByTitulo(titulo, _context);

	[HttpGet("autor={autor}")]
	[Authorize()]
	public ActionResult<List<Livro>> GetLivrosByAutor(string autor) => LivroService.GetLivrosByAutor(autor, _context);

	[HttpGet("genero={genero}")]
	[Authorize()]
	public ActionResult<List<Livro>> GetLivrosByGenero(string genero) => LivroService.GetLivrosByGenero(genero, _context);

	[HttpGet("classificacao={classificacao}")]
	[Authorize()]
	public ActionResult<List<Livro>> GetLivrosByClassificacao(int classificacao) => LivroService.GetLivrosByClassificacao(classificacao, _context);

	[HttpPost()]
	[Authorize(Roles = "Funcionário,Gerente")]
	public ActionResult<Livro> Post(Livro livro)
	{
		var existingLivro = LivroService.GetLivro(livro.Id, _context);
		if (existingLivro != null) { return BadRequest("Um livro com este mesmo Id já existe."); }

		LivroService.AddLivro(livro, _context);

		return CreatedAtAction(nameof(Get), new { id = livro.Id}, livro);
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Gerente")]
	public ActionResult Delete(int id)
	{
		var existingLivro = LivroService.GetLivro(id, _context);
		if(existingLivro == null) { return NotFound("Este livro não existe."); }

		LivroService.DeleteLivro(existingLivro, _context);

		return NoContent();
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Funcionário,Gerente")]
	public ActionResult Put(int id, Livro livro)
	{
		var existingLivro = LivroService.GetLivro(id, _context);
		if(existingLivro == null) { return NotFound("Este livro não existe."); }

		LivroService.UpdateLivro(existingLivro, livro, _context);

		return NoContent();
	}
}