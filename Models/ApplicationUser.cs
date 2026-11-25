using Microsoft.AspNetCore.Identity;//dotnet er identity er build in user class amader alda kore PasswordHash create korte hobe nah 


namespace InventoryManagement.Models;

public class ApplicationUser : IdentityUser//identity namespace er modde ase
{
    public string FullName { get; set; } = string.Empty;
}