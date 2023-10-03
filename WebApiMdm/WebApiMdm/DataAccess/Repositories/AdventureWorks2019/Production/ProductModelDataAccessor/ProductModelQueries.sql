-- ##### Product Model Queries #####

-- ##### Begin Declare Variables #####
DECLARE @ProductModelID INT, @Name NVARCHAR(50), @CatalogDescription NVARCHAR(MAX), @Instructions NVARCHAR(MAX), @ModifiedDate DATETIME;
-- ##### End Declare Variables #####

-- ##### Begin Query: GetAllProductModels #####
SELECT TOP 100
		p.ProductModelID,
		p.[Name],
		p.CatalogDescription,
		p.Instructions,
		p.ModifiedDate
FROM Production.ProductModel AS p
-- ##### End Query #####

-- ##### Begin Query: GetProductModelById #####
SELECT 
    p.ProductModelID, p.Name, p.CatalogDescription, p.Instructions, p.ModifiedDate
FROM Production.ProductModel AS p
WHERE ProductModelID = @ProductModelID
-- ##### End Query #####

-- ##### Begin Query: InsertProductModel #####
INSERT INTO Production.ProductModel (Name, CatalogDescription, Instructions, ModifiedDate)
VALUES (@Name, @CatalogDescription, @Instructions, @ModifiedDate);
-- ##### End Query #####

-- ##### Begin Query: UpdateProductModel #####
UPDATE Production.ProductModel
SET
    Name = @Name,
    CatalogDescription = @CatalogDescription,
    Instructions = @Instructions,
    ModifiedDate = @ModifiedDate
WHERE ProductModelID = @ProductModelID;
-- ##### End Query #####

-- ##### Begin Query: DeleteProductModel #####
DELETE FROM Production.ProductModel
WHERE ProductModelID = @ProductModelID;
-- ##### End Query #####

-- ##### Begin Query: GetProductModelByCriteria #####
SELECT 
    p.ProductModelID, p.[Name], p.CatalogDescription, p.Instructions, p.ModifiedDate
FROM Production.ProductModel AS p
WHERE 
    (@Name IS NULL OR p.[Name] = @Name) AND
    (@ModifiedDate IS NULL OR ModifiedDate = @ModifiedDate)
-- ##### End Query #####
