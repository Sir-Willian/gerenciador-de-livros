using GerenciadorDeLivros.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorDeLivros.Service;

public static class JwtAuth
{
	public static IConfiguration Configuration { get; set; } = default!;

	public static string GenerateToken(User user)
	{
		var myClaims = new[]
		{
			new Claim(ClaimTypes.Name, user.Name),
			new Claim(ClaimTypes.Role, RoleFactory(user.Type))
		};

        #pragma warning disable CS8604
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]));
		var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

		var token = new JwtSecurityToken(
			issuer: Configuration["JwtSettings:Issuer"],
			audience: Configuration["JwtSettings:Audience"],
			expires: DateTime.Now.AddMinutes(60),
			claims: myClaims,
			signingCredentials: cred);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	private static string RoleFactory(int roleNumber)
	{
		return roleNumber switch
		{
			1 => "Cliente",
			2 => "Funcionário",
			3 => "Gerente",
			_ => throw new Exception()
		};
	}
}
