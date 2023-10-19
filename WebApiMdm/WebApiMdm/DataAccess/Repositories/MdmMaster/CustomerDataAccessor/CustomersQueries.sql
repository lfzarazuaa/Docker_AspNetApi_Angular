-- ##### Customer Queries #####

-- ##### Begin Declare Variables #####
DECLARE @Name NVARCHAR(50);
-- ##### End Declare Variables #####

-- ##### Begin Query: TruncateCopiedCustomers #####
TRUNCATE TABLE dbo.CopiedCustomers;
-- ##### End Query #####

-- ##### Begin Query: GetCopiedCustomers #####
SELECT [OriginalDB] AS OriginalDb,
       [OriginalDBID] AS OriginalDbId,
       [Username],
       [Email],
       [FirstName],
       [LastName],
       [CURP],
       [Passport]
  FROM dbo.CopiedCustomers
-- ##### End Query #####

-- ##### Begin Query: TruncateStagingCustomers #####
TRUNCATE TABLE dbo.StagingCustomers;
-- ##### End Query #####

-- ##### Begin Query: GetStagingCustomers #####
SELECT [Guid],
       [OriginalDB] AS OriginalDb,
       [OriginalDBID] AS OriginalDbId,
       [Username],
       [Email],
       [FirstName],
       [LastName],
       [CURP],
       [Passport]
  FROM dbo.StagingCustomers
-- ##### End Query #####

-- ##### Begin Query: TruncateFinalCustomers #####
TRUNCATE TABLE dbo.FinalCustomers;
-- ##### End Query #####

-- ##### Begin Query: GetFinalCustomers #####
SELECT [Guid],
       [OriginalDB] AS OriginalDb,
       [OriginalDBID] AS OriginalDbId,
       [Username],
       [Email],
       [FirstName],
       [LastName],
       [CURP],
       [Passport]
  FROM dbo.FinalCustomers
-- ##### End Query #####

-- ##### Begin Query: GetGroupedStagingCustomers #####
BEGIN
WITH NumberedStagingCustomers AS
(
    SELECT 
        [Guid],
        [OriginalDB],
        [OriginalDBID],
        [Username],
        [Email],
        [FirstName],
        [LastName],
        [CURP],
        [Passport],
        ROW_NUMBER() OVER(PARTITION BY [Guid] ORDER BY [OriginalDBID]) AS rn
    FROM [dbo].[StagingCustomers] with (nolock)
)
SELECT
    [Guid],
    MAX(CASE WHEN rn = 1 THEN [OriginalDB] END) AS [OriginalDb1],
	MAX(CASE WHEN rn = 1 THEN [OriginalDBID] END) AS [OriginalDbId1],
	MAX(CASE WHEN rn = 1 THEN [Username] END) AS [Username1],
	MAX(CASE WHEN rn = 1 THEN [Email] END) AS [Email1],
	MAX(CASE WHEN rn = 1 THEN [FirstName] END) AS [FirstName1],
	MAX(CASE WHEN rn = 1 THEN [LastName] END) AS [LastName1],
	MAX(CASE WHEN rn = 1 THEN [CURP] END) AS [CURP1],
	MAX(CASE WHEN rn = 1 THEN [Passport] END) AS [Passport1],

    MAX(CASE WHEN rn = 2 THEN [OriginalDB] END) AS [OriginalDb2],
	MAX(CASE WHEN rn = 2 THEN [OriginalDBID] END) AS [OriginalDbId2],
	MAX(CASE WHEN rn = 2 THEN [Username] END) AS [Username2],
	MAX(CASE WHEN rn = 2 THEN [Email] END) AS [Email2],
	MAX(CASE WHEN rn = 2 THEN [FirstName] END) AS [FirstName2],
	MAX(CASE WHEN rn = 2 THEN [LastName] END) AS [LastName2],
	MAX(CASE WHEN rn = 2 THEN [CURP] END) AS [CURP2],
	MAX(CASE WHEN rn = 2 THEN [Passport] END) AS [Passport2],

    MAX(CASE WHEN rn = 3 THEN [OriginalDB] END) AS [OriginalDb3],
	MAX(CASE WHEN rn = 3 THEN [OriginalDBID] END) AS [OriginalDbId3],
	MAX(CASE WHEN rn = 3 THEN [Username] END) AS [Username3],
	MAX(CASE WHEN rn = 3 THEN [Email] END) AS [Email3],
	MAX(CASE WHEN rn = 3 THEN [FirstName] END) AS [FirstName3],
	MAX(CASE WHEN rn = 3 THEN [LastName] END) AS [LastName3],
	MAX(CASE WHEN rn = 3 THEN [CURP] END) AS [CURP3],
	MAX(CASE WHEN rn = 3 THEN [Passport] END) AS [Passport3],

    MAX(CASE WHEN rn = 4 THEN [OriginalDB] END) AS [OriginalDb4],
	MAX(CASE WHEN rn = 4 THEN [OriginalDBID] END) AS [OriginalDbId4],
	MAX(CASE WHEN rn = 4 THEN [Username] END) AS [Username4],
	MAX(CASE WHEN rn = 4 THEN [Email] END) AS [Email4],
	MAX(CASE WHEN rn = 4 THEN [FirstName] END) AS [FirstName4],
	MAX(CASE WHEN rn = 4 THEN [LastName] END) AS [LastName4],
	MAX(CASE WHEN rn = 4 THEN [CURP] END) AS [CURP4],
	MAX(CASE WHEN rn = 4 THEN [Passport] END) AS [Passport4]

