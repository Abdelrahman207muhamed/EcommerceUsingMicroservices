using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache= redisCache;

        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> updateBasket(ShoppingCart cart)
        {
            var basket = await _redisCache.GetStringAsync(cart.UserName);
            if (basket != null)
            {
                //return logic=> الافضل ان ارجعلو ايرور ان الباسكيت موجودة بالفعل 
                //ان انا اريترن اي حاجة انا عايزها 
                //لو موجود رجعو علي طول 
                return await GetBasket(cart.UserName);   //لازم اتشيك علي الحتة دي كويس 
            }
            else
            {
                //لو مش موجود اعمل سيف وبعدين رجعو 
                await _redisCache.SetStringAsync(cart.UserName, JsonConvert.SerializeObject(cart));
                return await GetBasket(cart.UserName);
            }
            /*
              (لازم اتشيك ان اليوزرنيم دا مش موجود قبل ما اسجل علشان لو عندي اتنين يوزر بنفس الاسم هيحصل مشكله =>(لو موجود رجع مسدج قولو ان اليوزر داموجود 
            */}
        public async Task DeleteBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if ((basket != null))
            {
                await _redisCache.RemoveAsync(userName);     //لو الباسكيت موجود اعمل دليت
            }
            //مفروض اقولو else واهندل اللوجيك بطريقة تانية 
        }
    }
}
