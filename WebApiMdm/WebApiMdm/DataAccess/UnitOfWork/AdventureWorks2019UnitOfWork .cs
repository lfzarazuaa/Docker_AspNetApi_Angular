using WebApiMdm.DataAccess.Connection.AdventureWorks2019;
using WebApiMdm.DataAccess.Interfaces;
using WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductDataAccessor;
using WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductModelDataAccessor;
using WebApiMdm.DataAccess.Services;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class AdventureWorks2019UnitOfWork : UnitOfWork
{
    private readonly IAdventureWorks2019SqlQueryService _adventureWorks2019SqlQueryService;
    
    public AdventureWorks2019UnitOfWork(AdventureWorks2019DbConfig config, IAdventureWorks2019SqlQueryService sqlQueryService) : base(config.ConnectionString??"")
    {
        _adventureWorks2019SqlQueryService = sqlQueryService;
    }

    public IProductRepository ProductRepository => new ProductRepository(Connection);
    //public IRepository<ProductCategory> ProductCategoryRepository => new ProductCategoryRepository(Connection);
    public IProductModelRepository ProductModelRepository => new ProductModelRepository(Connection, _adventureWorks2019SqlQueryService);
    //public IRepository<Location> LocationRepository => new LocationRepository(Connection);
    //public IRepository<ProductDescription> ProductDescriptionRepository => new ProductDescriptionRepository(Connection);
}

