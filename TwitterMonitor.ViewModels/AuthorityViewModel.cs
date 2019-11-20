using System;

namespace TwitterMonitor.ViewModels
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
