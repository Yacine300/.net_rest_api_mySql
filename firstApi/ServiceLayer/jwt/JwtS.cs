using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace firstApi.ServiceLayer.jwt
{
    public class JwtS : IJwtS
    {
        private readonly IConfiguration _configuration;

        public JwtS(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GenerateJwtToken(string email)
        {
              var tokenHandler = new JwtSecurityTokenHandler();
              var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            if (key.Length < 32)
            {
                throw new ArgumentException("The key must be at least 32 bytes long.", nameof(key));
            }

            var tokenDescriptor = new SecurityTokenDescriptor

              {
                  Subject = new ClaimsIdentity(new[]
                  {
                  new Claim(ClaimTypes.Email, email)
              }),
                  Expires = DateTime.UtcNow.AddDays(7),
                  SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
              };
              var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
