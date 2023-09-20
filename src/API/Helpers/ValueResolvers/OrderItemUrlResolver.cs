﻿using API.Dtos;
using AutoMapper;
using AutoMapper.Execution;
using Core.Entities.OrderAggregate;

namespace API.Helpers.ValueResolvers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _config;

        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }


        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Item.PhotoUrl))
            {
                return _config["ApiUrl"] + source.Item.PhotoUrl; 
            }
            return null;
        }
    }
}
