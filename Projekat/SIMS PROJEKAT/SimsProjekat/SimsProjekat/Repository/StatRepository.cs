using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;

namespace Repository
{
    public class StatRepository
    {
        private string Path;
        private string Delimiter;
        public StatRepository(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public string ConvertCsv(Statistics stat)
        {
            return string.Join(Delimiter,
                stat.IdStat,
                stat.IdPatient,
                stat.Id,
                stat.Grade,
                stat.Comment);
        }

        public Statistics ConvertToStat(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int IdStat = int.Parse(tokens[0]);
            int IdPatient = int.Parse(tokens[1]);
            int Id = int.Parse(tokens[2]);
            int Grade = int.Parse(tokens[3]);
            String Comment = tokens[1];
            return new Statistics(IdStat, IdPatient, Id, Grade, Comment);
        }

        public Statistics GetById(int id)
        {
            List<Statistics> stats = GetAll().ToList();
            Statistics stat = new Statistics(-1, -1, -1, -1, "");
            foreach (Statistics s in stats)
            {
                if (s.Id == id)
                {
                    stat.IdPatient = s.IdPatient;
                    stat.Id = s.Id;
                    stat.Grade = s.Grade;
                    stat.Comment = s.Comment;
                }
            }
            return stat;
        }

        public List<Statistics> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertToStat).ToList();
        }

        public bool Delete(int id)
        {
            List<Statistics> stats = GetAll().ToList();
            bool delete = false;
            List<string> updated = new List<string>();
            foreach (Statistics statistics in stats)
            {
                if (statistics.Id != id)
                {
                    delete = true;
                    updated.Add(ConvertCsv(statistics));
                }
            }
            File.WriteAllLines(Path, updated);
            return delete;
        }

        
        
    }
}
