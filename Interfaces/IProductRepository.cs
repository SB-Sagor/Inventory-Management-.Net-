using InventoryManagement.Models;
using InventoryManagement.DTOs;

namespace InventoryManagement.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(int id);
    Product? AddStock(int id, int quantity);
    List<Product> Search(string name);
    Product Add(Product product);
    Product? UpdateProduct(int id, decimal price);
    bool Delete(int id);

}