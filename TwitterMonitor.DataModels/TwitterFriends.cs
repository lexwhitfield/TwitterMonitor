using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels
{
    public partial class TwitterFriends
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }

        public virtual TwitterUser Friend { get; set; }
        public virtual TwitterUser User { get; set; }
    }
}
