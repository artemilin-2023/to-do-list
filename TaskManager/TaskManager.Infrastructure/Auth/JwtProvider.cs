using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Application.Abstracts.Auth;
using TaskManager.Domain;

namespace TaskManager.Infrastructure.Auth
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions options;
        private const string UserIdClaim = "userId";

        public JwtProvider(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }

        public string Generate(User user)
        {
            var claim = new[] { new Claim(UserIdClaim, user.Id.ToString()) };
            var creditionals = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claim, 
                expires: DateTime.UtcNow.AddHours(options.ExpiresHours), 
                signingCredentials: creditionals);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }

        public Guid GetUserId(string token)
        {
            var jwtToken = new JwtSecurityTokenHandler()
                .ReadJwtToken(token);
            var claim = jwtToken.Claims
                .First(c => c.Type == UserIdClaim);

            return Guid.Parse(claim.Value);
        }
    }
}
