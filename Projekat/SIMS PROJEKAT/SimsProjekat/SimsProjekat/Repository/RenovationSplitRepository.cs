using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;


namespace Repository
{
    public class RenovationSplitRepository
    {
        private string Path;
        private string Delimiter;

        public RenovationSplitRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }
        public string ConvertToCsv(RenovationSplit renovationSplit)
        {
            return string.Join(
                Delimiter,
                renovationSplit.Id,
                renovationSplit.RoomId,
                renovationSplit.NewRoomName1,
                renovationSplit.NewRoomName2,
                (int)renovationSplit.NewRoomType1,
                (int)renovationSplit.NewRoomType2,
                renovationSplit.Start,
                renovationSplit.Finish,
                renovationSplit.Description
                );
        }
        public RenovationSplit ConvertToRenovationSplit(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            string format = "M/d/yyyy h:mm:ss tt";
            int Id = int.Parse(tokens[0]);
            int RoomId = int.Parse(tokens[1]);
            String NewName1 = tokens[2];
            String NewName2 = tokens[3];
            int NewType1 = int.Parse(tokens[4]);
            int NewType2 = int.Parse(tokens[5]);
            DateTime Start = DateTime.ParseExact(tokens[6], format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime Finish = DateTime.ParseExact(tokens[7], format, System.Globalization.CultureInfo.InvariantCulture);
            String Description = tokens[8];

            return new RenovationSplit(Id, RoomId, NewName1, NewName2, NewType1, NewType2, Start, Finish, Description);
        }

        public List<RenovationSplit> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertToRenovationSplit).ToList();
        }

        protected int NewId()
        {
            int id = 0;
            List<RenovationSplit> renSplit = GetAll().ToList();
            foreach (RenovationSplit renovationSplit in renSplit)
            {
                if (renovationSplit.Id > id)
                {
                    id = renovationSplit.Id;
                }
            }
            if (renSplit.Count == 0) { id = 0; }
            return id;
        }

        public RenovationSplit Create(RenovationSplit renovationSplit)
        {
            int id = (NewId());
            renovationSplit.Id = ++id;
            File.AppendAllText(Path, ConvertToCsv(renovationSplit) + Environment.NewLine);
            return renovationSplit;
        }

        public bool Delete(int id)
        {
            List<string> updated = new List<string>();
            List<RenovationSplit> RenSplit = GetAll().ToList();
            bool deleted = false;

            foreach (RenovationSplit renSplit in RenSplit)
            {
                if (renSplit.Id != id)
                {
                    string update = ConvertToCsv(renSplit);
                    updated.Add(update);
                    deleted = true;
                }
            }

            File.WriteAllLines(Path, updated);

            return deleted;
        }
    }
}
