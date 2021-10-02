using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASA_Hackathon.Models
{
    public class Level1Model
    {
        public enum Gender { male, female };
        public enum VaccineBrand { AstraZeneca, BioNTech, Moderna, 嬌生, 高端};

        public int age { get; set; }
        public Gender gender { get; set; }
        public int vaccinDoses { get; set; }
        public VaccineBrand vaccineBrand { get; set; }
        public DateTime date { get; set; }
    }
}
