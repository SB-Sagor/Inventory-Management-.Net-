using Microsoft.AspNetCore.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductsController : ControllerBase
{
    private static readonly List<Product> _products = [

        new Product{
Id=1,Name="laptop",Price=7500m,Stock=10
    },
    new Product{
        Id=2,Name="Mouse",Price=1200m,Stock=50

    },

new Product{
            Id=2,Name="Keboard",Price=2500m,Stock=25


    }

    ];
    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}