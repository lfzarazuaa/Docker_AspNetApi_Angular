-- ##### Customer Queries #####

-- ##### Begin Declare Variables #####
DECLARE @Name NVARCHAR(50), @Id INT;
-- ##### End Declare Variables #####

-- ##### Begin Query: GetCustomers #####
SELECT CustomerId
      ,Username
      ,Email
      ,FirstName
      ,LastName
      ,Birthdate
      ,CURP
      ,Passport
  FROM [dbo].[Customers]
-- ##### End Query #####

-- ##### Begin Query: GetCustomerData #####
SELECT CustomerId
      ,Username
      ,Email
      ,FirstName
      ,LastName
      ,Birthdate
      ,CURP
      ,Passport
  FROM [dbo].[Customers]
  WHERE CustomerId=@Id
-- ##### End Query #####

-- ##### Begin Query: GetMdmCopyCustomers #####
SELECT DB_NAME() AS OriginalDb,
       CustomerId AS OriginalDbId,
       Username AS Username,
       Email AS Email,
       FirstName AS FirstName,
       LastName AS LastName,
       CURP AS CURP,
       Passport AS Passport
  FROM dbo.Customers
-- ##### End Query #####
