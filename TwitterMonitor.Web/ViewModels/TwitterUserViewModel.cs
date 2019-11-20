using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class TwitterUserViewModel
    {
        public long Id { get; set; }
        public string ScreenName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MostRecentFriendCount { get; set; }
        public int MostRecentFollowerCount { get; set; }
    }
}
