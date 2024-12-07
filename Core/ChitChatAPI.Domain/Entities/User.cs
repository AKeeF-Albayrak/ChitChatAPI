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
        public required string Username { get; set; }
        public Role Role { get; set; }
        public required string PasswordHash { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public DateOnly BirhDate { get; set; }
        public bool Gender { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }
        public required byte[] Avatar { get; set; }
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
