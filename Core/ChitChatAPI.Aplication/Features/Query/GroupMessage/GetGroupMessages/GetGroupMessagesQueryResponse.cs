﻿using ChitChatAPI.Domain.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Query.GroupMessage.GetGroupMessages
{
    public class GetGroupMessagesQueryResponse
    {
        public Response Response { get; set; }
        public ICollection<Domain.Entities.GroupMessage> Messages { get; set; }
    }
}
