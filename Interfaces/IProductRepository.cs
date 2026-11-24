using InventoryManagement.Models;
using InventoryManagement.DTOs;

namespace InventoryManagement.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();

    Product? GetById(int id);
    List<Product> Search(string name);
    Product Add(Product product);
    bool Delete(Product product);

}