using InventoryManagement.Models;//model class use kora hoyese

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;//ef core er necessery class
namespace InventoryManagement.Data;//class data framework er ontorbukto

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//inherite korse DbContext database er shathe necessary infrustructure dey

// public class InventoryDbContext : DbContext     //InventoryDbContext c# product object ke database table er row te convert kore 
public class InventoryDbContext : IdentityDbContext<ApplicationUser>
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
     : base(options)//option holo database configaration program.cs a ase
                    //base parantel class DbContext cause ef core er DbContext ke janate hobe kon database use kortesi 
    {
    }

    public DbSet<Product> Products { get; set; }//ef core er maddome product table access korar entry point 
}