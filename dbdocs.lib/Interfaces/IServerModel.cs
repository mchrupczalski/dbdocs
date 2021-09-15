using dbdocs.lib.Models;
using System.Collections.Generic;

namespace dbdocs.lib.Interfaces
{
    public interface IServerModel
    {
        List<DatabaseModel> Databases { get; set; }
    }
}