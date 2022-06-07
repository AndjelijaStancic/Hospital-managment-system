using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EquipmentDisplay
    {
        public string nameRoom { get; set; }
        public int idEquipment { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }   
        public string type { get; set; }

        public EquipmentDisplay(string roomName, int IdEquipment, string Name, int Quantity, string Type)
        {
            nameRoom = roomName;
            idEquipment = IdEquipment;
            quantity = Quantity;
            name = Name;
            type = Type;
            
        }


    }
}
