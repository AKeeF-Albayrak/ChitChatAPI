﻿using ChitChatAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Abstractions.Repositories
{
    public interface IGroupUserReadRepository : IReadRepository<GroupUser>
    {
        public Task<bool> CheckGroupUserByUserId(Guid userId, Guid groupId);
    }
}
