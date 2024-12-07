using ChitChatAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required Guid GroupMessageId { get; set; }
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public GroupMessage GroupMessage { get; set; }
    }
}
