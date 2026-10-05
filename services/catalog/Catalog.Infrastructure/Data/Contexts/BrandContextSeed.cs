using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class BrandContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductBrand> brandCollection)
        {
            var  hasBrands = await brandCollection.Find(_=>true).AnyAsync();
            if (hasBrands)
                return;

            var filepath = Path.Combine(AppContext.BaseDirectory,"Data", "SeedData", "brands.json");
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"Seed File Not Exists :{filepath}");
                return;
            }
            var brandData = await File.ReadAllTextAsync(filepath);
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

            if (brands?.Any() is true)
            {
                await brandCollection.InsertManyAsync(brands);
            }

        }
    }
}
