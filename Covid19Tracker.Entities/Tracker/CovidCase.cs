using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19Tracker.Entities.Tracker
{
    public class CovidCase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }
        public string ContractFrom { get; set; }
        public DateTime DateofRecorvery { get; set; }
        public DateTime DateOfDeath { get; set; }

        public Gender? Gender { get; set; }

        public string Nationality { get; set; }
        [MaxLength(100)]
        public CaseStatus CaseStatus { get; set; }

        public string State { get; set; }

    }

    public enum Gender
    {
        Male, Female, None
    }

    public enum CaseStatus
    {
        Sick, Recovered, Death
    }


}
