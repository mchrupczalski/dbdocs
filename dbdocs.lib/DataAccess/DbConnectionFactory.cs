using dbdocs.lib.Interfaces;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace dbdocs.lib.DataAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _cnxString;

        public DbConnectionFactory(string cnxString)
        {
            if (string.IsNullOrEmpty(cnxString))
            {
                throw new System.ArgumentException($"'{nameof(cnxString)}' cannot be null or empty.", nameof(cnxString));
            }

            _cnxString = cnxString;
        }

        public IDbConnection GetDBConnection()
        {
            var factory = DbProviderFactories.GetFactory("Microsoft.Data.SqlClient");
            var cnx = factory.CreateConnection();
            cnx.ConnectionString = GetConnectionString();
            cnx.Open();
            return cnx;
        }

        private string GetConnectionString() => _cnxString;
    }
}
