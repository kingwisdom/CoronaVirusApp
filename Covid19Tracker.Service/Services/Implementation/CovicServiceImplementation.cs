using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Entities.Tracker;
using Covid19Tracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Tracker.Service.Services.Implementation
{
    public class CovicServiceImplementation : ICovicServiceImplementation
    {
        private readonly Covid19TrackerDBContext _covid;

        public CovicServiceImplementation(Covid19TrackerDBContext covid)
        {
            _covid = covid;
        }

        
       public IEnumerable<RealCases> GetCases()
        {
            return _covid.RealCase;
        }
    }
}
