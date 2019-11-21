﻿using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class TwitterUser
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

        public TwitterStats TwitterStats { get; set; }
        public ICollection<Member> Member { get; set; }
        public ICollection<TwitterFriends> TwitterFriendsFriend { get; set; }
        public ICollection<TwitterFriends> TwitterFriendsUser { get; set; }
    }
}
