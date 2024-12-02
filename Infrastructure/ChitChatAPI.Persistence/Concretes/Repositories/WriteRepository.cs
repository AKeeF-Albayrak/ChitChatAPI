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
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ChitChatDbContext _context;

        public WriteRepository(ChitChatDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity) => await Table.AddAsync(entity);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<bool> UpdateEntityAsync(T entity)
        {
            Table.Update(entity);
            return true;
        }
    }
}
