using Dapper;
using dbdocs.lib.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace dbdocs.lib.DataAccess
{
    public class SqlServerDataAccess : IDataAccess
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public SqlServerDataAccess(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public T ExecuteTextWithOutput<T>(string query)
        {
            using (var cnx = _dbConnectionFactory.GetDBConnection())
            {
                var cmd = new SqlCommand(query, (SqlConnection)cnx);
                cmd.CommandType = System.Data.CommandType.Text;
                return (T)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Loads the model from SQL query;
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="query">SQL query to execute.</param>
        /// <returns>Model of T</returns>
        public T ExecuteTextLoadModel<T>(string query)
        {
            using (var connection = _dbConnectionFactory.GetDBConnection())
            {
                T output = connection.Query<T>(query, commandType: CommandType.Text).FirstOrDefault();
                return output;
            }
        }

        public IEnumerable<T> ExecuteTextLoadModelCollection<T>(string query)
        {
            using (var connection = _dbConnectionFactory.GetDBConnection())
            {
                IEnumerable<T> output = connection.Query<T>(query, commandType: CommandType.Text);
                return output;
            }
        }

        public IEnumerable<T> ExecuteText_LoadModelCollection_Multimapping<T,U>(string query, string splitOn, Func<T,U,T> map)
        {
            using (var cnx = _dbConnectionFactory.GetDBConnection())
            {
                return cnx.Query<T, U, T>(query, map, splitOn: splitOn).Distinct();
            }

        }
    }
}
