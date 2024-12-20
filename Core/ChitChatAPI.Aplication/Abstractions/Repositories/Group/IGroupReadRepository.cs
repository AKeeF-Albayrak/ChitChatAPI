﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Abstractions.Repositories
{
    public interface IGroupReadRepository : IReadRepository<Domain.Entities.Group>
    {
        public Task<ICollection<Domain.Entities.Group>> GetUserGroupsAsync(Guid userId);
    }
}
