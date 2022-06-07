using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;

namespace Repository
{
    public class StatRepositoryImpl : StatRepository
    {
        private string Path;
        private string Delimiter;
        public StatRepositoryImpl(string path, string delimiter)
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
                stat.GradeOne,
                stat.GradeTwo,
                stat.GradeThree
                );
        }

        public Statistics ConvertToStat(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int IdStat = int.Parse(tokens[0]);
            int IdPatient = int.Parse(tokens[1]);
            int Id = int.Parse(tokens[2]);
            int GradeOne = int.Parse(tokens[3]);
            int GradeTwo = int.Parse(tokens[4]);
            int GradeThree = int.Parse(tokens[5]);
            return new Statistics(IdStat, IdPatient, Id, GradeOne, GradeTwo, GradeThree);
        }

        public Statistics GetById(int id)
        {
            List<Statistics> stats = GetAll().ToList();
            Statistics stat = new Statistics(-1, -1, -1, -1, -1, -1);
            foreach (Statistics s in stats)
            {
                if (s.IdStat == id)
                {
                    stat.IdPatient = s.IdPatient;
                    stat.Id = s.Id;
                    stat.GradeOne = s.GradeOne;
                    stat.GradeTwo = s.GradeTwo;
                    stat.GradeThree = s.GradeThree;
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
                if (statistics.IdStat != id)
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
