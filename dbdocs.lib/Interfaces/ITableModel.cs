using System;

namespace dbdocs.lib.Interfaces
{
    public interface ITableModel : IDbObject
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
        int ObjectId { get; set; }
        string SchemaName { get; set; }
    }
}