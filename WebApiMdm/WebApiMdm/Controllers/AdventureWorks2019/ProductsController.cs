using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMdm.DataAccess.Repositories.AdventureWorks2019;
using WebApiMdm.Models.DbModels.AdventureWorks2019.Production;
using WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;

namespace WebApiMdm.Controllers.AdventureWorks2019;


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/Products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(_productService.GetAllProducts());
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    // POST: api/Products
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Invalid product data.");
        }

        var addedProduct = _productService.AddProduct(product);
        return CreatedAtAction(nameof(Get), new { id = addedProduct.ProductID }, addedProduct);
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    public ActionResult<Product> Put(int id, [FromBody] Product product)
    {
        if (id != product.ProductID)
        {
            return BadRequest("ID mismatch.");
        }

        var updatedProduct = _productService.UpdateProduct(product);
        return Ok(updatedProduct);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _productService.DeleteProduct(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}