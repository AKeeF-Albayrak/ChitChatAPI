using Azure.Identity;
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
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ChitChatDbContext context) : base(context)
        {
        }
    }
}
