using Covid19Tracker.Entities.Tracker;
using System.Collections.Generic;

namespace Covid19Tracker.Service.Services.Implementation
{
    public interface ICovicServiceImplementation
    {
        public IEnumerable<RealCases> GetCases();
       


    }
}