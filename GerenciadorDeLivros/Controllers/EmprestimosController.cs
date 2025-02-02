﻿using GerenciadorDeLivros.Data;
using GerenciadorDeLivros.Model;
using GerenciadorDeLivros.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers;

[ApiController()]
[Route("[controller]")]
public class EmprestimosController : ControllerBase
{
	private readonly EmprestimoContext context;

	public EmprestimosController(EmprestimoContext _context) { context = _context; }

	[HttpGet()]
	[Authorize()]
	public ActionResult<List<Emprestimo>> GetAll() => EmprestimoService.GetEmprestimos(context);

	[HttpGet("{id}")]
	[Authorize()]
	public ActionResult<Emprestimo> Get(int id)
	{
		var emprestimo = EmprestimoService.GetEmprestimo(id, context);
		if (emprestimo == null) { return NotFound("Este empréstimo não existe."); }

		return emprestimo;
	}

	[HttpGet("email={email}")]
	[Authorize()]
	public ActionResult<List<Emprestimo>> GetAllByEmail(string email) => EmprestimoService.GetEmprestimosByEmail(email, context);

	[HttpGet("livro_id={livroId}")]
	[Authorize()]
	public ActionResult<List<Emprestimo>> GetAllByLivroId(int livroId) => EmprestimoService.GetEmprestimosByLivroId(livroId, context);

	[HttpPost()]
	[Authorize()]
	public ActionResult<Emprestimo> Post(Emprestimo emprestimo)
	{
		var existingEmprestimo = EmprestimoService.GetEmprestimo(emprestimo.EmprestimoId, context);
		if (existingEmprestimo != null) { return BadRequest("Um empréstimo com este mesmo Id já existe."); }

		EmprestimoService.AddEmprestimo(emprestimo, context);

		return CreatedAtAction(nameof(Get), new { id = emprestimo.EmprestimoId }, emprestimo);
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Funcionário,Gerente")]
	public ActionResult Delete(int id)
	{
		var existingEmprestimo = EmprestimoService.GetEmprestimo(id, context);
		if (existingEmprestimo == null) { return NotFound("Este empréstimo não existe."); }

		EmprestimoService.DeleteEmprestimo(existingEmprestimo, context);

		return NoContent();
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Funcionário,Gerente")]
	public ActionResult Put(int id, Emprestimo emprestimo)
	{
		var existingEmprestimo = EmprestimoService.GetEmprestimo(id, context);
		if(existingEmprestimo == null) { return BadRequest("Este empréstimo não existe."); }

		EmprestimoService.UpdateEmprestimo(existingEmprestimo, emprestimo, context);

		return NoContent();
	}
}
