using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EquipmentMenagment
    {
        public int idEqpMenag { get; set; }

        public int idEqp { get; set; }  
        public int idRoom { get; set; }

        public  DateTime movingDay { get; set; }

        

        public EquipmentMenagment(int IdEqpMenag,int IdEqp, int IdRoom, DateTime MovingDay)
        {
            idEqpMenag = IdEqpMenag;
            idEqp = IdEqp;
            idRoom = IdRoom;
            movingDay = MovingDay;
        }
    }
}
