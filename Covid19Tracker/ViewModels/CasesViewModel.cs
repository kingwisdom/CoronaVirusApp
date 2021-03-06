﻿using Covid19Tracker.Entities.Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Tracker.Web.ViewModels
{
    public class CasesViewModel
    {
        public IEnumerable<RealCases> AllCases { get; set; }

        public int All { get; set; }
        public int Recorverd { get; set; }
        public int Sick { get; set; }
        public int Death { get; set; }

        public double getrecoverbar { get; set; }
        public double getsickbar { get; set; }
        public double getdeathbar { get; set; }

    }
}
