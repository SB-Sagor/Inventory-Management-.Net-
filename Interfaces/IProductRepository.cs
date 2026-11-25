using InventoryManagement.Models;
using InventoryManagement.DTOs;
using System.Threading.Tasks;
using System.Net.Http.Headers;
namespace InventoryManagement.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(int id);
    // Product? AddStock(int id, int quantity);
    Task<Product?> AddStock(int id, int quantity);//cause implementation ayscronus so task use
                                                  // Product Add(Product product);task pore return kore delay 

    Task<Product> Add(Product product);

    List<Product> Search(string name);
    // Product? UpdateProduct(int id, decimal price);
    Task<Product?> UpdateProduct(int id, decimal price);
    Task<bool> Delete(int id);

}