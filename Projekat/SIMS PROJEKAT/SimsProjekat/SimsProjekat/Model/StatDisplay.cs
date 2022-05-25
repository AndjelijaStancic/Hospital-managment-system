using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatDisplay
    {
        public String Name { get; set; }
        public Double Grade { get; set; }
        public List<String> Comments { get; set; }

        public StatDisplay(String Name, Double Grade, List<String> Comment)
        {
            this.Name = Name;
            this.Grade = Grade; 
            this.Comments = Comment;
        }
    }
}
