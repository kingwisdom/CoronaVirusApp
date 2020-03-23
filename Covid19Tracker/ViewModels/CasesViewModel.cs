using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Tracker.Web.ViewModels
{
    public class CasesViewModel
    {
        public int All { get; set; }
        public int Recorverd { get; set; }
        public int Sick { get; set; }
        public int Death { get; set; }

        public int getrecoverbar { get; set; }
        public int getsickbar { get; set; }
        public int getdeathbar { get; set; }

    }
}
