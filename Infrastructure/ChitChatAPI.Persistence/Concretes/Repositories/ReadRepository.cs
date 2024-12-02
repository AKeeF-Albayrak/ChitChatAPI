using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities.Common;
using ChitChatAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Concretes.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ChitChatDbContext _context;
        public ReadRepository(ChitChatDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetEntityByIdAsync(Guid id) => await Table.FirstAsync(x => x.Id == id);

        public async Task<bool> HasEntityByIdAsync(Guid id) => await Table.FirstAsync(x => x.Id == id) != null;
    }
}
