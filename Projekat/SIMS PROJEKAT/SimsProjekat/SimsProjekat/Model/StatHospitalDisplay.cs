using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatHospitalDisplay
    {
        public Double GradeOne { get; set; }

        public Double GradeTwo { get; set; }

        public Double GradeThree { get; set; }

        public Double Grade { get; set; }

        

        public StatHospitalDisplay(Double GradeOne, Double GradeTwno, Double GradeThree, Double Grade)
        {
            this.GradeOne = GradeOne;
            this.GradeTwo = GradeTwno;
            this.GradeThree = GradeThree;
            this.Grade = Grade;
            
        }
    }
}
