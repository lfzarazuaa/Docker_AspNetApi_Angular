using WebApiMdm.DataAccess.Interfaces;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Models.Dtos.Request.AdventureWorks2019.Product;

namespace WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductModelDataAccessor
{
    public interface IProductModelRepository : IRepository<ProductModel>
    {
        ProductModel GetByCriteria(ProductModelRequestDto productModel);
    }
}