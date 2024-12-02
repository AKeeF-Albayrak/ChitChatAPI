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
    public class GroupMessageWriteRepository : WriteRepository<GroupMessage>, IGroupMessageWriteRepository
    {
        public GroupMessageWriteRepository(ChitChatDbContext context) : base(context)
        {
        }
    }
}
