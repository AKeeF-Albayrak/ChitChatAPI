using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Aplication.Abstractions.Services;
using ChitChatAPI.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Concretes.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private IRefreshTokenReadRepository _refreshTokenReadRepository;
        private IRefreshTokenWriteRepository _refreshTokenWriteRepository;

        public TokenService(IConfiguration configuration, IRefreshTokenReadRepository refreshTokenReadRepository, IRefreshTokenWriteRepository refreshTokenWriteRepository)
        {
            _configuration = configuration;
            _refreshTokenReadRepository  = refreshTokenReadRepository;
            _refreshTokenWriteRepository = refreshTokenWriteRepository;
        }

        public string GenerateToken(string username, Guid userId, Guid TokenId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("id", userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Jti, TokenId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RefreshToken> ValidateToken(string token)
        {
            var _token = await _refreshTokenReadRepository.GetTokenByTokenAsync(token);

            if (_token != null && _token.ExpiryDate > DateTime.Now)
            {
                return _token;
            }
            if (_token == null) return null;

            _token.IsValid = false;
            
            await _refreshTokenWriteRepository.UpdateEntityAsync(_token);
            await _refreshTokenWriteRepository.SaveChangesAsync();

            return null;
        }
    }

}
