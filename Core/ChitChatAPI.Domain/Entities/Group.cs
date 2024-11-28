using ChitChatAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChitChatAPI.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        [JsonIgnore]
        public ICollection<GroupUser> GroupUsers { get; set; }
        [JsonIgnore]
        public ICollection<GroupMessage> GroupMessages { get; set; }
        [JsonIgnore]
        public User CreatedBy { get; set; }
    }
}
