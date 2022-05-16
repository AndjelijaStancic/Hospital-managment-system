using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
