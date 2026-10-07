using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Commands
{
    public class CreateShoppingCartCommand:IRequest<ShoppingCartResponse>
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        
        public CreateShoppingCartCommand(string userName , List<ShoppingCartItem> items)
        {
            UserName = userName;
            Items = items;
        }
    }
}
