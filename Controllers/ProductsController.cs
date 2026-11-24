using InventoryManagement.DTOs;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Services;
using InventoryManagement.Interfaces;
namespace InventoryManagement.Controllers;


[ApiController]//api controller behaivour enable kore 
[Route("api/[controller]")]
public class ProductsController : ControllerBase // built-in api er response Ok(), NotFound(), BadRequest() egula support kore 
{
    // private static readonly List<Product> _products =
    // [
    //     new Product
    //     {
    //         Id = 1,
    //         Name = "laptop",
    //         Price = 7500m,
    //         Stock = 10,
    //     },
    //     new Product
    //     {
    //         Id = 2,
    //         Name = "Mouse",
    //         Price = 1200m,
    //         Stock = 50,
    //     },
    //     new Product
    //     {
    //         Id = 3,
    //         Name = "Keyboard",
    //         Price = 2500m,
    //         Stock = 25,
    //     },
    // ];


    // private readonly ProductService _productService;
    private readonly IProductService _productService;


    public ProductsController(IProductService productService)//or ProductService
    {
        _productService = productService;
    }

    [HttpGet]
    public IEnumerable<ProductResponse> GetProducts() // kono check need hoy na
    {//age product return type chilo
        // return _products; // direct product list return kore 
        return _productService.GetProducts();
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest request) // IActionResult dotnet er return type ja http response pathate pare 200/400/404
    {
        // var product = new Product
        // {
        //     Id = _products.Count + 1,
        //     Name = request.Name,
        //     Price = request.Price,
        //     Stock = request.Stock
        // };

        // _products.Add(product); // product ke list a add korbe
        // return Ok(product);
        var product = _productService.CreateProduct(request);
        // return Ok(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);//CreatedAtAction(nameof(ActionName),routeValues, responseBody);
    }

    [HttpPost("add-stock")]
    public IActionResult AddStock(int id, StockRequest request)
    {
        // var product = _products.FirstOrDefault(p => p.Id == id); // p temporary parameter

        // if (product == null)
        // {
        //     return NotFound();
        // }
        // product.AddStock(request.Quantity);
        // return Ok(product);

        var product = _productService.AddStock(id, request);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("search")]
    public IActionResult SearchProduct(string name)
    {
        // if (string.IsNullOrWhiteSpace(name))
        // {
        //     return BadRequest();
        // }
        // var products = _products
        //     .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) // where collection return kore 
        //     .ToList();

        // return Ok(products);
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest();
        }
        var products = _productService.SearchProduct(name);


        return Ok(products);

    }

    [HttpGet("GetProductById")]
    public IActionResult GetProductById(int id)
    {
        // var products = _products.FirstOrDefault(p => p.Id == id);
        // if (products == null)
        // {
        //     return NotFound();
        // }
        // return Ok(products);
        var products = _productService.GetProductById(id);
        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPatch("updateProduct")]
    public IActionResult UpdateProduct(int id, UpdateProduct request)
    {
        // var product = _products.FirstOrDefault(p => p.Id == id);
        // if (product == null)
        // {
        //     return NotFound();
        // }
        // product.Price = request.Price;

        // return Ok(product);

        var product = _productService.UpdateProduct(id, request);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);

    }

    [HttpDelete("deleteProduct")]
    public IActionResult DeleteProduct(int id)
    {
        // var product = _products.FirstOrDefault(p => p.Id == id);
        // if (product == null)
        // {
        //     return NotFound();

        // }
        // _products.Remove(product);
        // return NoContent();

        var product = _productService.DeleteProduct(id);
        if (product == null)
        {
            return NotFound();

        }
        return NoContent();
    }
}