SELECT
     d.database_id                  AS [Uid]
    ,d.name                         AS [Name]
    ,d.create_date                  AS CreateDate
    ,d.compatibility_level          AS CompatibilityLevel
    ,d.collation_name               AS Collation
    ,d.user_access_desc             AS UserAccess
    ,d.is_read_only                 AS IsReadOnly
FROM sys.databases AS d
WHERE d.name IN (<<Replace_Me>>)