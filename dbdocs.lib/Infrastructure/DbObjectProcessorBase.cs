using dbdocs.lib.Interfaces;

namespace dbdocs.lib.Infrastructure
{
    public class DbObjectProcessorBase
    {
        public IDataAccess DataAccess { get; }

        public DbObjectProcessorBase(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

    }
}
