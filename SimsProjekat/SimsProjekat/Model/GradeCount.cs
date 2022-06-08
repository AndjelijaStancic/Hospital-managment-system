using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GradeCount
    {
        public String question { get; set; }
        public int grade1 { get; set; }
        public int grade2 { get; set; }
        public int grade3 { get; set; }
        public int grade4 { get; set; }
        public int grade5 { get; set; }
        
        public GradeCount(String question, int grade1, int grade2, int grade3, int grade4, int grade5)
        {
            this.question = question;
            this.grade1 = grade1;
            this.grade2 = grade2;
            this.grade3 = grade3;
            this.grade4 = grade4;
            this.grade5 = grade5;
        }
    }
}
