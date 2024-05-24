using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Authentication;
using ToDoList.DataLayer.Abstract;

namespace ToDoList.DataLayer.EntityFramework
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Token:Secret"]));

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: _configuration["Token:ValidIssuer"],
                    audience: _configuration["Token:ValidAudience"],
                    claims: new List<Claim> {
                    new Claim("userName", request.Username)
                    },
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.Add(TimeSpan.FromMinutes(100000)),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );
            return Task.FromResult(new GenerateTokenResponse
            {
                Token=new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate=dateTimeNow.Add(TimeSpan.FromMinutes(500)),
            });
        }
    }
}
