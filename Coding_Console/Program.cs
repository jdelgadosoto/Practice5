using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;


static void Main()
{

}


/*using (AplicationDBContext context = new())
{
    context.Database.EnsureCreated();

    if (context.Database.GetPendingMigrations().Count() > 0)
    {
        context.Database.Migrate();
    }

     GetAllProducts();


    void GetAllProducts()
    {
        using var context = new AplicationDBContext();
        var Products = context.Products.ToList();

        foreach (var product in Products)
        {
            Console.WriteLine($"Id: {product.Id} Name: {product.Name} Price: {product.Price}");
        }
    }
}

    /*
        void AddProduct()
    {
        Product product = new Product();
        using var context = new AplicationDBContext();
        var products = context.Products.Add(product);
        context.SaveChanges();
    }*/

