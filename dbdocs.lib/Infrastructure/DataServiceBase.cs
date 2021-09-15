using dbdocs.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Infrastructure
{
    public class DataServiceBase
    {
        public IDataAccess DataAccess { get; }

        public DataServiceBase(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

    }
}
