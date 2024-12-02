using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Abstractions.Repositories
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        public Task<bool> CheckForDuplicateEmailUsernameAsync(string email, string username);
        public Task<User> CheckLoginCredentials(string username, string password);
    }
}
