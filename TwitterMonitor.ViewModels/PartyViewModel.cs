using System;

namespace TwitterMonitor.ViewModels
{
    [Serializable]
    public class PartyViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int MemberCount { get; set; }
    }
}
