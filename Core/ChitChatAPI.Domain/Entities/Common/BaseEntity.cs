﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public required Guid Id { get; set; }
    }
}
