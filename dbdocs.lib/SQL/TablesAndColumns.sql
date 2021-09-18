USE <<Replace_Me>>;

DECLARE @DbId INT = (SELECT d.database_id FROM sys.databases AS d WHERE d.name = '<<Replace_Me>>');

-- get tables
WITH CTE_Tables AS (
    SELECT
        CONCAT(@DbId,'.',t.object_id)  AS [Uid]
        ,t.object_id    AS [ObjectId]
        ,s.name         AS [SchemaName]
        ,t.name         AS [Name]
        ,t.create_date  AS [DateCreated]
        ,t.modify_date  AS [DateModified]
        ,p.[value]      AS [TblExtendedDesc]
    FROM
        sys.tables AS t
        INNER JOIN sys.schemas AS s
            ON t.schema_id = s.schema_id
        LEFT JOIN (SELECT p.major_id, p.[value] 
                   FROM sys.extended_properties AS p
                   WHERE (p.minor_id = 0)) AS p
            ON t.object_id = p.major_id
    WHERE (
        (t.is_ms_shipped = 0)
    )
),
-- get columns
CTE_Columns AS 
(
    SELECT
         c.object_id                            AS ObjectId
        ,c.column_id                            AS ColumnId
        ,c.name                                 AS ColumnName
        ,t.name                                 AS DataType
        ,c.max_length                           AS MaxLen
        ,c.[precision]                          AS [Precision]
        ,c.scale                                AS Scale
        ,c.is_nullable                          AS IsNullable
        ,c.is_identity                          AS IsIdentity
        ,c.is_computed                          AS IsComputed
        ,CAST(d.definition AS NVARCHAR)         AS DefaultVal
    FROM 
        sys.columns AS c
        INNER JOIN CTE_Tables AS ct
            ON c.object_id = ct.ObjectId
        INNER JOIN sys.types AS t
            ON c.system_type_id = t.system_type_id AND c.user_type_id = t.user_type_id
        LEFT JOIN sys.default_constraints AS d
            ON c.object_id = d.parent_object_id AND c.column_id = d.parent_column_id
),
-- Get Extended Description
CTE_XtDesc AS 
(
    SELECT
         c.ObjectId
        ,c.ColumnId
        ,p.[value]    AS ColExtendedDesc
    FROM 
        sys.extended_properties AS p
        INNER JOIN CTE_Columns AS c
            ON p.major_id = c.ObjectId
            AND p.minor_id = c.ColumnId
    WHERE(
        name = 'MS_Description' 
        AND class_desc = 'OBJECT_OR_COLUMN'
    )
),
-- Get Primary Key
CTE_PK AS
(
    SELECT 
         c.ObjectId
        ,c.ColumnId
        ,CAST(CASE WHEN kc.[type] IS NULL THEN 0
              ELSE 1
         END AS BIT) AS IsPK
    FROM CTE_Columns AS c
        LEFT JOIN sys.index_columns AS ic
            ON c.ObjectId = ic.object_id
            AND c.ColumnId = ic.column_id
        LEFT JOIN sys.key_constraints AS kc
            ON ic.object_id = kc.parent_object_id
            AND ic.index_id = kc.unique_index_id
),
CTE_FK AS 
(
    SELECT
         c.ObjectId
        ,c.ColumnId
        ,CAST(CASE WHEN fk.[type] IS NULL THEN 0
              ELSE 1
         END AS BIT) AS IsFK
        ,fc.parent_object_id
        ,fc.referenced_object_id
    FROM CTE_Columns AS c
        LEFT JOIN sys.foreign_key_columns AS fc
            --ON fk.object_id = fc.constraint_object_id
            ON c.ObjectId = fc.parent_object_id
            AND c.ColumnId = fc.parent_column_id
        LEFT JOIN sys.foreign_keys AS fk
            ON fc.constraint_object_id = fk.object_id
)

SELECT 
     t.Uid
    ,t.ObjectId
    ,t.DateCreated
    ,t.DateModified
    ,t.SchemaName
    ,t.Name
    ,t.TblExtendedDesc
    ,c.ColumnId
    ,c.ColumnName
    ,c.DataType
    ,c.MaxLen
    ,c.[Precision]
    ,c.Scale
    ,c.IsNullable
    ,c.IsIdentity
    ,c.IsComputed
    ,c.DefaultVal
    ,x.ColExtendedDesc
    ,pk.IsPK
    ,fk.IsFK
FROM 
    CTE_Tables AS t
    INNER JOIN CTE_Columns AS c
        ON t.ObjectId = c.ObjectId
    LEFT JOIN CTE_XtDesc AS x
        ON c.ObjectId = x.ObjectId
        AND c.ColumnId = x.ColumnId
    LEFT JOIN CTE_PK AS pk
        ON c.ObjectId = pk.ObjectId
        AND c.ColumnId = pk.ColumnId
    LEFT JOIN CTE_FK AS fk
        ON c.ObjectId = fk.ObjectId
        AND c.ColumnId = fk.ColumnId