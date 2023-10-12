using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Models.Dtos.Request.AdventureWorks2019.Product;
using WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;

namespace WebApiMdm.Controllers.AdventureWorks2019;
[Route("api/[controller]")]
[ApiController]
public class ProductModelsController : ControllerBase
{
    private readonly IProductModelService _productModelService;

    public ProductModelsController(IProductModelService productModelService)
    {
        _productModelService = productModelService;
    }

    // GET: api/ProductModels
    [HttpGet]
    public ActionResult<IEnumerable<ProductModel>> Get()
    {
        return Ok(_productModelService.GetAllProductModels());
    }

    // GET: api/ProductModels/5
    [HttpGet("{id}")]
    public ActionResult<ProductModel> Get(int id)
    {
        var productModel = _productModelService.GetProductModelById(id);
        if (productModel == null)
        {
            return NotFound();
        }
        return Ok(productModel);
    }

    // POST: api/ProductModels
    [HttpPost]
    public ActionResult<ProductModel> Post([FromBody] ProductModel productModel)
    {
        if (productModel == null)
        {
            return BadRequest("Invalid productModel data.");
        }

        var addedProductModel = _productModelService.AddProductModel(productModel);
        return CreatedAtAction(nameof(Get), new { id = addedProductModel.ProductModelID }, addedProductModel);
    }

    // PUT: api/ProductModels/5
    [HttpPut("{id}")]
    public ActionResult<ProductModel> Put(int id, [FromBody] ProductModel productModel)
    {
        if (id != productModel.ProductModelID)
        {
            return BadRequest("ID mismatch.");
        }

        var updatedProductModel = _productModelService.UpdateProductModel(productModel);
        return Ok(updatedProductModel);
    }

    // DELETE: api/ProductModels/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _productModelService.DeleteProductModel(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPost("searchByCriteria")]
    public ActionResult<ProductModel> GetProductModelByCriteria([FromBody] ProductModelRequestDto requestDto)
    {
        var productModel = _productModelService.GetProductModelByCriteria(requestDto);
        if (productModel == null) return NotFound();
        return Ok(productModel);
    }

}

