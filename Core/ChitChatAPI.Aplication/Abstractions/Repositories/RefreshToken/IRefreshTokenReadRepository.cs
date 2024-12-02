using ChitChatAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Abstractions.Repositories
{
    public interface IRefreshTokenReadRepository : IReadRepository<RefreshToken>
    {
        public Task<RefreshToken> GetTokenByUserIdAndIpAdressAsync(Guid userId, string ipAdress);
        public Task<RefreshToken> GetTokenByTokenAsync(string token);
    }
}
