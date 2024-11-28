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
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }
        public byte[] Avatar { get; set; }
        public string? VerificationCode { get; set; }
        public DateTime? VerificationCodeExpiration { get; set; }

        public bool PasswordResetAuthorized { get; set; }
        public DateTime? PasswordResetAuthorizedExpiration { get; set; }

        public ICollection<GroupMessage> SentMessages { get; set; }
        public ICollection<GroupMessage> ReceivedMessages { get; set; }
        public ICollection<GroupUser> GroupUsers { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
        [JsonIgnore]
        public ICollection<Group> CreatedGroups { get; set; }
    }
}
