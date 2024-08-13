using ContosoPizza.Data;

namespace ContosoPizza;

public class Program {
  public static void Main(string[] args) {
    using ContosoPizzaContext context = new ContosoPizzaContext();
    
    // Product veggieSpecial = new Product() {
    //     Name = "Veggie Special Pizza",
    //     Price = 9.99m
    // };
    // context.Add(veggieSpecial);
    //
    // Product deluxeMeat = new Product() {
    //     Name = "Deluxe Meat Pizza",
    //     Price = 12.99M
    // };
    // context.Add(deluxeMeat);
    //
    // context.SaveChanges();

    // var products = context.Products
    //                      .Where(p => p.Price > 10.00M)
    //                      .OrderBy(p => p.Name);

    var veggieSpecial = context.Products
                               .Where(p => p.Name == "Veggie Special Pizza")
                               .FirstOrDefault();

    if (veggieSpecial is not null) {
      veggieSpecial.Price = 10.99M;
    }

    context.SaveChanges();
    
    var products = from product in context.Products
                   where product.Price > 10.00M
                   orderby product.Name
                   select product;

    foreach (Product p in products) {
      Console.WriteLine($"Id:       {p.Id}");
      Console.WriteLine($"Name:     {p.Name}");
      Console.WriteLine($"Price:    {p.Price}");
      Console.WriteLine(new string('-', 20));
    }
  }
}