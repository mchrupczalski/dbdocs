using dbdocs.lib.Interfaces;
using System;
using System.Collections.Generic;

namespace dbdocs.lib.Models
{
    public class TableModel : ITableModel
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public int ObjectId { get; set; }
        public string SchemaName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string TblExtendedDesc { get; set; }
        public List<TableFieldModel> Fields { get; set; } = new List<TableFieldModel>();
    }
}
