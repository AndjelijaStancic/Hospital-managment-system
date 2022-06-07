using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Statistics
    {
        public int IdStat { get; set; } 

        public int IdPatient { get; set; }

        public int Id { get; set; }

        public int GradeOne { get; set; }

        public int GradeTwo { get; set; }

        public int GradeThree { get; set; }



        public Statistics(int IdStat, int IdPatient, int Id, int GradeOne, int GradeTwo, int GradeThree)
        {
            this.IdStat = IdStat;
            this.IdPatient = IdPatient;
            this.Id = Id;
            this.GradeOne = GradeOne;   
            this.GradeTwo = GradeTwo;
            this.GradeThree = GradeThree;
        }


    }
}
