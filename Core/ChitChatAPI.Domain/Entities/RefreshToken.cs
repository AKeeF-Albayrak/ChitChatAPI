using ChitChatAPI.Domain.Entities.Common;
using ChitChatAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public required string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public TokenType Type { get; set; }
        public Guid UserId { get; set; }
        public bool IsValid { get; set; }
        public required string DeviceInfo { get; set; }
        public required string IpAddress { get; set; }
        [JsonIgnore]
        public User User { get; set; }  
    }
}
