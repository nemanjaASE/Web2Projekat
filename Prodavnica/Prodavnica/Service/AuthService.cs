using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Prodavnica.Dto;
using Prodavnica.Interfaces.IRepository;
using Prodavnica.Interfaces.IService;
using Prodavnica.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Prodavnica.Service
{
	public class AuthService : IAuthService
	{
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		private readonly IKorisnikRepository _repositoryKorisnik;

		public AuthService(IMapper mapper, IConfiguration configuration, IKorisnikRepository repo)
        {
			_mapper = mapper;
			_configuration = configuration;
			_repositoryKorisnik = repo;
        }
        public Task<string> GoogleLogin(string token)
		{
			throw new NotImplementedException();
		}

		public async Task<string> Login(LoginDTO loginDto)
		{
			var korisnici = await _repositoryKorisnik.GetAll();

			Korisnik? user = korisnici.Where(u => u.Email == loginDto.Email).FirstOrDefault();

			if (user == null)
			{
				throw new Exception($"Korisnik {loginDto.Email} ne postoji.");

			}else if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
			{
				throw new Exception($"Pogresna sifra.");
			}

			var claims = new[] {
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
						new Claim("UserId", user.Id.ToString()),
						new Claim("Email", user.Email!),
						new Claim(ClaimTypes.Role, user.Tip.ToString()),
						new Claim("Verification", user.Verifikacija.ToString())

			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "default"));

			var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				_configuration["Jwt:Issuer"],
				_configuration["Jwt:Audience"],
				claims,
				expires: DateTime.UtcNow.AddDays(1),
				signingCredentials: signIn);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
