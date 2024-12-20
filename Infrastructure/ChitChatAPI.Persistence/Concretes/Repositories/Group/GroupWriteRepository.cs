﻿using ChitChatAPI.Aplication.Abstractions.Repositories;
using ChitChatAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Persistence.Concretes.Repositories
{
    public class GroupWriteRepository : WriteRepository<Domain.Entities.Group>, IGroupWriteRepository
    {
        public GroupWriteRepository(ChitChatDbContext context) : base(context)
        {
        }
    }
}
