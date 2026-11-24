using InventoryManagement.DTOs;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
namespace InventoryManagement.Services;

public class ProductService : IProductService
{//private static use kora lagbe na AddSingleton<ProductService>() service instance a use hobe

    // private readonly List<Product> _products =
    //    [
    //        new Product
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

    // public List<Product> GetProducts()
    // {
    //     return _products;
    // }
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public List<ProductResponse> GetProducts()//ager Product chilo 
    {


        // return _productRepository.GetAll();
        var products = _productRepository.GetAll();

        return products.Select(product => new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
        }).ToList();

    }
    public ProductResponse CreateProduct(CreateProductRequest request)//ager Product chilo
    {
        var product = new Product()//DTO theke entity mapping
        {
            // Id = _products.Count + 1,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };
        // return _productRepository.Add(product);

        // _products.Add(product);
        // return product;

        var saveProduct = _productRepository.Add(product);

        var response = new ProductResponse()//entity theke DTO mapping  Request DTO alada thakle client Id pathaiya kono kichu override korte pare na.
        {
            Id = saveProduct.Id,
            Name = saveProduct.Name,
            Price = saveProduct.Price,
            Stock = saveProduct.Stock
        };
        return response;
    }



    public Product? AddStock(int id, StockRequest request)
    {
        // var product = _products.FirstOrDefault(p => p.Id == id);
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return null;
        }
        product.AddStock(request.Quantity);
        return product;
    }

    public List<Product> SearchProduct(string name)
    {


        // var products = _products
        var products = _productRepository.Search(name);
        // .Where(p => p.Name
        // .Contains(name, StringComparison.OrdinalIgnoreCase))
        // .ToList();
        return products;
    }

    public ProductResponse? GetProductById(int id)//Product chilo age
    {
        // var products = _products.FirstOrDefault(p => p.Id == id);
        var products = _productRepository.GetById(id);
        if (products == null)
        {
            return null;
        }
        // return products;

        var response = new ProductResponse
        {
            Id = products.Id,
            Name = products.Name,
            Price = products.Price,
            Stock = products.Stock
        };
        return response;

    }
    public Product? UpdateProduct(int id, UpdateProduct request)
    {
        // var product = _products.FirstOrDefault(p => p.Id == id);
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return null;
        }
        product.Price = request.Price;
        return product;

    }

    public Product? DeleteProduct(int id)
    {
        // var product = _products.FirstOrDefault(p => p.Id == id);
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return null;
        }
        bool isDeleted = _productRepository.Delete(product);
        if (!isDeleted)
        {
            return null;
        }

        // _productRepository.Delete(product);
        // _products.Remove(product);
        return product;
    }
}


