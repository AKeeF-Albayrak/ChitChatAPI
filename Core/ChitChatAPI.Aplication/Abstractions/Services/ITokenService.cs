using ChitChatAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Abstractions.Services
{
    public interface ITokenService
    {
        public string GenerateToken(string username, Guid UserId, Guid TokenId);
        public Task<RefreshToken> ValidateToken(string token);
    }
}
