using ChitChatAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }
        public string AvatarUrl { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public ICollection<GroupMessage> SentMessages { get; set; }
        [JsonIgnore]
        public ICollection<GroupMessage> ReceivedMessages { get; set; }
        [JsonIgnore]
        public ICollection<GroupUser> GroupUsers { get; set; }
    }
}
