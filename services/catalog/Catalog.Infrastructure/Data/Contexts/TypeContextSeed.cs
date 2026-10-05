using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Data.Contexts
{
    public static class TypeContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductType> typeCollection)
        {
            var hasTypes = await typeCollection.Find(_ => true).AnyAsync();
            if (hasTypes)
                return;

            var filepath = Path.Combine(AppContext.BaseDirectory, "Data", "SeedData", "types.json");
            if (!File.Exists(filepath))
            {
                Console.WriteLine($"Seed File Not Exists :{filepath}");
                return;
            }
            var typeData = await File.ReadAllTextAsync(filepath);
            var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

            if (types?.Any() is true)
            {
                await typeCollection.InsertManyAsync(types);
            }

        }
    }
}
