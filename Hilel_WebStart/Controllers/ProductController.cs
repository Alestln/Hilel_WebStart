using Hilel_WebStart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hilel_WebStart.Controllers;

[ApiController]
[Route($"{nameof(ProductController)}/")]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route($"{nameof(GetProductList)}")]
    public Task<IActionResult> GetProductList()
    {
        var products = new List<Product>()
        {
            new()
            {
                Id = 1,
                Name = "Apple",
                Price = 25.3m
            },
            new()
            {
                Id = 2,
                Name = "Banana",
                Price = 57.31m
            },
            new()
            {
                Id = 3,
                Name = "Cocos",
                Price = 120.5m
            }
        };

        return Task.FromResult<IActionResult>(Ok(products));
    }
}