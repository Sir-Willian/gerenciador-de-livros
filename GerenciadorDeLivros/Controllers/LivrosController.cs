using GerenciadorDeLivros.Data;
using GerenciadorDeLivros.Model;
using GerenciadorDeLivros.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers;

[ApiController()]
[Route("[controller]")]
public class LivrosController : ControllerBase
{
	private readonly LivroContext _context;

	public LivrosController(LivroContext context) { _context = context; }

	[HttpGet()]
	public ActionResult<List<Livro>> GetAll() => LivroService.GetLivros(_context);

	[HttpGet("{id}")]
	public ActionResult<Livro> Get(int id)
	{
		var livro = LivroService.GetLivro(id, _context);
		if(livro == null) { return NotFound("Este livro não existe."); }

		return Ok(livro);
	}

	[HttpPost()]
	public ActionResult<Livro> Post(Livro livro)
	{
		var existingLivro = LivroService.GetLivro(livro.Id, _context);
		if (existingLivro != null) { return BadRequest("Um livro com este mesmo Id já existe."); }

		LivroService.AddLivro(livro, _context);

		return CreatedAtAction(nameof(Get), new { id = livro.Id}, livro);
	}

	[HttpDelete("{id}")]
	public ActionResult Delete(int id)
	{
		var existingLivro = LivroService.GetLivro(id, _context);
		if(existingLivro == null) { return NotFound("Este livro não existe."); }

		LivroService.DeleteLivro(existingLivro, _context);

		return NoContent();
	}

	[HttpPut("{id}")]
	public ActionResult Put(int id, Livro livro)
	{
		var existingLivro = LivroService.GetLivro(id, _context);
		if(existingLivro == null) { return NotFound("Este livro não existe."); }

		LivroService.UpdateLivro(existingLivro, livro, _context);

		return NoContent();
	}
}