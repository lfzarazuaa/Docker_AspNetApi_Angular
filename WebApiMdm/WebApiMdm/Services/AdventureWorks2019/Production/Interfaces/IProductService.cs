using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;

namespace WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    Product AddProduct(Product product);
    Product UpdateProduct(Product product);
    bool DeleteProduct(int id);
}
