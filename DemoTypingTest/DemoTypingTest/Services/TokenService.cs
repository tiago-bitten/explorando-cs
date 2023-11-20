using DemoTypingTest.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoTypingTest.Services
{
    public class TokenService
    {
        public string GenerateToken(ApplicationUser user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("anapata-123-ovo-123-123"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(48);

            var token = new JwtSecurityToken
                (
                signingCredentials: signingCredentials,
                claims: claims,
                expires: expiration
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
