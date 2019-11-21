﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterMonitor.ViewModels
{
    public class EventViewModel
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Happened { get; set; }
    }
}
