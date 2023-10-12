using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharpPizza.Domain;
using SharpPizza.Infrastructure.Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SharpPizza.Api.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SharpPizzaDbContext _context;
        public IConfiguration _configuration;

        public UserController(SharpPizzaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public dynamic Login([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data!.username.ToString();
            string password = data.password.ToString();

            User? usuario = _context.Users.Where(x => x.UserName == user && x.Password == password).FirstOrDefault();

            if (usuario == null)
            {
                return new
                {
                    succes = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuario.Id.ToString() ),
                new Claim("username", usuario.UserName)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                signingCredentials: singIn

                );

            return new
            {
                succes = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

    }
}