FROM NumberedStagingCustomers
GROUP BY [Guid]
END
-- ##### End Query #####

-- ##### Begin Query: GetGroupedFinalCustomers #####
BEGIN
WITH NumberedFinalCustomers AS
(
    SELECT 
        [Guid],
        [OriginalDB],
        [OriginalDBID],
        [Username],
        [Email],
        [FirstName],
        [LastName],
        [CURP],
        [Passport],
        ROW_NUMBER() OVER(PARTITION BY [Guid] ORDER BY [OriginalDBID]) AS rn
    FROM [dbo].[FinalCustomers] with (nolock)
)
SELECT
    [Guid],
    MAX(CASE WHEN rn = 1 THEN [OriginalDB] END) AS [OriginalDb1],
	MAX(CASE WHEN rn = 1 THEN [OriginalDBID] END) AS [OriginalDbId1],
	MAX(CASE WHEN rn = 1 THEN [Username] END) AS [Username1],
	MAX(CASE WHEN rn = 1 THEN [Email] END) AS [Email1],
	MAX(CASE WHEN rn = 1 THEN [FirstName] END) AS [FirstName1],
	MAX(CASE WHEN rn = 1 THEN [LastName] END) AS [LastName1],
	MAX(CASE WHEN rn = 1 THEN [CURP] END) AS [CURP1],
	MAX(CASE WHEN rn = 1 THEN [Passport] END) AS [Passport1],

    MAX(CASE WHEN rn = 2 THEN [OriginalDB] END) AS [OriginalDb2],
	MAX(CASE WHEN rn = 2 THEN [OriginalDBID] END) AS [OriginalDbId2],
	MAX(CASE WHEN rn = 2 THEN [Username] END) AS [Username2],
	MAX(CASE WHEN rn = 2 THEN [Email] END) AS [Email2],
	MAX(CASE WHEN rn = 2 THEN [FirstName] END) AS [FirstName2],
	MAX(CASE WHEN rn = 2 THEN [LastName] END) AS [LastName2],
	MAX(CASE WHEN rn = 2 THEN [CURP] END) AS [CURP2],
	MAX(CASE WHEN rn = 2 THEN [Passport] END) AS [Passport2],

    MAX(CASE WHEN rn = 3 THEN [OriginalDB] END) AS [OriginalDb3],
	MAX(CASE WHEN rn = 3 THEN [OriginalDBID] END) AS [OriginalDbId3],
	MAX(CASE WHEN rn = 3 THEN [Username] END) AS [Username3],
	MAX(CASE WHEN rn = 3 THEN [Email] END) AS [Email3],
	MAX(CASE WHEN rn = 3 THEN [FirstName] END) AS [FirstName3],
	MAX(CASE WHEN rn = 3 THEN [LastName] END) AS [LastName3],
	MAX(CASE WHEN rn = 3 THEN [CURP] END) AS [CURP3],
	MAX(CASE WHEN rn = 3 THEN [Passport] END) AS [Passport3],

    MAX(CASE WHEN rn = 4 THEN [OriginalDB] END) AS [OriginalDb4],
	MAX(CASE WHEN rn = 4 THEN [OriginalDBID] END) AS [OriginalDbId4],
	MAX(CASE WHEN rn = 4 THEN [Username] END) AS [Username4],
	MAX(CASE WHEN rn = 4 THEN [Email] END) AS [Email4],
	MAX(CASE WHEN rn = 4 THEN [FirstName] END) AS [FirstName4],
	MAX(CASE WHEN rn = 4 THEN [LastName] END) AS [LastName4],
	MAX(CASE WHEN rn = 4 THEN [CURP] END) AS [CURP4],
	MAX(CASE WHEN rn = 4 THEN [Passport] END) AS [Passport4]

FROM NumberedFinalCustomers
GROUP BY [Guid]
END
-- ##### End Query #####