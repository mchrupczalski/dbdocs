using System;
using System.Collections.Generic;

namespace dbdocs.lib.Interfaces
{
    public interface IDataAccess
    {
        T ExecuteTextLoadModel<T>(string query);
        IEnumerable<T> ExecuteTextLoadModelCollection<T>(string query);
        T ExecuteTextWithOutput<T>(string query);
        IEnumerable<T> ExecuteText_LoadModelCollection_Multimapping<T, U>(string query, string splitOn, Func<T, U, T> map);
    }
}