using dbdocs.lib.Infrastructure;
using dbdocs.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbdocs.lib.Services
{
    public class SqlServerDataService : DataServiceBase
    {
        public SqlServerDataService(IDataAccess dataAccess) : base(dataAccess)
        {
        }
    }
}
