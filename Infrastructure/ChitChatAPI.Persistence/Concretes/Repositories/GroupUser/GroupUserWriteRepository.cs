using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities;
using ChitChatAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Concretes.Repositories
{
    public class GroupUserWriteRepository : WriteRepository<GroupUser>, IGroupUserWriteRepository
    {
        public GroupUserWriteRepository(ChitChatDbContext context) : base(context)
        {
        }
    }
}
