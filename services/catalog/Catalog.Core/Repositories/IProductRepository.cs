using Catalog.Core.Entities;
using Catalog.Core.Spec;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Pagination<Product>> GetAllProducts(CatalogSpecParams catalogSpecParams); //IEnumerable => To Return As a List of Products
        Task<Product> GetProductById(string id);     //To Get Product By Id
        Task<IEnumerable<Product>> GetAllProductsByName(string name);
        Task<IEnumerable<Product>> GetAllProductsByBrand(string name);
        
        //Craete 
        Task<Product> CreateProduct(Product product);

        //Update , Delete Doesn't Return Product, It Returns Boolean Value
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);

    }
}
