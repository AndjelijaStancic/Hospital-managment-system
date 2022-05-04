using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;
namespace Repository
{
    public class RenovationRepository
    {
        private string Path;
        private string Delimiter;

        public RenovationRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public string ConvertCsv(Renovation renovation)
        {
            return string.Join(
                Delimiter,
                renovation.IdReno,
                renovation.IdRoom,
                renovation.Start,
                renovation.Finish,
                renovation.Description
                );
        }
        public Renovation ConvertReno(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            string format = "M/d/yyyy h:mm:ss tt";
            int idReno = int.Parse(tokens[0]);
            int idRoom = int.Parse(tokens[1]);
            DateTime start = DateTime.ParseExact(tokens[2], format, System.Globalization.CultureInfo.InvariantCulture);
            DateTime finish = DateTime.ParseExact(tokens[3], format, System.Globalization.CultureInfo.InvariantCulture);
            String description = tokens[4];

            return new Renovation(idReno, idRoom, start, finish, description);
        }

        public List<Renovation> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertReno).ToList();
        }

        protected int NewId()
        {
            int id = 0;
            List<Renovation> reno = GetAll().ToList();
            foreach (Renovation renovation in reno)
            {
                if (renovation.IdReno > id)
                {
                    id = renovation.IdReno;
                }
            }
            if(reno.Count == 0) { id = 0; }
            return id;
        }
        public Renovation Create(Renovation reno)
        {
            int id = (NewId());
            reno.IdReno = ++id;
            File.AppendAllText(Path, ConvertCsv(reno) + Environment.NewLine);
            return reno;
        }
    }
}
