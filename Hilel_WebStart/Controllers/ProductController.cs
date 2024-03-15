using Hilel_WebStart.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hilel_WebStart.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly List<Product> _ctx =
    [
        new Product
        {
            Id = 1,
            Name = "Apple",
            Price = 25.3m
        },

        new Product
        {
            Id = 2,
            Name = "Banana",
            Price = 57.31m
        },

        new Product
        {
            Id = 3,
            Name = "Cocos",
            Price = 120.5m
        }
    ];
    
    [HttpGet]
    public IActionResult Get()
    {
        var products = _ctx.OrderBy(p => p.Id);
        
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        
        var product = _ctx.FirstOrDefault(p => p.Id == id);

        if (product is not null)
        {
            return Ok(product);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody]Product product)
    {
        var id = _ctx.Max(p => p.Id);

        product.Id = ++id;
        
        _ctx.Add(product);
        
        return CreatedAtAction($"{nameof(Create)}", product.Id);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product product)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        
        var stored = _ctx.FirstOrDefault(p => p.Id == id);
        
        if (stored is null)
        {
            return NotFound();
        }

        _ctx.Remove(stored);

        product.Id = id;
        
        _ctx.Add(product);
        
        return CreatedAtAction($"{nameof(Update)}", product.Id);;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        
        var stored = _ctx.FirstOrDefault(p => p.Id == id);
        
        if (stored is null)
        {
            return NotFound();
        }
        
        _ctx.Remove(stored);
        
        return Ok(stored);
    }
    
}