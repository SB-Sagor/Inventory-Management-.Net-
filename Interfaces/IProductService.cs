using InventoryManagement.DTOs;
using InventoryManagement.Models;
namespace InventoryManagement.Interfaces;


public interface IProductService
{
    List<ProductResponse> GetProducts();//age product chilo return type a 
    // Product CreateProduct(CreateProductRequest request);
    ProductResponse CreateProduct(CreateProductRequest request);
    Product? AddStock(int id, StockRequest request);
    List<Product> SearchProduct(string name);
    // Product? GetProductById(int id);
    ProductResponse? GetProductById(int id);
    Product? UpdateProduct(int id, UpdateProduct request);
    Product? DeleteProduct(int id);
}