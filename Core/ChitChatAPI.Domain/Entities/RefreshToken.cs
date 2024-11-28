using ChitChatAPI.Domain.Entities.Common;
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
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid UserId { get; set; }
        //public string DeviceInfo { get; set; }
        public string IpAddress { get; set; }
        [JsonIgnore]
        public User User { get; set; }  
    }
}
