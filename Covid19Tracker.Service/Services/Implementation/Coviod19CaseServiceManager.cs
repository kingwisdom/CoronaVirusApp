using Covid19Tracker.Entities.Tracker;
using Covid19Tracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Covid19Tracker.Service.Services.Implementation
{
   public class Coviod19CaseServiceManager:ICovid19CaseManagerService
    {
        private readonly IRepository<CovidCase> repositoryCovidCase;
        private readonly IRepository<RealCases> _covid;

        public Coviod19CaseServiceManager(IRepository<CovidCase> repositoryCovidCase, IRepository<RealCases> covid)
        {
            this.repositoryCovidCase = repositoryCovidCase;
            _covid = covid;
        }

        public IEnumerable<RealCases> GetCases()
        {
            return _covid.GetAll();
        }

        public int GetAllCasesCount()=>this.repositoryCovidCase.GetAll().Count;


        public int GetAllDeathCount()=> this.repositoryCovidCase.GetAll().Where(c => c.CaseStatus == CaseStatus.Death).Count();

       
        public int GetAllSickCount() => this.repositoryCovidCase.GetAll().Where(c => c.CaseStatus == CaseStatus.Sick).Count();

        public int GetAllRecoveriesCount() => this.repositoryCovidCase.GetAll().Where(c => c.CaseStatus == CaseStatus.Recovered).Count();
       
    }
}
