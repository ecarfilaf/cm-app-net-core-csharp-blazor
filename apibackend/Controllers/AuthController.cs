using Microsoft.AspNetCore.Mvc;
using apibackend.Data;
using apibackend.Models;
using apibackend.Services;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;

namespace apibackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext _context;
		private readonly JwtService _jwtService;

		public AuthController(ApplicationDbContext context, JwtService jwtService)
		{
			_context = context;
			_jwtService = jwtService;
		}

		// POST: api/auth/register
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserForm model)
		{
			Console.WriteLine($"Registering user: {model.usuario} with email: {model.email}");
			if (_context.Usuarios.Any(u => u.Usuusuario == model.usuario))
				return BadRequest("El usuario ya está registrado.");

			var newUser = new UsuUsuarios
			{
				Usurut = int.Parse(model.rut),
				Usudv = model.dv,
				Usunombres = model.nombres,
				Usuapaterno = model.apaterno,
				Usuamaterno = model.amaterno,
				Usuusuario = model.usuario,
				Usuclave = BCrypt.Net.BCrypt.HashPassword(model.clave), // Hashear la contraseña
				Codestado = int.Parse(model.codestado),
				Codtipousuario = int.Parse(model.codtipousuario),
				Fecvigencia = DateTime.Parse(model.fecvigencia),
				Usuemail = model.email,
				Usuavatar = model.avatar,
				Fecingreg = DateTime.Now,
				Usuingreg = model.user,
				Funingreg = model.fun,
				Fecmodreg = DateTime.Now,
				Usumodreg = model.user,	
				Funmodreg = model.fun
			};

			_context.Usuarios.Add(newUser);
			await _context.SaveChangesAsync();

			return Ok("Usuario registrado exitosamente.");
		}

		// POST: api/auth/login
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserLogin model)
		{
			var user = await _context.Usuarios
				.FirstOrDefaultAsync(u => u.Usuusuario == model.username ); //&& u.Usuclave == model.password);
			if (user == null)
				return Unauthorized("Credenciales inválidas.");

			var  isPasswordValid = await Task.Run(() => BCrypt.Net.BCrypt.Verify(model.password, user.Usuclave) );
			if (!isPasswordValid)
				return Unauthorized("Credenciales inválidas.");

			var token = _jwtService.GenerarToken(user);

			// Configurar opciones de la Cookie para máxima seguridad
			var cookieOptions = new CookieOptions
			{
				HttpOnly = true,   // Evita accesos desde scripts de JavaScript (Mitiga XSS)
				Secure = true,     // Obliga a que viaje solo por HTTPS
				SameSite = SameSiteMode.Strict, // Mitiga ataques CSRF
				Expires = DateTime.UtcNow.AddHours(2)
			};

			// Añadir la cookie a la respuesta HTTP
			Response.Cookies.Append("X-Access-Token", token, cookieOptions);


			return Ok(new { Token = token });
		}

		// POST: api/auth/logout
		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] UserLogin model)
		{
			Console.WriteLine($"Logout user: {model.username} ");

			// Borra la cookie del navegador expirándola inmediatamente
            Response.Cookies.Delete("X-Access-Token");

			return Ok(new { message = "Sesión cerrada correctamente"  });
		}
	}
}
