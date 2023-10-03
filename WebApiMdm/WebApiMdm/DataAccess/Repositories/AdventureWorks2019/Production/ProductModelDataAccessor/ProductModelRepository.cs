using System.Data;
using Dapper;
using WebApiMdm.DataAccess.Interfaces;
using WebApiMdm.DataAccess.Services;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Models.Dtos.Request.AdventureWorks2019.Product;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductModelDataAccessor;

public class ProductModelRepository : Repository, IProductModelRepository
{

    public ProductModelRepository(IDbConnection connection, IAdventureWorks2019SqlQueryService sqlQueryService) : base(connection, sqlQueryService, "ProductModelDataAccessor", "ProductModelQueries.sql")
    {
    }

    public IEnumerable<ProductModel> GetAll()
    {
        return _connection.Query<ProductModel>(_queries["GetAllProductModels"]);
    }

    public ProductModel GetById(int id)
    {
        return _connection.QuerySingleOrDefault<ProductModel>(_queries["GetProductModelById"], new { Id = id });
    }

    public void Insert(ProductModel productModel)
    {
        _connection.Execute(_queries["InsertProductModel"], productModel);
    }

    public void Update(ProductModel productModel)
    {
        _connection.Execute(_queries["UpdateProductModel"], productModel);
    }

    public void Delete(int id)
    {
        _connection.Execute(_queries["DeleteProductModel"], new { Id = id });
    }

    public ProductModel GetByCriteria(ProductModelRequestDto productModel)
    {
        var sql = _queries["GetProductModelByCriteria"];
        return _connection.QuerySingleOrDefault<ProductModel>(sql, productModel);
    }

}



