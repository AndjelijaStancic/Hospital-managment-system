using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Renovation
    {
        public int IdReno { get; set; }

        public int IdRoom { get; set; } 

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public String Description { get; set; }

        public Renovation(int idReno, int idRoom, DateTime start, DateTime finish, String description)
        {
            IdReno = idReno;
            IdRoom = idRoom;
            Start = start;
            Finish = finish;
            Description = description;
        }


    }
}
