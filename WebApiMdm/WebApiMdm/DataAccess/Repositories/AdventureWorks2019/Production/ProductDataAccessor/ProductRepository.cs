using System.Data;
using Dapper;
using WebApiMdm.DataAccess.Interfaces;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;

namespace WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductDataAccessor;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Product> GetAll()
    {
        const string sql = @"
                SELECT TOP 100
                    ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag,
                    Color, SafetyStockLevel, StandardCost, ListPrice, Size,
                    SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture,
                    ProductLine, Class, Style, ProductSubcategoryID, ProductModelID,
                    SellStartDate, SellEndDate, DiscontinuedDate, ModifiedDate
                FROM Production.Product";
        var myproduct1 = _connection.Query(sql);
        var myproduct2 = _connection.Query<Product>(sql);
        return myproduct2;
    }

    public Product GetById(int id)
    {
        const string sql = @"
                SELECT 
                    ProductID, Name, ProductNumber, MakeFlag, FinishedGoodsFlag,
                    Color, SafetyStockLevel, StandardCost, ListPrice, Size,
                    SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture,
                    ProductLine, Class, Style, ProductSubcategoryID, ProductModelID,
                    SellStartDate, SellEndDate, DiscontinuedDate, ModifiedDate
                FROM Production.Product 
                WHERE ProductID = @Id";

        return _connection.QuerySingleOrDefault<Product>(sql, new { Id = id });
    }

    public void Insert(Product entity)
    {
        const string sql = @"
                INSERT INTO Production.Product 
                (
                    Name, ProductNumber, MakeFlag, FinishedGoodsFlag,
                    Color, SafetyStockLevel, StandardCost, ListPrice, Size,
                    SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture,
                    ProductLine, Class, Style, ProductSubcategoryID, ProductModelID,
                    SellStartDate, SellEndDate, DiscontinuedDate, ModifiedDate
                ) 
                VALUES 
                (
                    @Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag,
                    @Color, @SafetyStockLevel, @StandardCost, @ListPrice, @Size,
                    @SizeUnitMeasureCode, @WeightUnitMeasureCode, @Weight, @DaysToManufacture,
                    @ProductLine, @Class, @Style, @ProductSubcategoryID, @ProductModelID,
                    @SellStartDate, @SellEndDate, @DiscontinuedDate, @ModifiedDate
                )";

        _connection.Execute(sql, entity);
    }

    public void Update(Product entity)
    {
        const string sql = @"
                UPDATE Production.Product SET 
                    Name = @Name, ProductNumber = @ProductNumber, MakeFlag = @MakeFlag, 
                    FinishedGoodsFlag = @FinishedGoodsFlag, Color = @Color, 
                    SafetyStockLevel = @SafetyStockLevel, StandardCost = @StandardCost, 
                    ListPrice = @ListPrice, Size = @Size, 
                    SizeUnitMeasureCode = @SizeUnitMeasureCode, 
                    WeightUnitMeasureCode = @WeightUnitMeasureCode, Weight = @Weight, 
                    DaysToManufacture = @DaysToManufacture, ProductLine = @ProductLine, 
                    Class = @Class, Style = @Style, 
                    ProductSubcategoryID = @ProductSubcategoryID, 
                    ProductModelID = @ProductModelID, SellStartDate = @SellStartDate, 
                    SellEndDate = @SellEndDate, DiscontinuedDate = @DiscontinuedDate, 
                    ModifiedDate = @ModifiedDate
                WHERE ProductID = @ProductID";

        _connection.Execute(sql, entity);
    }

    public void Delete(int id)
    {
        const string sql = "DELETE FROM Production.Product WHERE ProductID = @Id";
        _connection.Execute(sql, new { Id = id });
    }
}
