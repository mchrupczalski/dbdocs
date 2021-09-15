using dbdocs.lib.Interfaces;
using System;

namespace dbdocs.lib.Models
{
    public class DatabaseModel : IDbObject, IDatabaseModel
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int CompatibilityLevel { get; set; }
        public string Collation { get; set; }
        public string UserAccess { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
