using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    [Serializable]
    public class PartyViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int MemberCount { get; set; }
    }
}
