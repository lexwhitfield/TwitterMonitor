using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.SqlServer.Models
{
    public partial class TwitterStats
    {
        public long Id { get; set; }
        public int FollowerCount { get; set; }
        public int FriendCount { get; set; }

        public virtual TwitterUser IdNavigation { get; set; }
    }
}
