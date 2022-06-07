using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatisticsHospital
    {
        public int IdStat { get; set; }

        public int IdPatient { get; set; }

        public int GradeOne { get; set; }

        public int GradeTwo { get; set; }

        public int GradeThree { get; set; }



        public StatisticsHospital(int IdStat,int IdPatient, int GradeOne, int GradeTwo, int GradeThree)
        {
            this.IdStat = IdStat;
            this.IdPatient = IdPatient;
            this.GradeOne = GradeOne;
            this.GradeTwo = GradeTwo;
            this.GradeThree = GradeThree;
        }
    }
}
