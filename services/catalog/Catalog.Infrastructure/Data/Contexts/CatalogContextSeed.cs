using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class CatalogContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<Product> productCollection)
        {
            var hasProducts = await productCollection.Find(_ => true).AnyAsync();
            if (hasProducts)
                return;

            var filepath = Path.Combine(AppContext.BaseDirectory,"Data", "SeedData", "products.json");
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"Seed File Not Exists :{filepath}");
                return;
            }
            var productData = await File.ReadAllTextAsync(filepath);
            var products = JsonSerializer.Deserialize<List<Product>>(productData);

            if (products?.Any() is true)
            {
                await productCollection.InsertManyAsync(products);
            }

        }
    }
}
