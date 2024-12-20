﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication.Features.Query.GroupMessage.GetGroupMessages
{
    public class GetGroupMessagesQueryRequest : IRequest<GetGroupMessagesQueryResponse>
    {
        public Guid GroupId { get; set; }
    }
}
