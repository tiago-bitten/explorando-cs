using DemoTypingTest.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoTypingTest.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("anapata-123-ovo-123-123"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                signingCredentials: signingCredentials,
                claims: claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
