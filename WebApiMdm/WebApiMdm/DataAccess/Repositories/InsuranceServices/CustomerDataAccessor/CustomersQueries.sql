-- ##### Customer Queries #####

-- ##### Begin Declare Variables #####
DECLARE @Name NVARCHAR(50), @Id INT;
-- ##### End Declare Variables #####

-- ##### Begin Query: GetCustomers #####
SELECT CustomerId
      ,Username
      ,FirstName
      ,LastName
      ,Email
      ,Birthdate
      ,CURP
      ,Passport
      ,Phone
      ,Address
  FROM [dbo].[Customers]
-- ##### End Query #####

-- ##### Begin Query: GetCustomerData #####
SELECT TOP 1 CustomerId
      ,Username
      ,FirstName
      ,LastName
      ,Email
      ,Birthdate
      ,CURP
      ,Passport
      ,Phone
      ,Address
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
