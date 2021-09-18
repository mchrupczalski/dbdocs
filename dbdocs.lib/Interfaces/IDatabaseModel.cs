using System;

namespace dbdocs.lib.Interfaces
{
    public interface IDatabaseModel : IDbObject
    {
        string Collation { get; set; }
        int CompatibilityLevel { get; set; }
        DateTime CreateDate { get; set; }
        bool IsReadOnly { get; set; }
        string UserAccess { get; set; }
    }
}