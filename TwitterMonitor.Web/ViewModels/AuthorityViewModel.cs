using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    [Serializable]
    public class AuthorityViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public string CountryName { get; set; }
    }
}
