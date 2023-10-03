using WebApiMdm.DataAccess.Interfaces;
using WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductModelDataAccessor;
using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Models.Dtos.Request.AdventureWorks2019.Product;
using WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;

namespace WebApiMdm.Services.AdventureWorks2019.Production;

public class ProductModelService : IProductModelService
{
    private readonly IProductModelRepository _productRepository;

    public ProductModelService(AdventureWorks2019UnitOfWork unitOfWork)
    {
        _productRepository = unitOfWork.ProductModelRepository;
    }

    public IEnumerable<ProductModel> GetAllProductModels()
    {
        return _productRepository.GetAll();
    }

    public ProductModel GetProductModelById(int id)
    {
        return _productRepository.GetById(id);
    }

    public ProductModel AddProductModel(ProductModel product)
    {
        _productRepository.Insert(product);
        return product;
    }

    public ProductModel UpdateProductModel(ProductModel product)
    {
        _productRepository.Update(product);
        return product;
    }

    public bool DeleteProductModel(int id)
    {
        var existingProductModel = _productRepository.GetById(id);
        if (existingProductModel == null)
        {
            return false;
        }

        _productRepository.Delete(id);
        return true;
    }

    public ProductModel GetProductModelByCriteria(ProductModelRequestDto requestDto)
    {
        return _productRepository.GetByCriteria(requestDto);
    }
}