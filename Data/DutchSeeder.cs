using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext context;
        private readonly IWebHostEnvironment environment;

        public DutchSeeder(DutchContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(File.ReadAllText(Path.Combine(environment.ContentRootPath, "Data/art.json")));
                context.AddRange(products);
                context.Orders.Add(
                    new Order()
                    {
                        OrderDate = DateTime.Today,
                        OrderNumber = "1000",
                        Items = new List<OrderItem>()
                        {
                            new OrderItem()
                            {
                                Product = products.First(),
                                Quantity = 5,
                                UnitPrice= products.First().Price
                            }
                        }
                    });
                context.SaveChanges();
            }
        }
    }
}
