using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> updateBasket(ShoppingCart cart);
        Task DeleteBasket(string userName);
    }
}
