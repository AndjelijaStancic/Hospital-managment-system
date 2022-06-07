using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatDisplay
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Double GradeOne { get; set; }

        public Double GradeTwo { get; set; }

        public Double GradeThree { get; set; }
        
        public Double Grade { get; set; }   
        

        public StatDisplay(int Id, String Name, Double GradeOne, Double GradeTwno, Double GradeThree, Double Grade)
        {
            this.Id = Id;
            this.Name = Name;
            this.GradeOne = GradeOne;
            this.GradeTwo = GradeTwno;
            this.GradeThree = GradeThree;
            this.Grade = Grade; 
            
        }
    }
}
