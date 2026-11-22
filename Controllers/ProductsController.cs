using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase // built-in api er response Ok(), NotFound(), BadRequest() egula support kore 
{
    private static readonly List<Product> _products =
    [
        new Product
        {
            Id = 1,
            Name = "laptop",
            Price = 7500m,
            Stock = 10,
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 1200m,
            Stock = 50,
        },
        new Product
        {
            Id = 3,
            Name = "Keyboard",
            Price = 2500m,
            Stock = 25,
        },
    ];

    [HttpGet]
    public IEnumerable<Product> GetProducts() // kono check need hoy na
    {
        return _products; // direct product list return kore 
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest request) // IActionResult dotnet er return type ja http response pathate pare 200/400/404
    {
        var product = new Product
        {
            Id = _products.Count + 1,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        _products.Add(product); // product ke list a add korbe
        return Ok(product);
    }

    [HttpPost("add-stock")]
    public IActionResult AddStock(int id, StockRequest request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id); // p temporary parameter

        if (product == null)
        {
            return NotFound();
        }
        product.AddStock(request.Quantity);
        return Ok(product);
    }

    [HttpGet("search")]
    public IActionResult SearchProduct(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest();
        }
        var products = _products
            .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) // where collection return kore 
            .ToList();

        return Ok(products);
    }

    [HttpGet("GetProductById")]
    public IActionResult GetProductById(int id)
    {
        var products = _products.FirstOrDefault(p => p.Id == id);
        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPatch("updateProduct")]
    public IActionResult UpdateProduct(int id, UpdateProduct request)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        product.Price = request.Price;

        return Ok(product);
    }
}