using GerenciadorDeLivros.Model;
using GerenciadorDeLivros.Repositories;
using GerenciadorDeLivros.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers;

[ApiController()]
[Route("[controller]")]
public class AuthController : ControllerBase
{
	[HttpPost()]
	[AllowAnonymous()]
    #pragma warning disable CS1998
	public async Task<IActionResult> Auth(User user)
	{
		try
		{
			var existingUser = UserRepository.GetByName(user.Name);

			if (existingUser == null || user.Password != existingUser.Password) { return BadRequest("Nome ou senha está(ão) incorreto(s)."); }

			var token = JwtAuth.GenerateToken(existingUser);

			return Ok(new
			{
				Token = token,
				User = existingUser
			});
		}
		catch (Exception) { return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." }); }
	}
}
