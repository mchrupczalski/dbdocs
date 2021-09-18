USE <<Replace_Me>>;

DECLARE @DbId INT = (SELECT d.database_id FROM sys.databases AS d WHERE d.name = '<<Replace_Me>>');

SELECT
     CONCAT(@DbId,'.',t.object_id)  AS [Uid]
    ,t.object_id    AS [ObjectId]
    ,s.name         AS [SchemaName]
    ,t.name         AS [Name]
    ,t.create_date  AS [DateCreated]
    ,t.modify_date  AS [DateModified]
FROM
    sys.tables AS t
    INNER JOIN sys.schemas AS s
        ON t.schema_id = s.schema_id