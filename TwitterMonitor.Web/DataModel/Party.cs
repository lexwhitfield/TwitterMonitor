using System;
using System.Collections.Generic;

namespace WebApp.DataModel
{
    public partial class Party
    {
        public Party()
        {
            Member = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}
