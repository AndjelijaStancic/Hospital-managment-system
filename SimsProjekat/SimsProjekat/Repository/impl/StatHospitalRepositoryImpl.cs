using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;

namespace Repository
{
    public class StatHospitalRepositoryImpl : StatHospitalRepository
    {
        private string Path;
        private string Delimiter;
        public StatHospitalRepositoryImpl(string path, string delimiter)
        {
            Path = path;
            Delimiter = delimiter;
        }

        public string ConvertCsv(StatisticsHospital stat)
        {
            return string.Join(Delimiter,
                stat.IdStat,
                stat.IdPatient,
                stat.GradeOne,
                stat.GradeTwo,
                stat.GradeThree
                );
        }

        public StatisticsHospital ConvertToStat(string CsvFormat)
        {
            var tokens = CsvFormat.Split(Delimiter.ToCharArray());
            int IdStat = int.Parse(tokens[0]);
            int IdPatient = int.Parse(tokens[1]);
            int GradeOne = int.Parse(tokens[2]);
            int GradeTwo = int.Parse(tokens[3]);
            int GradeThree = int.Parse(tokens[4]);
            return new StatisticsHospital(IdStat, IdPatient, GradeOne, GradeTwo, GradeThree);
        }

        public List<StatisticsHospital> GetAll()
        {
            return File.ReadAllLines(Path).Select(ConvertToStat).ToList();
        }

        public bool Delete(int id)
        {
            List<StatisticsHospital> stats = GetAll().ToList();
            bool delete = false;
            List<string> updated = new List<string>();
            foreach (StatisticsHospital statistics in stats)
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
