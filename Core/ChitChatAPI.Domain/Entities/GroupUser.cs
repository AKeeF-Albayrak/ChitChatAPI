using ChitChatAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities
{
    public class GroupUser : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public Group Group { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
