using WebApiMdm.DataAccess.Interfaces;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;

namespace WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductDataAccessor
{
    public interface IProductRepository: IRepository<Product>
    {
    }
}