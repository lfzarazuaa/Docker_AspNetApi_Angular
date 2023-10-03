using WebApiMdm.DataAccess.Repositories.AdventureWorks2019.Production.ProductDataAccessor;
using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;

namespace WebApiMdm.Services.AdventureWorks2019.Production;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(AdventureWorks2019UnitOfWork unitOfWork)
    {
        _productRepository = unitOfWork.ProductRepository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetById(id);
    }

    public Product AddProduct(Product product)
    {
        _productRepository.Insert(product);
        return product;
    }

    public Product UpdateProduct(Product product)
    {
        _productRepository.Update(product);
        return product;
    }

    public bool DeleteProduct(int id)
    {
        var existingProduct = _productRepository.GetById(id);
        if (existingProduct == null)
        {
            return false;
        }

        _productRepository.Delete(id);
        return true;
    }
}
