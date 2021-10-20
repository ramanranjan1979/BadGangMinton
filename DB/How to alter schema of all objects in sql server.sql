SELECT 'ALTER SCHEMA BG TRANSFER [' + SysSchemas.Name + '].[' + DbObjects.Name + '];'
FROM sys.Objects DbObjects
INNER JOIN sys.Schemas SysSchemas ON DbObjects.schema_id = SysSchemas.schema_id
WHERE SysSchemas.Name = 'dbo'
AND (DbObjects.Type IN ('U', 'P', 'V'))