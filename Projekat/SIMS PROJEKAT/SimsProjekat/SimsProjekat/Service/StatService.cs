using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace Service
{
    public class StatService
    {
        public readonly StatRepository stat_Repository;

        public StatService(StatRepository statRepository)
        {
            stat_Repository = statRepository;
        }
        
        public List<Statistics> GetAll()
        {
            return stat_Repository.GetAll();
        } 
    }
}
