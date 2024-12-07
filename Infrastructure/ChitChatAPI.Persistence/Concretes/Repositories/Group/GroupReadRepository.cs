using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities;
using ChitChatAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Concretes.Repositories
{
    public class GroupReadRepository : ReadRepository<Domain.Entities.Group>, IGroupReadRepository
    {
        private readonly ChitChatDbContext _context;
        public GroupReadRepository(ChitChatDbContext context) : base(context)
        {
            _context = context;
        }
        public DbSet<Domain.Entities.Group> Table => _context.Set<Domain.Entities.Group>();

        public async Task<ICollection<Group>> GetUserGroupsAsync(Guid userId)
        {
            return await Table
                        .Where(g => g.GroupUsers.Any(gu => gu.UserId == userId))
                        .ToListAsync();
        }
    }
}
