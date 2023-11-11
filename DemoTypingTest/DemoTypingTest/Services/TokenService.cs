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
                new Claim("username", user.UserName),
                new Claim("email", user.Email)
            };

            Console.WriteLine($"Reivindicações no token: {string.Join(", ", claims.Select(c => $"{c.Type}: {c.Value}"))}");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("anapata-123-ovo-123-123"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(5);

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
