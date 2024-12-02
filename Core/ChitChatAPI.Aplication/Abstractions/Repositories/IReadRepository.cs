﻿using ChitChatAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Abstractions.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<T> GetEntityByIdAsync(Guid id);
        public Task<bool> HasEntityByIdAsync(Guid id);
    }
}
