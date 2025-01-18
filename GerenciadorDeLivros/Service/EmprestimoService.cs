using GerenciadorDeLivros.Data;
using GerenciadorDeLivros.Model;

namespace GerenciadorDeLivros.Service;

public class EmprestimoService
{
	static EmprestimoService() { }

	public static List<Emprestimo> GetEmprestimos(EmprestimoContext emprestimoContext) => emprestimoContext.Emprestimos.ToList();

	public static Emprestimo? GetEmprestimo(int id, EmprestimoContext emprestimoContext) => emprestimoContext.Emprestimos.FirstOrDefault(e => e.EmprestimoId == id);

	public static void AddEmprestimo(Emprestimo emprestimo, EmprestimoContext emprestimoContext)
	{
		emprestimoContext.Emprestimos.Add(emprestimo);
		emprestimoContext.SaveChanges();
	}

	public static void DeleteEmprestimo(Emprestimo emprestimo, EmprestimoContext emprestimoContext)
	{
		emprestimoContext.Emprestimos.Remove(emprestimo);
		emprestimoContext.SaveChanges();
	}

	public static void UpdateEmprestimo(Emprestimo emprestimoNoUp, Emprestimo toUp, EmprestimoContext emprestimoContext)
	{
		emprestimoNoUp.Email = toUp.Email;
		emprestimoNoUp.Nome = toUp.Nome;
		emprestimoNoUp.Valor = toUp.Valor;
		emprestimoNoUp.DataDaDevolucao = toUp.DataDaDevolucao;

		emprestimoContext.SaveChanges();
	}
}
