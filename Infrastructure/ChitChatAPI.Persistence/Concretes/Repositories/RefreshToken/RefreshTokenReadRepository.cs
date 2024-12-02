using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities;
using ChitChatAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Concretes.Repositories
{
    public class RefreshTokenReadRepository : ReadRepository<RefreshToken>, IRefreshTokenReadRepository
    {
        private readonly ChitChatDbContext _context;
        public RefreshTokenReadRepository(ChitChatDbContext context) : base(context)
        {
            _context = context;
        }
        public DbSet<RefreshToken> Table => _context.Set<RefreshToken>();

        public async Task<RefreshToken> GetTokenByTokenAsync(string token) => await Table.FirstAsync(t => t.Token == token && t.IsValid);

        public async Task<RefreshToken> GetTokenByUserIdAndIpAdressAsync(Guid userId, string ipAdress) => await Table.FirstAsync(t => t.IpAddress == ipAdress && t.UserId == userId);
    }
}
