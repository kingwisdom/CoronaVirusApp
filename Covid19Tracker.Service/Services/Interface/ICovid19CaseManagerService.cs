using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Tracker.Service.Services
{
  public  interface ICovid19CaseManagerService
    {
        public int GetAllCasesCount();

        public int GetAllRecoveriesCount();

        public int GetAllDeathCount();
        public int GetAllSickCount();

    }
}
