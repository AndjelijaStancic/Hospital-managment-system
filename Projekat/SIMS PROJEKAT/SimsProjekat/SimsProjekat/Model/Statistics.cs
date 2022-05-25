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

        public int Grade { get; set; }

        public String Comment { get; set; } 

        public Statistics(int IdStat, int IdPatient, int Id, int Grade, String Comment)
        {
            this.IdStat = IdStat;
            this.IdPatient = IdPatient;
            this.Id = Id;
            this.Grade = Grade;
            this.Comment = Comment;
        }


    }
}
