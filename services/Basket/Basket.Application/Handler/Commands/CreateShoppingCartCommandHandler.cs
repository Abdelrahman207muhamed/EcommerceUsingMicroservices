using AutoMapper;
using Basket.Application.Commands;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Handler.Commands
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public CreateShoppingCartCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            //TODO Will With Integrate with Discount Service
            var shoppingCart = await _basketRepository.updateBasket(new Core.Entities.ShoppingCart
            {
                UserName = request.UserName,
                Items = request.Items
            });

            var shoppinCartResponse = _mapper.Map<ShoppingCartResponse>(shoppingCart);
            return shoppinCartResponse;

        }
    }
}
