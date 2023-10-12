"-- ##### RetailBanking Utils Queries #####

-- ##### Begin Declare Variables #####
DECLARE @Name NVARCHAR(50);
-- ##### End Declare Variables #####

-- ##### Begin Query: GetDatabaseVersion #####
SELECT CONCAT(' DbName = ',DB_NAME(),', ',@@VERSION)
-- ##### End Query #####

-- ##### Begin Query: GetDatabaseTables #####
SELECT 
    DB_NAME() AS DatabaseName,
    t.TABLE_NAME AS TableName,
    c.COLUMN_NAME AS FieldName,
    c.DATA_TYPE AS DataType,
    c.CHARACTER_MAXIMUM_LENGTH AS MaxLength
FROM 
    INFORMATION_SCHEMA.TABLES AS t
JOIN 
    INFORMATION_SCHEMA.COLUMNS AS c ON t.TABLE_NAME = c.TABLE_NAME
WHERE 
    t.TABLE_CATALOG = DB_NAME() AND t.TABLE_TYPE = 'BASE TABLE'
ORDER BY 
    t.TABLE_NAME, c.ORDINAL_POSITION;
-- ##### End Query #####
"
