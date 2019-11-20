using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    [Serializable]
    public class ConstituencyViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string CurrentMember { get; set; }

        public int? AuthorityId { get; set; }

        public string AuthorityName { get; set; }

        public string RegionName { get; set; }

        public string CountryName { get; set; }
    }
}
