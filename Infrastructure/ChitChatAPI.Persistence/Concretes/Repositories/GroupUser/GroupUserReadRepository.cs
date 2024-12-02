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
    public class GroupUserReadRepository : ReadRepository<GroupUser>, IGroupUserReadRepository
    {
        private readonly ChitChatDbContext _context;
        public GroupUserReadRepository(ChitChatDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<GroupUser> Table => _context.Set<GroupUser>();

        public async Task<bool> CheckGroupUserByUserId(Guid userId, Guid groupId) => await Table.FirstAsync(gu => gu.UserId == userId && gu.GroupId == groupId) != null;
    }
}
