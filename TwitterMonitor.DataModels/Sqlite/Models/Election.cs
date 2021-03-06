﻿using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Election
    {
        public int Id { get; set; }
        public int ElectionTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ElectionDate { get; set; }

        public ElectionType ElectionType { get; set; }
        public ICollection<ConstituencyMember> Members { get; set; }
    }
}
