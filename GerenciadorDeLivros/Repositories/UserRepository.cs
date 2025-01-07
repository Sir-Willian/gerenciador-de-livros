using GerenciadorDeLivros.Model;

namespace GerenciadorDeLivros.Repositories;

public class UserRepository
{
	/*
	 * 1 - Cliente
	 * 2 - Funcionário
	 * 3 - Gerente
	 */

	public static IList<User> Users = new List<User>
	{
		new()
		{
			Type = 3,
			Name = "Matt",
			Password = "matt123"
		},
		new()
		{
			Type = 1,
			Name = "Jorge",
			Password = "jorge123"
		},
		new()
		{
			Type = 2,
			Name = "John",
			Password = "john123"
		}
	};

	public static User? GetByName(string userName) => Users.Where(u => u.Name == userName).FirstOrDefault();
}
