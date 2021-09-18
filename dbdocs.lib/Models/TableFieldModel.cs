namespace dbdocs.lib.Models
{
    public class TableFieldModel
    {
        public int ColumnId { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public int MaxLen { get; set; }
        public int Precision { get; set; }
        public int Scale { get; set; }
        public bool IsNullable { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsComputed { get; set; }
        public string DefaultVal { get; set; }
        public string ColExtendedDesc { get; set; }
        public bool IsPK { get; set; }
        public bool IsFK { get; set; }
    }
}
