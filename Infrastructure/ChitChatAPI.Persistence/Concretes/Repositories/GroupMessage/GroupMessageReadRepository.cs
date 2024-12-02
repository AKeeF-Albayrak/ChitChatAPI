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
    public class GroupMessageReadRepository : ReadRepository<GroupMessage>, IGroupMessageReadRepository
    {
        private readonly ChitChatDbContext _context;
        public GroupMessageReadRepository(ChitChatDbContext context) : base(context)
        {
            _context = context;
        }
        public DbSet<GroupMessage> Table => _context.Set<GroupMessage>();
        public async Task<ICollection<GroupMessage>> GetMessagesByGroupIdAsync(Guid groupId) => await Table.Where(m =>  m.GroupId == groupId).ToListAsync();
    }
}
