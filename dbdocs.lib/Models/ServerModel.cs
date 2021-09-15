using dbdocs.lib.Interfaces;
using System.Collections.Generic;

namespace dbdocs.lib.Models
{
    public class ServerModel : IServerModel
    {
        public List<DatabaseModel> Databases { get; set; } = new List<DatabaseModel>();
    }
}
