using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels
{
    public partial class TwitterUser
    {
        public TwitterUser()
        {
            Member = new HashSet<Member>();
            TwitterFriendsFriend = new HashSet<TwitterFriends>();
            TwitterFriendsUser = new HashSet<TwitterFriends>();
        }

        public long Id { get; set; }
        public string ScreenName { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual TwitterStats TwitterStats { get; set; }
        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<TwitterFriends> TwitterFriendsFriend { get; set; }
        public virtual ICollection<TwitterFriends> TwitterFriendsUser { get; set; }
    }
}
