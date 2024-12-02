using Azure.Identity;
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
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        private ChitChatDbContext _context;
        public UserReadRepository(ChitChatDbContext context) : base(context)
        {
            _context = context;
        }

        public DbSet<User> Table => _context.Set<User>();

        public async Task<bool> CheckForDuplicateEmailUsernameAsync(string email, string username) => await Table.FirstOrDefaultAsync(u => u.Username == username || u.Email == email) != null;

        public async Task<User> CheckLoginCredentials(string UsernameorEmail, string password)
        {
            var user = await Table.FirstOrDefaultAsync(u => (u.Username == UsernameorEmail || u.Email == UsernameorEmail) && u.PasswordHash == password);
            return user;
        }
    }
}
