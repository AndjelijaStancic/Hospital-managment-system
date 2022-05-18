using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;

namespace Repository
{
    public class EqpMenagmentRepository
    {
        private string Path;
        private string Delimiter;

        public EqpMenagmentRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public string ConvertCsv(EquipmentMenagment equipmentMenagment)
        {
            return string.Join(
                Delimiter,
                equipmentMenagment.idEqpMenag,
                equipmentMenagment.idEqp,
                equipmentMenagment.idRoom,
                equipmentMenagment.movingDay

                );
        }

        public EquipmentMenagment ConvertEqpMenagment(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            string format = "M/d/yyyy h:mm:ss tt";
            int idEqpMenag = int.Parse(tokens[0]);
            int idEqp = int.Parse(tokens[1]);
            int idRoomChange = int.Parse(tokens[2]);
            DateTime date = DateTime.ParseExact(tokens[3], format, System.Globalization.CultureInfo.InvariantCulture);


            return new EquipmentMenagment(idEqpMenag, idEqp, idRoomChange, date);
        }

        public List<EquipmentMenagment> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertEqpMenagment).ToList();
        }

        protected int NewId()
        {
            int id = 0;
            List<EquipmentMenagment> equipmentMenagments2 = GetAll().ToList();
            foreach (EquipmentMenagment equipmentMenagments in equipmentMenagments2)
            {
                if (equipmentMenagments.idEqpMenag > id)
                {
                    id = equipmentMenagments.idEqpMenag;
                }
                else if (equipmentMenagments.idEqpMenag == null)
                {
                    id = 0;
                }
            }
            return id;
        }
        public EquipmentMenagment Create(EquipmentMenagment equipmentMenagment)
        {
            List<EquipmentMenagment> equipmentMenagments = GetAll().ToList();
            int id = (NewId());
            equipmentMenagment.idEqpMenag = ++id;
            File.AppendAllText(Path, ConvertCsv(equipmentMenagment) + Environment.NewLine);
            return equipmentMenagment;

        }

        public EquipmentMenagment GetById(int id)
        {
            List<EquipmentMenagment> equipment = GetAll().ToList();
            EquipmentMenagment eqpMen = new EquipmentMenagment(-1, -1, -1, DateTime.Parse("12 / 12 / 2122"));
            foreach (EquipmentMenagment EqpMen in equipment)
            {
                if (EqpMen.idEqpMenag == id)
                {
                    eqpMen.idEqpMenag = EqpMen.idEqpMenag;
                    eqpMen.idEqp = EqpMen.idEqp;
                    eqpMen.idRoom = EqpMen.idRoom;
                    eqpMen.movingDay = EqpMen.movingDay;

                }
            }
            return eqpMen;
        }
        public bool DeleteEqpMen(int id)
        {
            List<string> updated = new List<string>();
            List<EquipmentMenagment> eqpMen = GetAll().ToList();
            bool deleted = false;

            foreach (EquipmentMenagment EqpMen in eqpMen)
            {
                if (EqpMen.idEqpMenag != id)
                {
                    string update = ConvertCsv(EqpMen);
                    updated.Add(update);
                    deleted = true;
                }
            }

            File.WriteAllLines(Path, updated);

            return deleted;
        }
    }
}
