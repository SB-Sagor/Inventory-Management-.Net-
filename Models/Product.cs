namespace InventoryManagement.Models;

public class Product
{
    public int Id { get; set; }//get set na kole model binding fail korbe/database a colomn create hobe nah /json sirialization fail korbe/get valu read kore and set value change kore 
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }

}