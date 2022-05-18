using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model;
using System.IO;
using Repository;

namespace Repository
{
    public class EquipmentRepository
    {
        private string Path;
        private string Delimiter;

        public EquipmentRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }
        public string ConvertCsv(Equipment equipment)
        {
            return string.Join(
                Delimiter,
                equipment.idEquipment,
                equipment.name,
                equipment.quantity,
                equipment.type,
                equipment.idRoom
                );
        }

        public Equipment ConvertEqp(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int idEquipment = int.Parse(tokens[0]);
            String name = tokens[1];
            int quantity = int.Parse(tokens[2]);
            String type = tokens[3];
            int idRoom = int.Parse(tokens[4]);
            return new Equipment(idEquipment, name, quantity, type, idRoom);
        }

        public List<Equipment> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertEqp).ToList();
        }
        public Equipment GetById(int id)
        {
            List<Equipment> equipment = GetAll().ToList();
            Equipment eqp = new Equipment(-1, "", -1, "", -1);
            foreach (Equipment Eqp in equipment)
            {
                if (Eqp.idEquipment == id)
                {
                    eqp.idEquipment = Eqp.idEquipment;
                    eqp.name = Eqp.name;
                    eqp.quantity = Eqp.quantity;
                    eqp.type = Eqp.type;
                    eqp.idRoom = Eqp.idRoom;

                }
            }
            return eqp;
        }

        protected int NewId()
        {
            int id = 0;
            List<Equipment> equipments = GetAll().ToList();
            foreach (Equipment equipment in equipments)
            {
                if (equipment.idEquipment > id)
                {
                    id = equipment.idEquipment;
                }
                
            }
            if (equipments.Count == 0) { id = 0; }
            return id;
        }

        public Equipment Create(Equipment eqp)
        {
            if (eqp.type.Equals("S"))
            {
                eqp.quantity = 1;
            }
            List<Equipment> equipment = GetAll().ToList();
            int id = (NewId());
            eqp.idEquipment = ++id;
            File.AppendAllText(Path, ConvertCsv(eqp) + Environment.NewLine);
            return eqp;

        }

        public Equipment Update(Equipment eqp)
        {
            List<Equipment> Eqp = GetAll().ToList();
            List<string> updated = new List<string>();

            foreach (Equipment equipment in Eqp)
            {
                if (equipment.idEquipment == eqp.idEquipment)
                {
                    equipment.name = eqp.name;
                    equipment.quantity = eqp.quantity;
                    equipment.idRoom = eqp.idRoom;
                }
                string update = ConvertCsv(equipment);
                updated.Add(update);
            }

            File.WriteAllLines(Path, updated);
            return eqp;
        }

        public bool DeleteEqp(int id)
        {
            List<string> updated = new List<string>();
            List<Equipment> eqp = GetAll().ToList();
            bool deleted = false;

            foreach (Equipment Eqp in eqp)
            {
                if (Eqp.idEquipment != id)
                {
                    string update = ConvertCsv(Eqp);
                    updated.Add(update);
                    deleted = true;
                }
            }

            File.WriteAllLines(Path, updated);

            return deleted;
        }

    }
}
