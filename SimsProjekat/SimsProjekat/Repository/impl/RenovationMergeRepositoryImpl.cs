using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;


namespace Repository
{
    public class RenovationMergeRepositoryImpl : RenovationMergeRepository
    {
        private string Path;
        private string Delimiter;

        public RenovationMergeRepositoryImpl(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }
        public string ConvertToCsv(RenovationMerge renovationMerge)
        {
            return string.Join(
                Delimiter,
                renovationMerge.Id,
                renovationMerge.RoomId1,
                renovationMerge.RoomId2,
                renovationMerge.Start,
                renovationMerge.Finish,
                renovationMerge.NewRoomName,
                (int)renovationMerge.NewRoomType,
                renovationMerge.Description
                );
        }
        public RenovationMerge ConvertToRenovationMerge(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            string format = "M/d/yyyy h:mm:ss tt";
            int idRenMer = int.Parse(tokens[0]);
            int idRoom1 = int.Parse(tokens[1]);
            int idRoom2 = int.Parse(tokens[2]);
            DateTime start = DateTime.ParseExact(tokens[3], format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime finish = DateTime.ParseExact(tokens[4], format, System.Globalization.CultureInfo.InvariantCulture);
            String newName = tokens[5];
            int newType = int.Parse(tokens[6]);
            String description = tokens[7];

            return new RenovationMerge(idRenMer, idRoom1, idRoom2, start, finish, newName, newType, description);
        }

        public List<RenovationMerge> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertToRenovationMerge).ToList();
        }

        public int NewId()
        {
            int id = 0;
            List<RenovationMerge> renMer = GetAll().ToList();
            foreach (RenovationMerge renovationMerge in renMer)
            {
                if (renovationMerge.Id > id)
                {
                    id = renovationMerge.Id;
                }
            }
            if (renMer.Count == 0) { id = 0; }
            return id;
        }
        public RenovationMerge Create(RenovationMerge renovationMerge)
        {
            int id = (NewId());
            renovationMerge.Id = ++id;
            File.AppendAllText(Path, ConvertToCsv(renovationMerge) + Environment.NewLine);
            return renovationMerge;
        }

        public bool Delete(int id)
        {
            List<string> updated = new List<string>();
            List<RenovationMerge> RenMer = GetAll().ToList();
            bool deleted = false;

            foreach (RenovationMerge renMer in RenMer)
            {
                if (renMer.Id != id)
                {
                    string update = ConvertToCsv(renMer);
                    updated.Add(update);
                    deleted = true;
                }
            }

            File.WriteAllLines(Path, updated);

            return deleted;
        }
    }
}
