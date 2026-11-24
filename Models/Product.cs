namespace InventoryManagement.Models;

public class Product
{
    public int Id { get; set; } // get set na korle model binding fail korbe / database a column create hobe nah / json serialization fail korbe / get value read kore and set value change kore 
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product()
    {

    }

    public Product(string name, decimal price, int stock)
    {
        Console.WriteLine("this is a constructor");
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void AddStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("quantity must be greater then zero");
        }

        Stock = Stock + quantity;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("quantity must be greater then zero");
        }
        if (Stock < quantity)
        {
            throw new ArgumentException("insufficient stock");
        }
        Stock -= quantity;
    }
}