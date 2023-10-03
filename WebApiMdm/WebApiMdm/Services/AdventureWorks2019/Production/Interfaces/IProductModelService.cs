using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Models.Dtos.Request.AdventureWorks2019.Product;

namespace WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;

public interface IProductModelService
{
    IEnumerable<ProductModel> GetAllProductModels();
    ProductModel GetProductModelById(int id);
    ProductModel AddProductModel(ProductModel product);
    ProductModel UpdateProductModel(ProductModel product);
    bool DeleteProductModel(int id);
    ProductModel GetProductModelByCriteria(ProductModelRequestDto requestDto);
}
