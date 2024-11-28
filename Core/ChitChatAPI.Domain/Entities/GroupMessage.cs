using ChitChatAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities
{
    public class GroupMessage : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Guid SenderId { get; set; }
        public string Content { get; set; }
        public byte[] MediaData { get; set; }
        public DateTime Timestamp { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
        [JsonIgnore]
        public User Sender { get; set; }
        [JsonIgnore]
        public ICollection<User> ReadedUsers { get; set; }
    }
}
